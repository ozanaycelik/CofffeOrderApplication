using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CofffeOrderApplication.Concerete
{
    public class Context: DbContext
    {
        DbSet<OrderInfo> OrderInfo { get; set; }
    }
}