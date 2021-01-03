using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DAL.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetByIdString(string id);
        void RemoveString(string id);
        void Add(TEntity entity);
        void Remove(int id);
        TEntity GetById(int id);
        List<TEntity> GetAll();

        //List<TEntity> FilterByCity(Expression<Func<TEntity, bool>> pred);

        //  List<TEntity> GetByCity(string city);

        // void Update(TEntity nesne);
        // void Delete(TEntity nesne);
    }
}
