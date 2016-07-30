using Beblue.Domain.Utils;

namespace Beblue.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string CriptografarSenha(string senha)
        {
            return MD5.HashMD5(senha);
        }
    }
}
