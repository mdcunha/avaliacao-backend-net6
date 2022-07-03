using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class DevRepository : IDevRepository
    {

        private readonly DataContext _context;

        public DevRepository(DataContext context )
        {
            _context = context;
        }

        public void Adicionar(Dev dev)
        {
            _context.Devs.Add(dev);
        }

        public void Alterar(Dev dev)
        {
            var devAlt = _context.Devs.FirstOrDefault(d=>d.Id == dev.Id);

            devAlt.Name = dev.Name;
            devAlt.Avatar = dev.Avatar;
            devAlt.Login = dev.Login;
            devAlt.Email = dev.Email;

        }

        public async Task<bool> Gravar()
        {
             return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<Dev> ObterPorId(int id)
        {
            return await _context.Devs.FirstOrDefaultAsync(d=>d.Id == id);
        }

        public async Task<IEnumerable<Dev>> ObterTodos()
        {
            return await _context.Devs.ToListAsync();
        }

        public void Remover(Dev dev)
        {
            _context.Devs.Remove(dev);
        }

        
    }
}