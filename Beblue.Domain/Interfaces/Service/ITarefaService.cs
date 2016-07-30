using Beblue.Domain.Entities;
using System.Collections.Generic;

namespace Beblue.Domain.Interfaces.Service
{
    public interface ITarefaService : IServiceBase<Tarefa>
    {
        IEnumerable<Tarefa> GetByIdUsuario(int idUsuario);
    }
}
