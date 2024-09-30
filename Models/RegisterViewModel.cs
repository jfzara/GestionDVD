using System.ComponentModel.DataAnnotations;

namespace Zara_GestionDVD.ViewModels  
{
    public class RegisterViewModel
    {
        [Required]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string Courriel { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}