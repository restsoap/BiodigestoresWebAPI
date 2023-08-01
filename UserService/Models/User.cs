using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserService.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo Nombre debe tener menos de {1} caracteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo Apellido debe tener menos de {1} caracteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido")]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "El Email no es valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo cédula es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo cédula debe contener solo dígitos.")]
        public string DNI { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public string IdRol { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
                           ErrorMessage = "La contraseña debe tener al menos 8 caracteres y contener al menos una letra, un dígito y un carácter especial.")]
        public string Password { get; set; }
    }
}

