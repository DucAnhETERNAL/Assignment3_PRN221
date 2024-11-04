using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShoppingWeb.Pages
{
    public class LogoutModel : PageModel
    {
		public IActionResult OnGet()
		{
			
			HttpContext.Session.Remove("UserName");
			HttpContext.Session.Remove("FullName");
			HttpContext.Session.Remove("Type");
			TempData["LogoutMessage"] = "You have been logged out successfully.";

			return RedirectToPage("/Index");
		}

	}
}
