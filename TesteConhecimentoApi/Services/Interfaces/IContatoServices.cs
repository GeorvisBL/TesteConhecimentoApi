using TesteConhecimentoApi.DTOs;
using TesteConhecimentoApi.DTOs.Contato;

namespace TesteConhecimentoApi.Services.Interfaces
{
    public interface IContatoServices
    {
        Task<RetornoDto<IEnumerable<ContatoDto>>> BuscarListaContatos();

        Task<RetornoDto<string>> AddContato(ContatoAdicionarAtualizarDto contato);
        Task<RetornoDto<string>> UpdateContato(int id, ContatoAdicionarAtualizarDto contato);
        Task<RetornoDto<string>> RemoveContato(int id);
    }
}