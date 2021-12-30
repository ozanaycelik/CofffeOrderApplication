using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using CofffeOrderApplication.Concerete;
using CofffeOrderApplication.EntityFramework;
using DevExpress.Utils.Internal;

namespace CofffeOrderApplication
{
    public partial class OrderData : System.Web.UI.Page
    {
        OrderInfoManager orderInfoManager = new OrderInfoManager(new EfOrderInfo());

        public void GetList()
        {
            var orderList = orderInfoManager.GetList();
            Repeater1.DataSource = orderList;
            Repeater1.DataBind();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetList();
            
        }

        protected void Repeater1_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string ClientInfo = ((Label)e.Item.FindControl("Label0")).Text;
            string ClientPhone = ((Label)e.Item.FindControl("Label1")).Text;
            string ClientAdress = ((Label)e.Item.FindControl("Label2")).Text;
            string DrinkCode = ((Label)e.Item.FindControl("Label3")).Text;
            string DrinkAmount = ((Label)e.Item.FindControl("Label4")).Text;
            string DrinkHeight = ((Label)e.Item.FindControl("Label5")).Text;
            string DrinkTotal = ((Label)e.Item.FindControl("Label6")).Text;
            string OrderDate = ((Label)e.Item.FindControl("Label7")).Text;
            string OrderRef = ((Label)e.Item.FindControl("Label8")).Text;

            var order = new OrderInfo()
            {
                CLIENT_INFO = ClientInfo,
                CLIENT_PHONE = ClientPhone,
                CLIENT_ADDRESS = ClientAdress,
                DRINK_CODE = DrinkCode,
                DRINK_AMOUNT = int.Parse(DrinkAmount),
                DRINK_HEIGHT = DrinkHeight,
                ORDER_TOTAL = double.Parse(DrinkTotal),
                ORDER_DATE = DateTime.Parse(OrderDate),
                ORDER_REF = Convert.ToInt16(OrderRef)

            };

            if (e.CommandName == "Update")
            {
                txtName.Text = ClientInfo;
                txtPhone.Text = ClientPhone;
                txtAdress.Text = ClientAdress;
                txtDrink.Text = DrinkCode;
                txtHeight.Text = DrinkHeight;
                lblDate.Text = OrderDate;
                lblOrderRef.Text = OrderRef;
                txtAmount.Text = DrinkAmount;
                txtTotal.Text = DrinkTotal;

                //linkButton8.Attributes.Add("onclick", {"Model"});
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", "javascript:modalAc(); ", true);
                //Response.Write( string.Concat("< script type = "+"text"+"/javascript"+ ">$(window).on('Update', function(){ $('#myModal').modal('show'); });</ script >"));
                //Response.Write("<script>$(\"#myModal\").modal()</script>");
                //Response.Write("< script type = \"text/javascript\" > $(window).on('load', function(){('#myModal').modal('show');  }); </ script >");

            }

            if (e.CommandName == "Delete")
            {
                sqlDelete(order.ORDER_REF);
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            var order = new OrderInfo()
            {
                CLIENT_INFO = txtName.Text,
                CLIENT_PHONE = txtPhone.Text,
                CLIENT_ADDRESS = txtAdress.Text,
                DRINK_CODE = txtDrink.Text,
                DRINK_AMOUNT = int.Parse(txtAmount.Text),
                DRINK_HEIGHT = txtHeight.Text,
                ORDER_TOTAL = double.Parse(txtTotal.Text),
                ORDER_DATE = DateTime.Parse(lblDate.Text),
                ORDER_REF = Convert.ToInt16(lblOrderRef.Text)
            };

           sqlUpdate(order);
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAdress.Text = string.Empty;
            txtDrink.Text = string.Empty;
            txtHeight.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblOrderRef.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        public void sqlDelete(int id)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Context"].ConnectionString);
            con.Open();
            SqlCommand delete = new SqlCommand("DELETE FROM OrderInfoes WHERE ORDER_REF=@orderRef", con);
            delete.Parameters.Add("@orderRef", id);
            delete.ExecuteNonQuery();
            con.Close();

            GetList();

        }

        public void sqlUpdate(OrderInfo order)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Context"].ConnectionString);
            con.Open();
            SqlCommand delete = new SqlCommand(@"UPDATE OrderInfoes SET 
                                               CLIENT_INFO=@CLIENT_INFO,
                                               CLIENT_PHONE=@CLIENT_PHONE,
                                               CLIENT_ADDRESS=@CLIENT_ADDRESS,
                                               DRINK_CODE=@DRINK_CODE,
                                               DRINK_AMOUNT=@DRINK_AMOUNT,
                                               DRINK_HEIGHT=@DRINK_HEIGHT,
                                               ORDER_TOTAL=@ORDER_TOTAL WHERE ORDER_REF=@orderRef", con);
            delete.Parameters.Add("@orderRef", order.ORDER_REF);
            delete.Parameters.Add("@CLIENT_INFO", order.CLIENT_INFO);
            delete.Parameters.Add("@CLIENT_PHONE", order.CLIENT_PHONE);
            delete.Parameters.Add("@CLIENT_ADDRESS", order.CLIENT_ADDRESS);
            delete.Parameters.Add("@DRINK_CODE", order.DRINK_CODE);
            delete.Parameters.Add("@DRINK_AMOUNT", order.DRINK_AMOUNT);
            delete.Parameters.Add("@DRINK_HEIGHT", order.DRINK_HEIGHT);
            delete.Parameters.Add("@ORDER_TOTAL", order.ORDER_TOTAL);
            delete.ExecuteNonQuery();
            con.Close();

            GetList();
            
        }
    }
}