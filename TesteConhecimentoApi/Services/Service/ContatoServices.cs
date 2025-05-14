using TesteConhecimentoApi.DTOs;
using TesteConhecimentoApi.DTOs.Contato;
using TesteConhecimentoApi.Models;
using TesteConhecimentoApi.Repositories.Interfaces;
using TesteConhecimentoApi.Services.Interfaces;

namespace TesteConhecimentoApi.Services.Service
{
    public class ContatoServices : IContatoServices
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoServices(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<RetornoDto<IEnumerable<ContatoDto>>> BuscarListaContatos()
        {
            var contatos = await _contatoRepository.BuscarListaContatosAsync();
            var sucesso = contatos.Any();

            return new RetornoDto<IEnumerable<ContatoDto>>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados de contato encontrados com sucesso!" : "Nenhum dado de contato encontrado.",
                Data = sucesso ? contatos : null
            };
        }


        public async Task<RetornoDto<string>> AddContato(ContatoAdicionarAtualizarDto contato)
        {
            var newContato = new Contato
            {
                Nome = contato.Nome,
                Telefone = contato.Telefone
            };

            _contatoRepository.AddContato(newContato);
            var sucesso = await _contatoRepository.SaveChangesAsync();

            return new RetornoDto<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados de contato cadastrado com sucesso!" : "Erro ao cadastrar os dados de contato."
            };
        }

        public async Task<RetornoDto<string>> UpdateContato(int id, ContatoAdicionarAtualizarDto contato)
        {
            var contatoBanco = await _contatoRepository.BuscarContatoPorId(id);
            if (contatoBanco == null)
            {
                return new RetornoDto<string>
                {
                    Status = false,
                    Msg = "Erro: Não foi encontrado nenhum registro com esse Id!"
                };
            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;

            _contatoRepository.UpdateContato(contatoBanco);
            var sucesso = await _contatoRepository.SaveChangesAsync();

            return new RetornoDto<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados de contato atualizado com sucesso!" : "Erro ao atualizar os dados de contato."
            };
        }

        public async Task<RetornoDto<string>> RemoveContato(int id)
        {
            var contatoBanco = await _contatoRepository.BuscarContatoPorId(id);
            if (contatoBanco == null)
            {
                return new RetornoDto<string>
                {
                    Status = false,
                    Msg = "Erro: Não foi encontrado nenhum registro com esse Id!"
                };
            }

            _contatoRepository.RemoveContato(contatoBanco);
            var sucesso = await _contatoRepository.SaveChangesAsync();

            return new RetornoDto<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados de contato deletado com sucesso!" : "Erro ao deletar os dados de contato."
            };
        }
    }
}
