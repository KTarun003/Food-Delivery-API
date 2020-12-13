using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Zinger_API.Data;
using Zinger_API.Models;

namespace Zinger_API.Controllers.RestaurantAPI
{
	[Route("api/restaurant/orders")]
	[ApiController]
	public class OrdersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public OrdersController(ApplicationDbContext context)
		{
			_context = context;
		}
		
		// GET : api/restaurant/orders/id
		[HttpGet("{id}")]
		public ActionResult<IEnumerable<Order>> Index(string id,[FromBody] string status)
		{
			List<Order> orders = new List<Order>();
			List<OrderItem> orderItems = _context.OrderItems.ToList();
			if (status.Equals("Pending"))
			{
				orders = _context.Orders.Where(o => o.RestaurantId.Equals(id) && o.OrderStatus.Equals("Pending")).ToList();
			}
			else
			{
				orders = _context.Orders.Where(o => o.RestaurantId.Equals(id)).ToList();
			}
			foreach (var order in orders)
			{
				foreach (var item in orderItems)
				{
					if (item.OrderId.Equals(order.OrderId))
					{
						item.Item = _context.MenuItems.Find(item.ItemId);
						order.Items.Add(item);
					}
				}
			}
			return orders;
		}
		
		// POST : api/restaurant/orders
		[HttpPost]
		public ActionResult<Order> AddOrder([FromBody] Order order)
		{
			foreach (var agent in _context.Agents.ToList().Where(agent => agent.AgentStatus.Equals("Ready")))
			{
				order.AgentId = agent.AgentId;
				break;
			}
			_context.Orders.Add(order);
			_context.SaveChanges();
			return CreatedAtAction("AddOrder", order);
		}

		//PUT : api/restaurant/orders
		[HttpPut]
		public ActionResult UpdateOrder([FromBody] Order order)
		{
			_context.Orders.Update(order);
			_context.SaveChanges();
			return NoContent();
		}
	}
}