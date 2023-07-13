using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Compare("Password", ErrorMessage = "A senha não corresponde")]
        public string ConfirmPassword { get; set; }
    }
}
