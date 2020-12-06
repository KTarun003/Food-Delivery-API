using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zinger_API.Data;
using Zinger_API.Models;

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
		
		[HttpGet]
		public ActionResult<IEnumerable<ApplicationUser>> GetAllUsers()
		{
			
			return _context.Users.ToList();
		}
		
		// POST : api/users
		[HttpPost]
		public async Task<ActionResult<ApplicationUser>> CreateUser(ApplicationUser user)
		{
			user.UserId = Guid.NewGuid().ToString();
			await _context.Users.AddAsync(user);
			// if (type.Equals("Restaurant"))
			// {
			// 	Restaurant restaurant = new Restaurant()
			// 	{
			// 		RestaurantId = Guid.NewGuid().ToString(),
			// 		UserId = obj.user.UserId
			// 	};
			// 	await _context.Restaurants.AddAsync(restaurant);
			// }
			await _context.SaveChangesAsync();
			return CreatedAtAction("CreateUser", new {id = user.UserId}, user);
		}
	}
}