using System.Collections.Generic;
using Api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IDevRepository
    {
        Task<IEnumerable<Dev>> ObterTodos();
        Task<Dev> ObterPorId(int id);
        void Adicionar(Dev dev);
        void Alterar(Dev dev);
        void Remover(Dev dev);
        Task<bool> Gravar();
    }
}