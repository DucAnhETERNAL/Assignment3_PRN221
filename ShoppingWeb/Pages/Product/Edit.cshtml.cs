using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Assignment2_ShoppingWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingWeb.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;
        private readonly IHostEnvironment _environment; // Để xử lý đường dẫn lưu trữ file

        public EditModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Products Products { get; set; } = default!;

        [BindProperty]
        public IFormFile? filesUpload { get; set; } // Thuộc tính để nhận file upload

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }
            Products = products;
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName"); // Hiển thị tên danh mục
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "CompanyName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra nếu có file upload
            if (filesUpload != null)
            {
                // Lấy tên file và tạo đường dẫn để lưu file vào thư mục wwwroot/Images
                var fileName = Path.GetFileName(filesUpload.FileName);
                var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "Images", fileName);

                // Lưu file vào đường dẫn
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await filesUpload.CopyToAsync(fileStream);
                }

                // Cập nhật tên file vào thuộc tính ProductImage
                Products.ProductImage = $"/Images/{fileName}";
            }
            else
            {
                // Nếu không có file mới, giữ nguyên ảnh cũ
                var existingProduct = await _context.Products
                                                   .AsNoTracking()
                                                   .FirstOrDefaultAsync(p => p.ProductID == Products.ProductID);
                if (existingProduct != null)
                {
                    Products.ProductImage = existingProduct.ProductImage;
                }
            }

            _context.Attach(Products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(Products.ProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductsExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
