using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Repository;
using System.Linq;

namespace Beblue.Infrastructure.Repository.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario Authenticate(string email, string senha)
        {
            return db.Usuarios.Where(x => x.Email == email).Where(x => x.Senha == senha).FirstOrDefault();
        }

        public Usuario GetByEmail(string email)
        {
            return db.Usuarios.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
