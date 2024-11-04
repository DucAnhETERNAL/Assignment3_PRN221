using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment2_ShoppingWeb.Models;

namespace ShoppingWeb.Pages.Member
{
    public class DeleteModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;

        public DeleteModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Customers Customers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerID == id);

            if (customers == null)
            {
                return NotFound();
            }
            else 
            {
                Customers = customers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }
            var customers = await _context.Customers.FindAsync(id);

            if (customers != null)
            {
                Customers = customers;
                _context.Customers.Remove(Customers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
