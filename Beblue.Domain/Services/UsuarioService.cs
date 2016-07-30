using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Repository;
using Beblue.Domain.Interfaces.Service;

namespace Beblue.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Usuario Authenticate(string email, string senha)
        {
            return _repository.Authenticate(email, senha);
        }

        public Usuario GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
    }
}
