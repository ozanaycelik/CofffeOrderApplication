using System;
using System.ComponentModel.DataAnnotations;

namespace CofffeOrderApplication.Concerete
{
    public class OrderInfo
    {
        [Key]
        public int ORDER_REF { get; set; }
        public string CLIENT_INFO { get; set; }
        public string CLIENT_PHONE { get; set; }
        public string CLIENT_ADDRESS { get; set; }
        public string DRINK_CODE { get; set; }
        public int DRINK_AMOUNT { get; set; }
        public string DRINK_HEIGHT { get; set; }
        //public string DRINK_SHOT { get; set; }
        //public string DRINK_MILK { get; set; }
        public double ORDER_TOTAL { get; set; }
        public DateTime ORDER_DATE { get; set; }

    }
}