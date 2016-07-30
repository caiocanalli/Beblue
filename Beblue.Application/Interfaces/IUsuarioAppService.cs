using Beblue.Domain.Entities;

namespace Beblue.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario Authenticate(string email, string senha);
        Usuario GetByEmail(string email);
    }
}
