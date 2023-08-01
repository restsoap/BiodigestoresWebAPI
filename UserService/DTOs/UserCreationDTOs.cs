using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class UserCreationDTOs
    {
        public string _name;
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo Nombre debe tener menos de {1} carácteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras")]
        public string Name
        {
            get => _name;
            set => _name = value?.ToUpper();
        }


        public string _surname;
        [Required(ErrorMessage = "El campo Apellido es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo Apellido debe tener menos de {1} carácteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras")]
        public string Surname
        {
            get => _surname;
            set => _surname = value?.ToUpper();
        }

        [Required(ErrorMessage = "El campo Email es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo cedula es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo cedula debe contener solo dígitos.")]
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