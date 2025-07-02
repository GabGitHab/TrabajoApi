using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace TrabajoApi.Modelos
{
    public class Usuario
    {
        private string clave;

        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public ICollection<Artista> Artistas { get; set; } = new List<Artista>();
       

        public Usuario() { }
        public Usuario(string nombreUsuario, string passwordSinEncriptar)
        {
            NombreUsuario = nombreUsuario;
            SetearPasswordEncriptado(passwordSinEncriptar);
        }

        private void SetearPasswordEncriptado(string password)
        {
            PasswordHash = EncriptarPassword(password);
        }
        public static string EncriptarPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                // Convertir a cadena hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2")); // X2 para hex en mayúsculas
                }
                return sb.ToString();
            }
        }

    }
}
    

