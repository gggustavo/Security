using System.ComponentModel.DataAnnotations;

namespace MSA.Models
{

    public class ManageUserViewModel
    {
        [Required(ErrorMessage = "Ingrese una Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password actual")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Ingrese una Password")]
        [StringLength(100, ErrorMessage = "El {0} debe ser al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nueva Password")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la confirmación de contraseña no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage="Ingrese un usuario")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Ingrese una password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Recordarme?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ingrese un usuario")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese una Password")]
        [StringLength(100, ErrorMessage = "El {0} debe ser al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación de contraseña no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
