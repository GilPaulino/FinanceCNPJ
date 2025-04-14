using FinanceCNPJ.API.Base;
using FinanceCNPJ.Aplicacao.Conta.Consultas.Extrato;
using FinanceCNPJ.Aplicacao.Conta.Consultas.Saldo;
using FinanceCNPJ.Aplicacao.Transacao.Comandos.Deposito;
using FinanceCNPJ.Aplicacao.Transacao.Comandos.Saque;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCNPJ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : BaseController
    {
        public TransacaoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("deposito")]
        public async Task<IActionResult> Depositar([FromBody] DepositoComando comando)
        {
            await Mediator.Send(comando);
            return Ok(new { mensagem = "Depósito realizado com sucesso." });
        }

        [HttpPost("saque")]
        public async Task<IActionResult> Sacar([FromBody] SaqueComando comando)
        {
            try
            {
                await Mediator.Send(comando);
                return Ok(new { mensagem = "Saque realizado com sucesso." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }


        [HttpGet("extrato/{contaId}")]
        public async Task<IActionResult> ObterExtrato(long contaId)
        {
            var consulta = new ExtratoContaConsulta { ContaId = contaId };
            var extrato = await Mediator.Send(consulta);
            return Ok(extrato);
        }
    }
}
