using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWeb.Pages
{
    public class LoginModel : PageModel
    {
        private readonly Assignment2_ShoppingWeb.Models.ApplicationDBContext _context;

        public LoginModel(Assignment2_ShoppingWeb.Models.ApplicationDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            // Kiểm tra thông tin đăng nhập
            var account = _context.Accounts.FirstOrDefault(a => a.UserName == Username && a.Password == Password);
            if (account != null)
            {
                HttpContext.Session.SetString("UserName", account.UserName);
                HttpContext.Session.SetString("FullName", account.FullName);
                HttpContext.Session.SetInt32("Type",account.Type);
                TempData["LoginMessage"] = "You have been logged in successfully.";
                return RedirectToPage("/Index"); 
            }

           
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
