using Microsoft.EntityFrameworkCore;
using Zara_GestionDVD.Models;

namespace Zara_GestionDVD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DVD> DVDs { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Historique> Historiques { get; set; }
    }
}