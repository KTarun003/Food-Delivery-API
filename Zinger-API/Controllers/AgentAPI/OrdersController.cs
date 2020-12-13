using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Zinger_API.Data;
using Zinger_API.Models;

namespace Zinger_API.Controllers.AgentAPI
{
	[Route("api/agent/orders")]
	[ApiController]
	public class OrdersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public OrdersController(ApplicationDbContext context)
		{
			_context = context;
		}
		
		// GET : api/agent/orders/id
		[HttpGet("{id}")]
		public ActionResult<IEnumerable<Order>> Index(string id)
		{
			return _context.Orders.Where(o => o.AgentId.Equals(id)).ToList();
		}
		
		//PUT : api/agent/orders
		[HttpPut]
		public ActionResult UpdateOrder([FromBody] Order order)
		{
			_context.Orders.Update(order);
			_context.SaveChanges();
			return NoContent();
		}
	}
}