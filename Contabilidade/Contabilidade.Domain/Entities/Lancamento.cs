namespace Contabilidade.Domain.Entities
{
    public class Lancamento : BaseEntity
    {
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public int TipoLancamento { get; set; }

        public DateTime MomentoLancamento { get; set; }
    }
}
