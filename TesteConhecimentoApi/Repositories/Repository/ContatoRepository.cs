using Microsoft.EntityFrameworkCore;
using TesteConhecimentoApi.Context;
using TesteConhecimentoApi.DTOs.Contato;
using TesteConhecimentoApi.Models;
using TesteConhecimentoApi.Repositories.Interfaces;

namespace TesteConhecimentoApi.Repositories.Repository
{
    public class ContatoRepository : IContatoRepository
    {

        private readonly DBContext _context;
        public ContatoRepository(DBContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<ContatoDto>> BuscarListaContatosAsync()
        {
            var retorno = await _context.Contatos
                .Select(c => new ContatoDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Telefone = c.Telefone
                })
                .ToListAsync();

            return retorno;
        }

        public async Task<Contato> BuscarContatoPorId(int id)
        {
            var retorno = await _context.Contatos
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            return retorno;
        }


        public void AddContato(Contato contato)
        {
            _context.Contatos.Add(contato);
        }

        public void UpdateContato(Contato contato)
        {
            _context.Contatos.Update(contato);
        }

        public void RemoveContato(Contato contato)
        {
            _context.Contatos.Remove(contato);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}
