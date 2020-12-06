namespace Zinger_API.Models
{
	public class OrderItem
	{
		public string ItemId { get; set; }

		public string OrderId { get; set; }

		public int Quantity { get; set; }

		public Order Order { get; set; }

		public MenuItem Item { get; set; }
	}
}