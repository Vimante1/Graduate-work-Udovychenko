using System.ComponentModel.DataAnnotations;

namespace GraduateWorkUdovychenko.Domain.ViewModels
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "Логін обов'язковий")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        

        [Required(ErrorMessage = "Пароль обов'язковий")]
        [StringLength(6, ErrorMessage = "Пароль повинен містити мінімум 6 символів")]
        public string Password { get; set; }
    }
}
