using FinanceCNPJ.API.Base;
using FinanceCNPJ.Aplicacao.Conta.Comandos.Criar;
using FinanceCNPJ.Aplicacao.Conta.Comandos.Editar;
using FinanceCNPJ.Aplicacao.Conta.Comandos.Excluir;
using FinanceCNPJ.Aplicacao.Conta.Consultas;
using FinanceCNPJ.Aplicacao.Conta.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCNPJ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : BaseController
    {
        public ContaController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> CriarConta([FromBody] CriarContaComando comando)
        {
            var resultado = await Mediator.Send(comando);
            return Ok(resultado);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> EditarConta([FromBody] EditarContaComando comando)
        {
            var conta = await Mediator.Send(comando);
            return Ok(conta);
        }


        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> ExcluirConta(long id)
        {
            await Mediator.Send(new ExcluirContaComando(id));
            return Ok(new { mensagem = "Registro excluído com sucesso!" });
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> BuscarConta([FromQuery] BuscarContaFiltroViewModel filtro)
        {
            var consulta = new BuscarContaConsulta { Filtro = filtro };
            var resultado = await Mediator.Send(consulta);
            return Ok(resultado);
        }

    }
}
