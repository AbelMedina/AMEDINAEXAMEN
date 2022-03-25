using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        [Required(ErrorMessage="Ingrese su username")]
        public string Username { get; set; }
        [Required(ErrorMessage="Ingrese su password")]
        public string Password { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
