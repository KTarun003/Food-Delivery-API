using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Zinger_API.Data;
using Zinger_API.Models;

namespace Zinger_API.Controllers.RestaurantAPI
{
	[Route("api/restaurant/menu")]
	public class MenuController : Controller
	{
		private readonly ApplicationDbContext _context;
		
		public MenuController(ApplicationDbContext context)
		{
			_context = context;
		}
		
		// GET : api/restaurant/menu/{restaurantId}
		[HttpGet("{restId}")]
		public ActionResult<IEnumerable<MenuItem>> GetMenu(string restId)
		{
			return _context.MenuItems.Where(m => m.RestaurantId.Equals(restId)).ToList();
		}
		
		// POST : api/restaurant/menu/{restaurantId}
		[HttpPost]
		public ActionResult<IEnumerable<MenuItem>> AddMenu([FromBody] IEnumerable<MenuItem> menu)
		{
			_context.MenuItems.AddRange(menu);
			_context.SaveChanges();
			return CreatedAtAction("AddMenu", menu);
		}
		
		// PUT : api/restaurant/menu/{restaurantId}
		[HttpPut]
		public ActionResult<IEnumerable<MenuItem>> UpdateMenu([FromBody] IEnumerable<MenuItem> menu)
		{
			foreach (var item in menu)
			{
				_context.MenuItems.Update(item);
			}
			_context.SaveChanges();
			return NoContent();
		}
	}
}