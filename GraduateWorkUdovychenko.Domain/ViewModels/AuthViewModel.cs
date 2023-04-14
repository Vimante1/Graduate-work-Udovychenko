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
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Підтвердіть пароль")]
        [MinLength(2 , ErrorMessage ="Error")]
        public string Password { get; set; }
    }
}
