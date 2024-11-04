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
    public class IndexModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;

        public IndexModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get;set; } = default!;
		[BindProperty(SupportsGet = true)]
		public string? SearchKeyword { get; set; }

		[BindProperty(SupportsGet = true)]
		public decimal? MinPrice { get; set; }

		[BindProperty(SupportsGet = true)]
		public decimal? MaxPrice { get; set; }
		public async Task OnGetAsync()
        {
			var query = _context.Products.Include(p => p.Supplier).Include(p => p.Category).AsQueryable();

			if (!string.IsNullOrEmpty(SearchKeyword))
			{
				query = query.Where(p => p.ProductName.Contains(SearchKeyword));
			}

			if (MinPrice.HasValue && MaxPrice.HasValue)
			{
				query = query.Where(p => p.UnitPrice >= MinPrice.Value && p.UnitPrice <= MaxPrice.Value);
			}
			else if (MinPrice.HasValue)
			{
				query = query.Where(p => p.UnitPrice >= MinPrice.Value);
			}
			else if (MaxPrice.HasValue)
			{
				query = query.Where(p => p.UnitPrice <= MaxPrice.Value);
			}

			Products = await query.ToListAsync();
		}
    }
}
