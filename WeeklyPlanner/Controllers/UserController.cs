using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeeklyPlanner.Areas.Identity.Data;
using WeeklyPlanner.Data;

namespace WeeklyPlanner.Controllers
{
	public class UserController : Controller
	{
		// GET: /<controller>/
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly WeeklyPlannerContext _context;
		//private readonly RoleManager<IdentityRole> _roleManager;

		public UserController(
		   WeeklyPlannerContext context,
		   UserManager<ApplicationUser> userManager)
		//RoleManager<IdentityRole> roleManager)
		{
			//_roleManager = roleManager;
			_userManager = userManager;
			_context = context;
		}

		//public IActionResult Index()
		//      {
		//          return View();
		//      }

		public IActionResult Index()
		{
			var users = _context.Users.ToList();
			var roles = _context.Roles.ToList();

			var userRoles = _context.UserRoles.ToList();

			var convertedUsers = users.Select(x => new UsersViewModel
			{
				Email = x.Email,
				Roles = roles
					.Where(y => userRoles.Any(z => z.UserId == x.Id && z.RoleId == y.Id))
					.Select(y => new UsersRole
					{
						Name = y.NormalizedName
					})
			});
			ViewBag.Users = convertedUsers;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(string email)
		{
			var user = new ApplicationUser
			{
				UserName = email,
				Email = email
			};

			await _userManager.CreateAsync(user, "password");

			return RedirectToAction("Index");
		}

		public class UsersViewModel
		{
			public string Email { get; set; }
			public IEnumerable<UsersRole> Roles { get; set; }
		}
	}
}