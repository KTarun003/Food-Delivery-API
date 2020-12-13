using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Zinger_API.Data;
using Zinger_API.Models;

namespace Zinger_API.Controllers.CustomerAPI
{
	[Route("api/customer/orders")]
	[ApiController]
	public class OrdersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public OrdersController(ApplicationDbContext context)
		{
			_context = context;
		}
		
		// GET : api/customer/orders/id
		[HttpGet("{id}")]
		public ActionResult<IEnumerable<Order>> Index(string id)
		{
			return _context.Orders.Where(o => o.CustomerId.Equals(id)).ToList();
		}
		
		// POST : api/customer/orders
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

		//PUT : api/customer/orders
		[HttpPut]
		public ActionResult UpdateOrder([FromBody] Order order)
		{
			_context.Orders.Update(order);
			_context.SaveChanges();
			return NoContent();
		}
	}
}