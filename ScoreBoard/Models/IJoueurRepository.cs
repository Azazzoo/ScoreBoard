namespace ScoreBoard.Models
{
    public interface IJoueurRepository  
    {
        public IEnumerable<Joueur> _MesJoueurs { get; set; }
        public Joueur? GetJoueur(int id);
        public void Modifier(Joueur joueur);
        public void Supprimer(int id);
    }
}
