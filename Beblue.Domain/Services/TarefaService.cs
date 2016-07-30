using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Repository;
using Beblue.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace Beblue.Domain.Services
{
    public class TarefaService : ServiceBase<Tarefa>, ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Tarefa> GetByIdUsuario(int idUsuario)
        {
            return _repository.GetByIdUsuario(idUsuario);
        }
    }
}
