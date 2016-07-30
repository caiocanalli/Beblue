using Beblue.Domain.Entities;

namespace Beblue.Domain.Interfaces.Service
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario Authenticate(string email, string senha);
        Usuario GetByEmail(string email);
    }
}
