using System.Collections.Generic;

namespace Zinger_API.Models
{
	public class Restaurant
	{
		public Restaurant()
		{
			Orders = new HashSet<Order>();
			Items = new HashSet<MenuItem>();
		}
		
		public string RestaurantId { get; set; }

		public string UserId { get; set; }

		public ApplicationUser User { get; set; }

		public ICollection<MenuItem> Items { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}