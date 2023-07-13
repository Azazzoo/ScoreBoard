using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class DBJoueurRepository : IJoueurRepository
    {
        private readonly CatalogueDbContext _catalogueDbContext;
        public IEnumerable<Joueur> _MesJoueurs { get { return _catalogueDbContext.Joueurs.Include(i => i.Jeux).OrderBy(g => g.Nom).ToList(); } }

        public DBJoueurRepository(CatalogueDbContext catalogueDbContext)
        {
            _catalogueDbContext = catalogueDbContext;
        }

        public Joueur? GetJoueur(int id)
        {
            Joueur joueur = _catalogueDbContext.Joueurs.Include(j => j.Jeux).FirstOrDefault(g => g.Id == id);
            return joueur;
        }

        public void Modifier(Joueur joueur)
        {
            _catalogueDbContext.Joueurs.Update(joueur);
            _catalogueDbContext.SaveChanges();
        }

        public void Supprimer(int id)
        {
            _catalogueDbContext.Joueurs.Remove(GetJoueur(id));
            _catalogueDbContext.SaveChanges();
        }

        public void AddJoueur(Joueur joueur)
        {
            _catalogueDbContext.Add(joueur);
            _catalogueDbContext.SaveChanges();
        }
    }
}
