using Beblue.Application.Interfaces;
using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Service;

namespace Beblue.Application
{
    public class CategoriaAppService : AppServiceBase<Categoria>, ICategoriaAppService
    {
        private readonly ICategoriaService _service;

        public CategoriaAppService(ICategoriaService service) : base(service)
        {
            _service = service;
        }
    }
}
