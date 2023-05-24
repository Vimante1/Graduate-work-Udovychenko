using GraduateWorkUdovychenko.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GraduateWorkUdovychenko.Domain.Models
{
    public class User
    {
        [BsonId]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

    }
}
