using Nortwind.DAL.Context;
using Nortwind.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DAL.Repositories.Concrate
{
   // public class BaseRepository<TEntity> where TEntity : class
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        //DataBaseContext context = new DataBaseContext();
        protected DataBaseContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity nesne)
        {
            _dbSet.Add(nesne);
            //context.Set<TEntity>().Add(nesne);
            //context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
           // return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
            //return context.Set<TEntity>().ToList();

        }

        public void Remove(int id)
        {
           _dbSet.Remove(GetById(id));
        }

        public TEntity GetByIdString(string id)
        {
            return _dbSet.Find(id);
        }

        public void RemoveString(string id)
        {
            _dbSet.Remove(GetByIdString(id));
        }

        //public List<TEntity> FilterByCity(Expression<Func<TEntity, bool>> pred)
        //{
        //    return _context.Set<TEntity>().Where(pred).ToList();
        //}

       

        //public List<TEntity> GetByCity(string city)
        //{
        //    return _dbSet.ToList();
        //    //return _dbSet.Find(city);
        //    //_dbSet.Where(customer => customer.Name == Name).ToList();
        //}



    }
}
