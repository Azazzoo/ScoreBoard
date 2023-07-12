using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class CatalogueDbContext : DbContext
    {
        public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options) : base(options)
        {

        }
        public DbSet<Joueur> Joueurs { get; set; }  
        public DbSet<Jeu> Jeux { get; set; }
    }

}
