using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2_ShoppingWeb.Models;

namespace ShoppingWeb.Pages.Member
{
    public class EditModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;

        public EditModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context)
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

            var customers =  await _context.Customers.FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customers == null)
            {
                return NotFound();
            }
            Customers = customers;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(Customers.CustomerID))
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

        private bool CustomersExists(int id)
        {
          return (_context.Customers?.Any(e => e.CustomerID == id)).GetValueOrDefault();
        }
    }
}
