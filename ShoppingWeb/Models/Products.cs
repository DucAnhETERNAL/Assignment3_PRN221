using System.ComponentModel.DataAnnotations;

namespace Assignment2_ShoppingWeb.Models
{
	public class Products
	{
		[Key]
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int SupplierID { get; set; }
		public int CategoryID { get; set; }
		public string QuantityPerUnit { get; set; }
		public decimal UnitPrice { get; set; }
		public string ProductImage { get; set; }

		public Suppliers Supplier { get; set; }
		public Categories Category { get; set; }
		public ICollection<Order_Details> OrderDetails { get; set; }
	}
}
