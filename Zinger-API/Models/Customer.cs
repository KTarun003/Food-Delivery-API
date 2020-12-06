using System.Collections.Generic;

namespace Zinger_API.Models
{
	public class Customer
	{
		public string CustomerId { get; set; }

		public string UserId { get; set; }

		public ApplicationUser User { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}