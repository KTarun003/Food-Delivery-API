using System.Collections.Generic;

namespace Zinger_API.Models
{
	public class MenuItem
	{
		public string ItemId { get; set; }

		public string RestaurantId { get; set; }

		public string Name { get; set; }

		public string Category { get; set; }

		public float Price { get; set; }

		public Restaurant Restaurant { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }
	}
}