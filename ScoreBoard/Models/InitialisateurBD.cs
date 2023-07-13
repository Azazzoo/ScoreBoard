namespace ScoreBoard.Models
{
    public class InitialisateurBD
    {
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
                Nom = "Auger1",
                Prenom = "Yoshi",
                Equipe = "Les Pogo",
                Telephone = "888-888-8888",
                Courriel = "YoshiAuger@scoreboard.ca",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom = "Auger2",
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
                Nom = "Shield1",
                Prenom = "Loki",
                Equipe = "Les Chips",
                Telephone = "888-888-8888",
                Courriel = "LokiShield@scoreboard.ca",
                Jeux = new List<Jeu>()
            },
            new Joueur
            {
                Nom = "Shield2",
                Prenom = "Maze",
                Equipe = "Les Chips",
                Telephone = "888-888-8888",
                Courriel = "MazeShield@scoreboard.ca",
                Jeux = new List<Jeu>()
            }
        };

        private static Dictionary<string, Joueur> _NomJoueurDict;
        public static Dictionary<string, Joueur> NomJoueurDict
        {
            get
            {
                _NomJoueurDict = new Dictionary<string, Joueur>();
                foreach (Joueur joueur in _listjoueur)
                {
                    _NomJoueurDict.Add(joueur.Nom, joueur);
                }

                return _NomJoueurDict;
            }
        }

        public static List<Jeu> _listjeux = new List<Jeu>
        {

            new Jeu
            {
                Nom = "Tetris",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                Joueur = NomJoueurDict["Auger"],
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            },
            new Jeu
            {
                Nom = "Mario Bros",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                Joueur = NomJoueurDict["Auger"],
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            },
            new Jeu
            {
                Nom = "Serpent et echelle",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                Joueur = NomJoueurDict["Auger"],
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            },
            new Jeu
            {
                Nom = "Monopoly",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                Joueur = NomJoueurDict["Auger"],
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            },
            new Jeu
            {
                Nom = "Pac Man",
                DateSortie = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet. Non alias quia sed fugiat consequatur in doloremque animi eos ipsa provident qui dolorem vero At nesciunt illo.",
                Joueur = NomJoueurDict["Auger"],
                ScoreJoueur = 0,
                DateEnregistrement = DateTime.Now,
            }
        };

        

        

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // On ne peut pas utiliser l'injection de dépendances ici, 
            // le DbContext CatalogueGateauxDbContext sera donc récupéré à partir de applicationBuilder.
            CatalogueDbContext catalogueDbContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CatalogueDbContext>();

           

            if (!catalogueDbContext.Joueurs.Any())
            {
                catalogueDbContext.Joueurs.AddRange(NomJoueurDict.Values);
                catalogueDbContext.SaveChanges();
            }

            if (!catalogueDbContext.Jeux.Any())
            {
                catalogueDbContext.Jeux.AddRange(_listjeux);
                catalogueDbContext.SaveChanges();
            }
        }
    }

}

