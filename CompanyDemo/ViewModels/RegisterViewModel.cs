using System.ComponentModel.DataAnnotations;

namespace CompanyDemo.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Compare password")]
        public string PasswordConfirm { get; set; }
    }
}
