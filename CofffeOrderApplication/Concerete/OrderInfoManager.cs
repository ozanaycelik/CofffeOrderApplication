using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CofffeOrderApplication.Abstract;

namespace CofffeOrderApplication.Concerete
{
    public class OrderInfoManager:IOrderService
    {
        IRepository<OrderInfo> _orderInfo;

        public OrderInfoManager(IRepository<OrderInfo> orderInfo)
        {
            _orderInfo = orderInfo;
        }

        public List<OrderInfo> GetList()
        {
            return _orderInfo.List();
        }

        public void OrderInfoAdd(OrderInfo about)
        {
            _orderInfo.Insert(about);
        }

        public OrderInfo GetByID(int id)
        {
            return _orderInfo.Get(x => x.ORDER_REF == id);
        }

        public void OrderInfoDelete(OrderInfo orderInfo)
        {
            _orderInfo.Delete(orderInfo);
        }

        public void OrderInfoUpdate(OrderInfo orderInfo)
        {
            _orderInfo.Update(orderInfo);
        }
    }
}