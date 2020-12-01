using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeeklyPlanner.Areas.Identity.Data;
using WeeklyPlanner.Data;
using static WeeklyPlanner.Controllers.UserController;

namespace WeeklyPlanner.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly WeeklyPlannerContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(
            WeeklyPlannerContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();
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

            return View(new DisplayViewModel
            {
                Roles = roles.Select(x => x.NormalizedName),
                Users = convertedUsers
            });
        }


        //
        public IActionResult UserAndRole()
        {
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();


            var convertedUsersRoles = roles.Select(x => new RoleViewModel
            {
                Name = x.Name,
                Users = users.Where(y => userRoles.Any(z => z.UserId == x.Id && z.RoleId == y.Id))
                    .Select(y => new UsersViewModel
                    {
                        Email = y.Email
                    })
            });
            ViewBag.UsersRoles = convertedUsersRoles;

            //return View(new UserAndRoleViewModel
            //{
            //    Roles = convertedUsersRoles,
            //    Users = users.Select(x=> x.NormalizedUserName)
            //});
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel vm)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = vm.Name });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleViewModel vm)
        {
            if (vm.UserEmail != null && vm.Role != null)

            {
                foreach (var checkrole in vm.Role)
                {

                    var user = await _userManager.FindByEmailAsync(vm.UserEmail);

                    if (vm.Delete)
                        await _userManager.RemoveFromRoleAsync(user, checkrole);
                    else
                        await _userManager.AddToRoleAsync(user, checkrole);
                }
            }
            return RedirectToAction("Index");


        }
    }

    public class DisplayViewModel
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<UsersViewModel> Users { get; set; }
        //Addition
        public bool Delete { get; set; }
    }


    public class UsersRole
    {
        public string Name { get; set; }
    }
    //Addition
    //public class UserAndRoleViewModel
    //{        
    //    public IEnumerable<UsersViewModel> Users { get; set; }
    //    public IEnumerable<RoleViewModel> Roles { get; set; }      

    //}
    public class RoleViewModel
    {
        public string Name { get; set; }

        //Addition
        public IEnumerable<string> Roles { get; set; }
        public string Role { get; set; }
        public IEnumerable<UsersViewModel> Users { get; set; }

    }

    public class 
        UserRoleViewModel
    {
        public IEnumerable<UsersViewModel> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }


        public string UserEmail { get; set; }
        //public string Role { get; set; }
        public List<string> Role { get; set; }
        public bool Delete { get; set; }
    }

    public class UpdateUserRoleViewModel
    {
        public IEnumerable<UsersViewModel> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }


        public string UserEmail { get; set; }
        //public string Role { get; set; }
        public List<string> Role { get; set; }
        public bool Delete { get; set; }
    }
}