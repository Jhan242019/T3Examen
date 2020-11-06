using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
