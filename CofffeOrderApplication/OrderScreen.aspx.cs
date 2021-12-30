using System;
using CofffeOrderApplication.Abstract;
using CofffeOrderApplication.Concerete;
using CofffeOrderApplication.EntityFramework;
using CofffeOrderApplication.Repositories;
using DevExpress.Data.Extensions;

namespace CofffeOrderApplication
{
    public partial class OrderScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_OnClick(object sender, EventArgs e)
        {
            string nameSurname = ASPxTextBox1.Text;
            var phoneNumber = ASPxTextBox2.Text;
            var Adress = TextArea1.Value;

            var coffeType = ASPxComboBox1.Text;
            var coffePrice = ASPxComboBox1.Value == null ? ASPxComboBox1.Value : Convert.ToDouble(ASPxComboBox1.Value.ToString().Replace('.', ','));
            var coffeAmount = Request.Form["amount1"] == "" ? "0" : Request.Form["amount1"];

            var iceDrinkType = cbxIceDrink.Text;
            var icePrice = 5.5;
            var iceAmount = Request.Form["amount2"] == "" ? "0" : Request.Form["amount2"];

            var hotDrinkType = ASPxComboBox2.Text;
            var hotDrinkPrice = ASPxComboBox2.Value == null ? ASPxComboBox2.Value : Convert.ToDouble(ASPxComboBox2.Value.ToString().Replace('.', ','));
            var hotAmount = Request.Form["amount3"] == "" ? "0" : Request.Form["amount3"];

            var shotCount = ASPxCheckBoxList1.SelectedItems.Count;
            double shotPrice = 0;
            var shotName = string.Empty;
            int shotValue = 0;

            foreach (var item in ASPxCheckBoxList1.SelectedItems)
            {
                shotValue = Convert.ToInt32(item.ToString().Replace("x", ""));
            }

            if (shotValue!=0)
            {
                shotName = string.Concat(shotValue + "x shot");
                shotPrice = 0.75 * shotValue;

            }

            var milkCount = ASPxCheckBoxList2.SelectedItems.Count;
            double milkPrice = 0;
            var milkName = string.Empty;

            if (milkCount == 2)
            {
                milkPrice = 1.5;
                milkName = "Yağsız-soyalı süt";
            }
            else if (milkCount == 1)
            {
                milkPrice = 0.75;
                foreach (var item in ASPxCheckBoxList2.SelectedItems)
                {
                    milkName = item.ToString() + " süt";
                }

            }
            else
            {
                milkPrice = 0;
            }

            var drinkHeight = ASPxComboBox3.Text;
            var drinkHeightPrice = Convert.ToDouble(ASPxComboBox3.Value==null? ASPxComboBox3.Value:ASPxComboBox3.Value.ToString().Replace(".",","));


            double netAmount = 0;
            double netPrice = 0;

            if (Convert.ToDouble(coffeAmount) > 0)
            {
                netAmount = Convert.ToDouble(coffeAmount);
                netPrice = Convert.ToDouble(coffePrice);
            }
            else if (Convert.ToDouble(iceAmount) > 0)
            {
                netAmount = Convert.ToDouble(iceAmount);
                netPrice = icePrice;
            }
            else
            {
                netAmount = Convert.ToDouble(hotAmount);
                netPrice = Convert.ToDouble(hotDrinkPrice);
            }

            var netOrderPrice = (netPrice + shotPrice + milkPrice + drinkHeightPrice) * (netAmount);

            var order = string.Concat(drinkHeight + ", "
                                                + coffeAmount.Replace("0", "") + iceAmount.Replace("0", "") + hotAmount.Replace("0", "") + "x"
                                                + coffeType + iceDrinkType + hotDrinkType + ", "
                                           + shotName + ", " + milkName + "; Fiyat =" + netOrderPrice + "TL");


            var message = "Merhaba," + nameSurname + " siparişiniz ortalama 10-15 dk içinde hazır olacaktır." +
                          "Siparişleriniz :" + coffeType + coffePrice;
            // Response.Write kısmı js kullanarak mesaj çıkardık!
            //Response.Write("<script>alert('"+message+"');</script>");

