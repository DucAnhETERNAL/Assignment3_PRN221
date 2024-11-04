using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2_ShoppingWeb.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace ShoppingWeb.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        
        public CreateModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult OnGet()
        {
			ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName"); // Hiển thị tên danh mục
			ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "CompanyName"); // Hiển thị tên nhà cung cấp
			return Page();
        }
        [Required(ErrorMessage = "Please choose at least one file.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png, jpg, jpeg, gif")]
        [Display(Name = "Choose image pizza to upload")]
        [BindProperty]
        public IFormFile[] filesUpload { get; set; }
        [BindProperty]
        public Products Products { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
			if (_context.Products == null || Products == null)
			{
				return Page();
			}

			if (filesUpload != null && filesUpload.Length > 0)
			{
				// Thư mục images sẽ nằm trong wwwroot
				var uploadFolder = Path.Combine(_environment.WebRootPath, "images");

				// Kiểm tra xem thư mục đã tồn tại chưa, nếu chưa thì tạo
				if (!Directory.Exists(uploadFolder))
				{
					Directory.CreateDirectory(uploadFolder);
				}

				foreach (var fileUpload in filesUpload)
				{
					// Lấy tên tệp
					var fileName = Path.GetFileName(fileUpload.FileName);
					var filePath = Path.Combine(uploadFolder, fileName);

					// Lưu file vào thư mục wwwroot/images
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						await fileUpload.CopyToAsync(fileStream);
					}

					// Lưu đường dẫn tương đối của hình ảnh để lưu vào CSDL
					Products.ProductImage = $"/images/{fileName}";
				}
			}


			_context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
