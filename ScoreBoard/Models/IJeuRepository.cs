namespace ScoreBoard.Models
{
    public interface IJeuRepository
    {
        public IEnumerable<Jeu> _MesJeux { get; set; }
        public Jeu? GetJeu(int id);
        public void Modifier(Jeu jeu);
        public void Supprimer(int id);
    }
}
