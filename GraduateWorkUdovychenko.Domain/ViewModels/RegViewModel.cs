using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

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
