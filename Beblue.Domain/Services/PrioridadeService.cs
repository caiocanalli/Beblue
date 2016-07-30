using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Repository;
using Beblue.Domain.Interfaces.Service;

namespace Beblue.Domain.Services
{
    public class PrioridadeService : ServiceBase<Prioridade>, IPrioridadeService
    {
        private readonly IPrioridadeRepository _repository;

        public PrioridadeService(IPrioridadeRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
