using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetinho
{
    public class Usuario
    {
        public UInt64 Id { get; set; }
        [Required]
        [MaxLength(200)]
        public String Nome { get; set; }
        public Credencial Credencial { get; set; }
        
    }
}
