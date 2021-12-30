using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CofffeOrderApplication.Abstract;
using CofffeOrderApplication.Concerete;
using CofffeOrderApplication.Repositories;

namespace CofffeOrderApplication.EntityFramework
{
    public class EfOrderInfo : GenericRepository<OrderInfo>, IRepository<OrderInfo>
    {
    }
}