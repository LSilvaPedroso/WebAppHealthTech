using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppHealthTech.Models
{
    public class LoginModel
    {
        public string Email { get; set; }

        public string Senha { get; set; }

    }
}
