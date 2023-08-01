using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class UserDTO
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string DNI { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string IdRol { get; set; }

        //public string Password { get; set; }
    }
}