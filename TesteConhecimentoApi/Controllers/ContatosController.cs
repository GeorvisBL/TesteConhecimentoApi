using Microsoft.AspNetCore.Mvc;
using TesteConhecimentoApi.DTOs.Contato;
using TesteConhecimentoApi.Services.Interfaces;

namespace TesteConhecimentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {

        private readonly IContatoServices _contatoServices;
        public ContatosController(IContatoServices contatoServices)
        {
            _contatoServices = contatoServices;
        }


        [HttpGet("BuscarContatos")]
        public async Task<IActionResult> BuscarContatos()
        {
            var retornoContatos = await _contatoServices.BuscarListaContatos();

            if (retornoContatos.Status)
                return Ok(retornoContatos);
            else
                return NotFound(retornoContatos);
        }



        [HttpPost("ContatoAdicionar")]
        public async Task<IActionResult> ContatoAdicionar([FromBody] ContatoAdicionarAtualizarDto contato)
        {
            if (contato == null) return BadRequest("Dados inválidos!");

            var retornoAdd = await _contatoServices.AddContato(contato);

            if (retornoAdd.Status)
                return Ok(retornoAdd);
            else
                return BadRequest(retornoAdd);
        }


        [HttpPut("ContatoAtualizar/{idContato}")]
        public async Task<IActionResult> ContatoAtualizar(int idContato, [FromBody] ContatoAdicionarAtualizarDto contato)
        {
            if (idContato <= 0 || contato == null) return BadRequest("Objeto inválido!");

            var retornoUpdate = await _contatoServices.UpdateContato(idContato, contato);

            if (retornoUpdate.Status)
                return Ok(retornoUpdate);
            else
                return NotFound(retornoUpdate);
        }


        [HttpDelete("ContatoEliminar/{idContato}")]
        public async Task<IActionResult> ContatoEliminar(int idContato)
        {
            if (idContato <= 0) return BadRequest("Código inválido!");

            var retornoRemove = await _contatoServices.RemoveContato(idContato);

            if (retornoRemove.Status)
                return Ok(retornoRemove);
            else
                return NotFound(retornoRemove);
        }


    }
}