            ASPxListBox1.Items.Add(order);
            double total = 0;

            foreach (var listItems in ASPxListBox1.Items)
            {
                var a = listItems.ToString().IndexOf('=');
                var b = listItems.ToString().IndexOf("TL");
                var c = Convert.ToDouble(listItems.ToString().Substring(a + 1, b - a - 1));
                total += c;
            }

            lblNetPrice.Text = total.ToString();
        }

        protected void btnClear_OnClick(object sender, EventArgs e)
        {
            TextArea1.InnerText = string.Empty;
            cbxIceDrink.Text = string.Empty;
            ASPxComboBox1.Text = string.Empty;
            ASPxTextBox2.Text = string.Empty;
            ASPxCheckBoxList1.Value = 0;
            ASPxCheckBoxList2.Value = 0;
            ASPxTextBox1.Text = string.Empty;
            ASPxComboBox2.Text = string.Empty;
            ASPxComboBox3.Text = string.Empty;

        }

        protected void btnAddOrder_OnClick(object sender, EventArgs e)
        {
            OrderInfoManager orderInfoManager = new OrderInfoManager(new EfOrderInfo());
            string[] virgül;



            foreach (var item in ASPxListBox1.Items)
            {

                virgül = item.ToString().Split();

                var itemCodeLengthStart = virgül[1].ToString().IndexOf('x');
                var itemCodeLengthEnd = virgül[1].ToString().IndexOf(",");

                var priceLengthStart = item.ToString().IndexOf('=');
                var priceLengthEnd = item.ToString().IndexOf("TL");
                var price = Convert.ToDouble(item.ToString().Substring(priceLengthStart + 1, priceLengthEnd - priceLengthStart - 1));

                var order = new OrderInfo()
                {
                    CLIENT_INFO = ASPxTextBox1.Text,
                    CLIENT_PHONE = ASPxTextBox2.Text,
                    CLIENT_ADDRESS = TextArea1.InnerText,
                    DRINK_CODE = virgül[1].ToString().Substring(itemCodeLengthStart + 1, itemCodeLengthEnd - 2),
                    DRINK_AMOUNT = int.Parse(virgül[1].ToString().Substring(0, itemCodeLengthStart)),
                    ORDER_DATE = DateTime.Now.Date,
                    DRINK_HEIGHT = item.ToString().Substring(0,item.ToString().IndexOf(",")),
                    ORDER_TOTAL = price
                };

                if (string.IsNullOrEmpty(order.CLIENT_PHONE)|| string.IsNullOrEmpty(order.CLIENT_ADDRESS)|| string.IsNullOrEmpty(order.CLIENT_INFO))
                {
                    var message = "Müşteri bilgilerini doldurmadan sipariş veremezsiniz !";
                    // Response.Write kısmı js kullanarak mesaj çıkardık!
                    Response.Write("<script>alert('"+message+"');</script>");

                }
                else
                {
                    orderInfoManager.OrderInfoAdd(order);
                }


            }
        }
        protected void ASPxComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxIceDrink.Text))
            {
                cbxIceDrink.Text = string.Empty;
                //var iceAmount = int.Parse(Request.Form["amount2"]);
            }

            if (!string.IsNullOrEmpty(ASPxComboBox2.Text))
            {
                ASPxComboBox2.Text = string.Empty;
            }
        }

        protected void cbxIceDrink_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ASPxComboBox1.Text))
            {
                ASPxComboBox1.Text = string.Empty;
                //var iceAmount = int.Parse(Request.Form["amount2"]);
            }

            if (!string.IsNullOrEmpty(ASPxComboBox2.Text))
            {
                ASPxComboBox2.Text = string.Empty;
            }
        }

        protected void ASPxComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ASPxComboBox1.Text))
            {
                ASPxComboBox1.Text = string.Empty;
                //var iceAmount = int.Parse(Request.Form["amount2"]);
            }

            if (!string.IsNullOrEmpty(cbxIceDrink.Text))
            {
                cbxIceDrink.Text = string.Empty;
            }

            ASPxCheckBoxList1.Value = 0;
            ASPxCheckBoxList2.Value = 0;
            ASPxComboBox3.Text = string.Empty;
        }
    }
}