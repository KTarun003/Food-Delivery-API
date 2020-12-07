using System.Collections;
using System.Collections.Generic;

namespace Zinger_API.Models
{
	public class Order
	{
		public Order()
		{
			Items = new HashSet<OrderItem>();
		}
		public string OrderId { get; set; }

		public string RestaurantId { get; set; }

		public string CustomerId { get; set; }

		public string AgentId { get; set; }

		public string Instructions { get; set; }

		public int Quantity { get; set; }

		public float Amount { get; set; }

		public string OrderStatus { get; set; }

		public Agent Agent { get; set; }

		public Customer Customer { get; set; }

		public Restaurant Restaurant { get; set; }

		public ICollection<OrderItem> Items { get; set; }
	}
}