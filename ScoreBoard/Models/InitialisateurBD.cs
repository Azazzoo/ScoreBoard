namespace ScoreBoard.Models
{
    public class InitialisateurBD
    {
        public static List<Jeu> _listjeux = new List<Jeu>
        {
            new Jeu
            {
                Nom = "Tetris",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                JoueurId = 1,
                Joueur = new Joueur(),
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            },
            new Jeu
            {
                Nom = "Mario Bros",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                JoueurId = 2,
                Joueur = new Joueur(),
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            },
            new Jeu
            {
                Nom = "Serpent et echelle",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                JoueurId = 3,
                Joueur = new Joueur(),
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            },
            new Jeu
            {
                Nom = "Monopoly",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                JoueurId = 1,
                Joueur = new Joueur(),
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            },
            new Jeu
            {
                Nom = "Pac Man",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                JoueurId = 2,
                Joueur = new Joueur(),
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            }
        };

        private static Dictionary<string, Jeu> _NomJeuDict;
        public static Dictionary<string, Jeu> NomJeuDict
        {
            get
            {
                _NomJeuDict = new Dictionary<string, Jeu>();
                foreach (Jeu jeu in _listjeux)
                {
                    _NomJeuDict.Add(jeu.Nom, jeu);
                }

                return _NomJeuDict;
            }
        }

        public static List<Joueur> _listjoueur = new List<Joueur> 
        { 
            new Joueur
            {
                Nom = "Auger",
                Prenom = "Marco",
                Equipe = "Les Pogo",
                Telephone = "888-888-8888",
                Courriel = "MarcoAuger@scoreboard.ca",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom = "Auger",
                Prenom = "Yoshi",
                Equipe = "Les Pogo",
                Telephone = "888-888-8888",
                Courriel = "YoshiAuger@scoreboard.ca",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom = "Auger",
                Prenom = "BooBoo",
                Equipe = "Les Pogo",
                Telephone = "888-888-8888",
                Courriel = "BooBooAuger@scoreboard.ca",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom = "Shield",
                Prenom = "Karo",
                Equipe = "Les Chips",
                Telephone = "888-888-8888",
                Courriel = "KaroShield@scoreboard.ca",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom = "Shield",
                Prenom = "Loki",
                Equipe = "Les Chips",
                Telephone = "888-888-8888",
                Courriel = "LokiShield@scoreboard.ca",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom = "Shield",
                Prenom = "Maze",
                Equipe = "Les Chips",
                Telephone = "888-888-8888",
                Courriel = "MazeShield@scoreboard.ca",
                Jeux = new List<Jeu>()
            }
        };

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // On ne peut pas utiliser l'injection de dépendances ici, 
            // le DbContext CatalogueGateauxDbContext sera donc récupéré à partir de applicationBuilder.
            CatalogueDbContext catalogueDbContext =
                    applicationBuilder.ApplicationServices.CreateScope()
                    .ServiceProvider.GetRequiredService<CatalogueDbContext>();

            if (!catalogueDbContext.Jeux.Any())
            {
                catalogueDbContext.Jeux.AddRange(NomJeuDict.Values);
            }

            catalogueDbContext.SaveChanges();

            if (!catalogueDbContext.Joueurs.Any())
            {
                catalogueDbContext.Joueurs.AddRange(_listjoueur);
            }

            catalogueDbContext.SaveChanges();
        }
    }

}
}
