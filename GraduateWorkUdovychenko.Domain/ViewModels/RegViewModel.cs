using GraduateWorkUdovychenko.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkUdovychenko.Domain.ViewModels
{
    public class RegViewModel
    {
        [BsonId]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Підтвердіть пароль")]
        [Compare("Password",ErrorMessage ="Паролі не збігаються")]
        public string ConfirmPassword { get; set; }
    
    
    
    
    }



}
