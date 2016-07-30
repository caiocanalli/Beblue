using Beblue.Domain.Entities;
using System.Collections.Generic;

namespace Beblue.Domain.Interfaces.Repository
{
    public interface ITarefaRepository : IRepositoryBase<Tarefa>
    {
        IEnumerable<Tarefa> GetByIdUsuario(int idUsuario);
    }
}
