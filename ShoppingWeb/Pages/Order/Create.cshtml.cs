using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2_ShoppingWeb.Models;

namespace ShoppingWeb.Pages.Order
{
    public class CreateModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;

        public CreateModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Set<Customers>(), "CustomerID", "ContactName");
            return Page();
        }

        [BindProperty]
        public Orders Orders { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Orders == null || Orders == null)
            {
                return Page();
            }

            _context.Orders.Add(Orders);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
