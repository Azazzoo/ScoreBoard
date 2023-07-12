using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class DBJeuRepository : IJeuRepository
    {
        private readonly CatalogueDbContext _catalogueDbContext;
        public IEnumerable<Jeu> _MesJeux { get { return _catalogueDbContext.Jeux.Include(j => j.Nom).OrderBy(g => g.Nom).ToList(); } }

        public DBJeuRepository(CatalogueDbContext catalogueDbContext)
        {
            _catalogueDbContext = catalogueDbContext;
        }
        public Jeu? GetJeu(int id)
        {
            Jeu jeu = _catalogueDbContext.Jeux.Include(j =>j.Id).FirstOrDefault(g => g.Id == id);
            return jeu;
        }

        public void Modifier(Jeu jeu)
        {
            _catalogueDbContext.Jeux.Update(jeu);
            _catalogueDbContext.SaveChanges();
        }

        public void Supprimer(int id)
        {
            _catalogueDbContext.Jeux.Remove(GetJeu(id));
            _catalogueDbContext.SaveChanges();
        }
    }
}
