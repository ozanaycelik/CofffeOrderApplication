using System.Collections.Generic;
using CofffeOrderApplication.Concerete;

namespace CofffeOrderApplication.Abstract
{
    public interface IOrderService
    {
        List<OrderInfo> GetList();

        void OrderInfoAdd(OrderInfo orderInfo);

        OrderInfo GetByID(int id);
        void OrderInfoDelete(OrderInfo orderInfo);

        void OrderInfoUpdate(OrderInfo orderInfo);
    }
}