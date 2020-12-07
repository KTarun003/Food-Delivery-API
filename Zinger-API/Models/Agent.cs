using System.Collections.Generic;

namespace Zinger_API.Models
{
	public class Agent
	{
		public Agent()
		{
			Orders = new HashSet<Order>();
		}
		
		public string AgentId { get; set; }

		public string UserId { get; set; }

		public string AgentStatus { get; set; }

		public ApplicationUser User { get; set; }
		
		public ICollection<Order> Orders { get; set; }
	}
}