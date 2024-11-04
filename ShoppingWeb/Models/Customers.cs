using System.ComponentModel.DataAnnotations;

namespace Assignment2_ShoppingWeb.Models
{
	public class Customers
	{
		[Key]
		public int CustomerID { get; set; }
		
		[Display(Name = "Customer Name")]
		[Required(ErrorMessage = "Customer Name is required!")]
		public string ContactName { get; set; }
		
		[Required(ErrorMessage = "Password is required!")]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Address")]
        public string Address { get; set; }

		[Required(ErrorMessage = "Phone number is required!")]
		[Display(Name = "Phone Number")]
		public string Phone { get; set; }
		public ICollection<Orders> Orders { get; set; }

	}
}
