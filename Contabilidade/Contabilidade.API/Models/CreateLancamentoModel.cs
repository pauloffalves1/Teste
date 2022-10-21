using System;

namespace Contabilidade.API.Models
{
    public class CreateLancamentoModel
    {
        public string descricao { get; set; }

        public decimal valor { get; set; }

        public int tipolancamento { get; set; }

        public string momentolancamento { get; set; }
    }
}
