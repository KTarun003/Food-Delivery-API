using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zinger_API.Data;
using Zinger_API.Models;
using Zinger_API.ViewModels;

namespace Zinger_API.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;

		public UserController(ApplicationDbContext context)
		{
			_context = context;
		}
		
		// GET : api/users
		[HttpGet]
		public ActionResult<IEnumerable<ApplicationUser>> GetAllUsers()
		{
			return _context.Users.ToList();
		}
		
		// POST : api/users
		[HttpPost]
		public async Task<ActionResult<ApplicationUser>> CreateUser(UserVm userVm)
		{
			userVm.User.UserId = Guid.NewGuid().ToString();
			await _context.Users.AddAsync(userVm.User);
			if (userVm.Type.Equals("Restaurant"))
			{
				Restaurant restaurant = new Restaurant()
				{
					RestaurantId = Guid.NewGuid().ToString(),
					UserId = userVm.User.UserId
				};
				await _context.Restaurants.AddAsync(restaurant);
			}
			if (userVm.Type.Equals("Customer"))
			{
				Customer customer = new Customer
				{
					CustomerId = Guid.NewGuid().ToString(),
					UserId = userVm.User.UserId
				};
				await _context.Customers.AddAsync(customer);
			}
			if (userVm.Type.Equals("Agent"))
			{
				Agent agent = new Agent
				{
					AgentId = Guid.NewGuid().ToString(),
					UserId = userVm.User.UserId
				};
				await _context.Agents.AddAsync(agent);
			}
			await _context.SaveChangesAsync();
			return CreatedAtAction("CreateUser", new {id = userVm.User.UserId}, userVm.User);
		}
	}
}