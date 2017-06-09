using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProdBuilder0920.Domain;

namespace ProdBuilder0920.DataService.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admins"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "admins" };
                roleManager.Create(role);
            }

            //context.PackageSeries.AddOrUpdate(x => x.PackageSeriesId,
            //new PackageSeries() {PackageSeriesId = 1, PackageSeriesName = "Base"});

            if (!Queryable.Any(context.Users, u => u.UserName == "admin@admin.com"))
            {
                var userStore = new UserStore<AppUser>(context);
                var userManager = new UserManager<AppUser>(userStore);
                var user = new AppUser
                {
                    UserName = "admin@admin.com",
                    Email = "fredrik@kodmentor.se",
                    FirstName = "ADMINFIRSTNAME",
                    LastName = "ADMINLASTNAME",
                    CompanyName = "admincompany",
                    DeliveryAdress = "adminadr"

                }; userManager.Create(user, "P@ssw0rd"); userManager.AddToRole(user.Id, "admins"); }
        }
    }
 }

