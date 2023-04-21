using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
