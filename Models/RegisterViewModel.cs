using System.ComponentModel.DataAnnotations;

namespace Zara_GestionDVD.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Courriel { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("MotDePasse", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Prenom { get; set; }
    }
}