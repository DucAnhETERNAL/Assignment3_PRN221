using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment2_ShoppingWeb.Models;

namespace ShoppingWeb.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;

        public DetailsModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context)
        {
            _context = context;
        }

      public Products Products { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
			.Include(p => p.Supplier) 
			.Include(p => p.Category)
			.FirstOrDefaultAsync(m => m.ProductID == id);

			if (products == null)
            {
                return NotFound();
            }
            else 
            {
                Products = products;
            }
            return Page();
        }
    }
}
