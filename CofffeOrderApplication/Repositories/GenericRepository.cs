using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CofffeOrderApplication.Abstract;
using CofffeOrderApplication.Concerete;

namespace CofffeOrderApplication.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        //Yapıcı metod ctor constructior method
        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public List<T> List()
        {
            return _object.ToList();
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;

            //Diğer bir ekleme metodu!
            //_object.Add(p);
            c.SaveChanges();
        }

        /// <summary>
        /// Entity state kullanımı
        /// todo entity state nedir?
        /// </summary>
        /// <param name="p"></param>
        public void Update(T p)
        {
            var updateEntity = c.Entry(p);
            updateEntity.State = EntityState.Modified;
            c.SaveChanges();
        }

        public void Delete(T p)
        {
            var deleteEntity = c.Entry(p);
            deleteEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        /// <summary>
        /// ID bulmak için kullanıyoruz.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> filter)
        {
            //Single or default bir değer döndürmesi için kullanılan linq methodu
            return _object.SingleOrDefault(filter);
        }

        /// <summary>
        /// Func ile filtreli veri dönüyoruz.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}