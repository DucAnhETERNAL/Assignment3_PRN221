using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Text.Json.Serialization.Metadata;

namespace Assignment2_ShoppingWeb.Models
{
	public class Orders
	{
		[Key]
		public int OrderID { get; set; }
		public int CustomerID { get; set; }
		public DateTime OrderDate{ get; set; }
		public DateTime? RequiredDate { get; set; }
		public DateTime? ShippedDate { get; set; }
		[Required]
		[Display(Name = "Freight")]
		public decimal Freight { get; set; }
		[Display(Name = "Shipping Address")]
		public string ShipAddress { get; set; }

		public Customers customer { get; set; }
		public ICollection<Order_Details> OrderDetails { get; set; }

	}
}
