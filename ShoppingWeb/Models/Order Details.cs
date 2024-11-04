namespace Assignment2_ShoppingWeb.Models
{
	public class Order_Details
	{
		public int OrderID { get; set; }
		public int ProductID { get; set; }
		public decimal UnitPrice {  get; set; }
		public int Quantity { get; set; }
		public Products Product { get; set; }
		public Orders Order { get; set;}
	}
}
