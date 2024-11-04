using System.ComponentModel.DataAnnotations;

namespace Assignment2_ShoppingWeb.Models
{
	public class Categories
	{

		[Key]
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public ICollection<Products> Products { get; set; }
	}
}
