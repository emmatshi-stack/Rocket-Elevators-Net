using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace rocket_elevator_ui.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<buildingapi.Model.Interventions> Interventions { get; set; }

        public System.Data.Entity.DbSet<buildingapi.Model.Batteries> Batteries { get; set; }

        public System.Data.Entity.DbSet<buildingapi.Model.Buildings> Buildings { get; set; }

        public System.Data.Entity.DbSet<buildingapi.Model.Columns> Columns { get; set; }

        public System.Data.Entity.DbSet<buildingapi.Model.Customers> Customers { get; set; }

        public System.Data.Entity.DbSet<buildingapi.Model.Elevators> Elevators { get; set; }
    }
}