using Beblue.Application.Interfaces;
using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Service;

namespace Beblue.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _service;

        public UsuarioAppService(IUsuarioService service) : base(service)
        {
            _service = service;
        }

        public Usuario Authenticate(string email, string senha)
        {
            return _service.Authenticate(email, senha);
        }

        public Usuario GetByEmail(string email)
        {
            return _service.GetByEmail(email);
        }
    }
}
