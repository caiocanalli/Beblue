using Beblue.Application.Interfaces;
using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Service;

namespace Beblue.Application
{
    public class PrioridadeAppService : AppServiceBase<Prioridade>, IPrioridadeAppService
    {
        private readonly IPrioridadeService _service;

        public PrioridadeAppService(IPrioridadeService service): base(service)
        {
            _service = service;
        }
    }
}
