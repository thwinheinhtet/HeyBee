using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeeklyPlanner.Areas.Identity.Data;

namespace WeeklyPlanner.Data
{
    public class WeeklyPlannerContext : IdentityDbContext<ApplicationUser>
    {
        public WeeklyPlannerContext(DbContextOptions<WeeklyPlannerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "WeeklyPlanner_Roles"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable(name: "WeeklyPlanner_RoleClaims"); });
            builder.Entity<IdentityUser>(entity => { entity.ToTable(name: "WeeklyPlanner_Users"); });
            builder.Entity<ApplicationUser>(entity => { entity.ToTable(name: "WeeklyPlanner_ApplicationUsers"); });
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable(name: "WeeklyPlanner_UserClaims"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable(name: "WeeklyPlanner_UserLogins"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable(name: "WeeklyPlanner_UserRoles"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable(name: "WeeklyPlanner_UserTokens"); });

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
