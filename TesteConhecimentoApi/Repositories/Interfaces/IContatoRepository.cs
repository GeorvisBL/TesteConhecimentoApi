using TesteConhecimentoApi.DTOs.Contato;
using TesteConhecimentoApi.Models;

namespace TesteConhecimentoApi.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        public Task<IEnumerable<ContatoDto>> BuscarListaContatosAsync();
        public Task<Contato> BuscarContatoPorId(int id);

        public void AddContato(Contato contato);
        public void UpdateContato(Contato contato);
        public void RemoveContato(Contato contato);
        public Task<bool> SaveChangesAsync();
    }
}
