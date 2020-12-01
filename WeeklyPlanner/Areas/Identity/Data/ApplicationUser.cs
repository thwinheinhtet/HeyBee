using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyPlanner.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string Position { get; set; }
    }
}
