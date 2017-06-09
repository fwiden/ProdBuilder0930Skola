using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProdBuilder0920.Domain;

namespace ProdBuilder0920.DataService
{
    public class AppContext : IdentityDbContext<AppUser>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageSeries> PackageSeries { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartType> PartTypes { get; set; }

        // Your context has been configured to use a 'AppContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProdBuilder0920.web.Models.AppContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AppContext' 
        // connection string in the application configuration file.
        public AppContext()
            : base("name=AppContext")
        {
        }

        public System.Data.Entity.DbSet<ProdBuilder0920.Domain.ViewModels.ApViewModel> ApViewModels { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}