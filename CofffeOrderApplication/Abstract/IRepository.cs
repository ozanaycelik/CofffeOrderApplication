using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CofffeOrderApplication.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        void Insert(T p);
        void Update(T p);
        void Delete(T p);

        /// <summary>
        /// GetbyID
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> filter);


        /// <summary>
        /// Şartlı listeleme
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<T> List(Expression<Func<T, bool>> filter);
    }
}