using Beblue.Application.Interfaces;
using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace Beblue.Application
{
    public class TarefaAppService : AppServiceBase<Tarefa>, ITarefaAppService
    {
        private readonly ITarefaService _service;

        public TarefaAppService(ITarefaService service) : base(service)
        {
            _service = service;
        }

        public IEnumerable<Tarefa> GetByIdUsuario(int idUsuario)
        {
            return _service.GetByIdUsuario(idUsuario);
        }
    }
}
