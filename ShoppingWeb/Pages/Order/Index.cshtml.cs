using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment2_ShoppingWeb.Models;

namespace ShoppingWeb.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;

        public IndexModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Orders> Orders { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Orders = await _context.Orders
                .Include(o => o.customer).ToListAsync();
            }
        }
    }
}
