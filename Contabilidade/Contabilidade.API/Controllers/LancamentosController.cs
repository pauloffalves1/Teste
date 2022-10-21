using Contabilidade.API.Models;
using Contabilidade.Domain.Entities;
using Contabilidade.Domain.Interfaces;
using Contabilidade.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private IBaseService<Lancamento> _baseLancamentoService;

        public LancamentosController(IBaseService<Lancamento> baseLancamentoService)
        {
            _baseLancamentoService = baseLancamentoService;
        }

        [HttpPost]
        [Route("NovoLancamento")]
        public IActionResult Create([FromBody] CreateLancamentoModel lancamento)
        {
            if (lancamento == null)
                return NotFound();

            lancamento.valor = VerificarValorPorTipoDoLancamento(lancamento);
            //lancamento.momentolancamento = DateTime.Now;

            return Execute(() => _baseLancamentoService.Add<CreateLancamentoModel, LancamentoModel, LancamentoValidator>(lancamento));
        }

        private static decimal VerificarValorPorTipoDoLancamento(CreateLancamentoModel lancamento)
        {
            if (lancamento.tipolancamento == 0 && lancamento.valor > 0)
                lancamento.valor = lancamento.valor * (-1);
            else if (lancamento.tipolancamento == 1 && lancamento.valor < 0)
                lancamento.valor = lancamento.valor * (-1);
            return lancamento.valor;
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
