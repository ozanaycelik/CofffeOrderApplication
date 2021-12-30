using EntityLayer.Concerete;
using System.Data.Entity;

namespace DataAccessLayer.Concerete
{
    public class Context : DbContext
    {
        DbSet<OrderInfo> OrderInfo { get; set; }
    }
}
