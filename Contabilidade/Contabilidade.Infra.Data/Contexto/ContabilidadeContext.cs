using Contabilidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contabilidade.Infra.Data.Contexto
{
    public class ContabilidadeContext : DbContext
    {
        public ContabilidadeContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Lancamento> Lancamentos { get; set; }


    }
}
