using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Repository;
using Beblue.Domain.Interfaces.Service;

namespace Beblue.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
