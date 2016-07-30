using Beblue.Domain.Entities;

namespace Beblue.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario Authenticate(string email, string senha);
        Usuario GetByEmail(string email);
    }
}
