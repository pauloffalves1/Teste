using Contabilidade.API.Models;
using Contabilidade.Domain.Entities;
using Contabilidade.Domain.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Contabilidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolidacaoDiariaController : ControllerBase
    {
        private IBaseService<Lancamento> _baseLancamentoService;

        public ConsolidacaoDiariaController(IBaseService<Lancamento> baseLancamentoService)
        {
            _baseLancamentoService = baseLancamentoService;
        }

        [HttpGet]
        [Route("ConsolidacaoPorData")]
        public IActionResult SelectConsolidacaoPorDia([FromBody] ConsolidacaoDiariaModel consolidacao)
        {
            if (consolidacao == null)
                return NotFound();

            return Execute(
                        () => _baseLancamentoService.Get<Lancamento>()
                        .Where(x => x.MomentoLancamento.Date.Equals(Convert.ToDateTime(consolidacao.momentolancamento).Date))
                        .GroupBy(z => z.MomentoLancamento.Date)
                        .Select(ret => new
                            {
                                dia = ret.Key.Date.ToString("dd/MM/yyyy"),
                                valortotal = ret.Sum(p => p.Valor)
                            }
                        )
                    );
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
