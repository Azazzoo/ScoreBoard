using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Joueur
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [RegularExpression("^.{2,20}$", ErrorMessage = "Le nom doit comporter entre 2 et 20 caracteres")]
        public string Nom { get; set; }
        [RegularExpression("^.{2,20}$", ErrorMessage = "Le prénom doit comporter entre 2 et 20 caracteres")]
        [Required]
        public string Prenom { get; set; }
        [RegularExpression("^[A-Z]{2,4}$", ErrorMessage = "L'équipe doit avoir 2 à 4 lettres majuscules.")]
        public string? Equipe { get; set; }

        public string? Telephone { get; set; }
        [Required]
        [Display(Name = "Identifiant")]
        public string Courriel { get; set; }
        [Required]
        public List<Jeu>? Jeux { get; set; }
    }
}
