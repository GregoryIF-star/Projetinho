using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projetinho
{
    [Index(nameof(Email),IsUnique = true)]
    public class Credencial
    {
        private const String Salt = "1FnM6_";
        public UInt64 Id { get; set; }

        private string _senha;
        [Required]
        [MaxLength(64)]
        public String Senha
        {
            get
            {
                return _senha;
            }
            set
            {
                _senha = ComputeSHA256(value);
            }
        }

        public static String ComputeSHA256(String Input)
        {
            return ComputeSHA256(Input, Salt);
        }

        [Required]
        public String Email { get; set; }

        public Boolean Administrador { get; set; }

        public UInt64 UsuarioId { get; set; }
        [Required]
        public Usuario Usuario { get; set; }

        #region HASHING
        public static String ComputeSHA256(String input, String salt)
        {
            string hash = String.Empty;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(
                   Encoding.UTF8.GetBytes(salt + input));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
                return hash;
            }
        }
        #endregion

        public override string ToString()
        {
            return $"Email:{Email} Senha:{Senha}\nADM:{(Administrador ? "Ativo" : "Inativo")}";
        }
    }
}
