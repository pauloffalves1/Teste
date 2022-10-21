using Contabilidade.Domain.Entities;
using Contabilidade.Domain.Interfaces;
using Contabilidade.Infra.Data.Contexto;
using System.Linq.Expressions;

namespace Contabilidade.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ContabilidadeContext _contabilidadeContext;

        public BaseRepository(ContabilidadeContext contabilidadeContext)
        {
            _contabilidadeContext = contabilidadeContext;
        }

        public void Insert(TEntity obj)
        {
            _contabilidadeContext.Set<TEntity>().Add(obj);
            _contabilidadeContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _contabilidadeContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contabilidadeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _contabilidadeContext.Set<TEntity>().Remove(Select(id));
            _contabilidadeContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _contabilidadeContext.Set<TEntity>().ToList();

        public TEntity? Select(int id) =>
            _contabilidadeContext.Set<TEntity>().Find(id);

    }
}
