using Nortwind.DAL.Repositories;
using Nortwind.DAL.Repositories.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business
{
    public class BaseBusiness<TEntity> where TEntity : class
    {
        BaseRepository<TEntity> repo = new BaseRepository<TEntity>();

        public void Ekle(TEntity nesne)
        {
            repo.Ekle(nesne);
        }

        public void Sil(TEntity nesne)
        {
            repo.Sil(nesne);
        }
        public void Guncelle(TEntity nesne)
        {
            repo.Guncelle(nesne);
        }
        public TEntity IdyeGoreGetir(int id)
        {
            return repo.IdyeGoreGetir(id);
        }

        public List<TEntity> HepsiniGetir()
        {
            return repo.HepsiniGetir();

        }
    }
}
