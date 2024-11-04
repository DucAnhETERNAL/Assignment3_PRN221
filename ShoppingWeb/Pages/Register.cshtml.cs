using Assignment2_ShoppingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWeb.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public RegisterModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }

       
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            var account = new Account
            {
                UserName = Username,
                Password = Password, 
                Type = 0 
            };

            // Lưu vào cơ sở dữ liệu
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

           
            return RedirectToPage("/Login");
        }
    }
}
