using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JoueurController : Controller
    {
        private IJeuRepository MesJeux;
        private IJoueurRepository MesJoueurs;
        public JoueurController(IJeuRepository repositoryJeu, IJoueurRepository repositoryJoueur)
        {
            MesJeux = repositoryJeu;
            MesJoueurs = repositoryJoueur;
        }
        public IActionResult Index()
        {
            return View("Index", MesJoueurs._MesJoueurs);
        }

        public IActionResult Modifier(int id)
        {
            Joueur joueur = MesJoueurs.GetJoueur(id);
            return View("ModifierJoueur",joueur);
        }

        public IActionResult ModifierUnJoueur(Joueur joueur)
        {
            MesJoueurs.Modifier(joueur);
            return View("Index", MesJoueurs._MesJoueurs);
        }

        public IActionResult AfficherJoueur(int id)
        {
            Joueur joueur = MesJoueurs.GetJoueur(id);
            return View("InfoJoueur", joueur);
        }

        public IActionResult Supprimer(int id)
        {
            MesJoueurs.Supprimer(id);
            return View("Index", MesJoueurs._MesJoueurs);
        }

        public IActionResult AjouterJoueur()
        {
            return View("AjouterJoueur");
        }

        public IActionResult AjouterUnJoueur(Joueur joueur)
        {
            var identifiant = joueur.Prenom + joueur.Nom;
            joueur.Courriel = identifiant.ToLower();
            MesJoueurs.AddJoueur(joueur);
            return View("Index", MesJoueurs._MesJoueurs);
        }
    }
}
