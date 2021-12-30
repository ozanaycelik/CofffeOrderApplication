<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderData.aspx.cs" Inherits="CofffeOrderApplication.OrderData" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css">
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js"></script>

    <script type="text/javascript" language="javascript">
        function modalAc() {
            $('#myModal').modal(Show)
        }
        function helloWorld() {
            alert("welcome to codepedia.info");
        }
    </script>


</head>
<body style="background: antiquewhite">
    <form id="form1" runat="server">
        <div>
            <a href="OrderScreen.aspx">Sipariş Ver</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="OrderData.aspx" style="padding-left: 10px">Listele</a>
            <h1 class="auto-style5" align="center" style="background-color: darkcyan" height="100px">

                <img src="Image/CoffeOrderImage/indir.png" height="50px" align="absmiddle" />

                Kahve Evi Sipariş Ekranı
            </h1>
        </div>
        
            
        <div>
            <table border="5" cellpadding="0" cellspacing="0" style="float:left">
            <tr>
                <td>
                <label class="label-info">Müşteri Bilgileri :</label>
                <asp:TextBox runat="server" ID="txtName" CssClass="text-info"></asp:TextBox>
                <br />
                <label class="label-info">Müşteri İletişim :</label>
                <asp:TextBox runat="server" ID="txtPhone" CssClass="text-info"></asp:TextBox>
                <br />
                <label class="label-info">Müşteri Adres :</label>
                <asp:TextBox runat="server" ID="txtAdress" CssClass="text-info"></asp:TextBox>
                <br />
                <label class="label-info">İçecek :</label>
                <asp:TextBox runat="server" ID="txtDrink" CssClass="text-info"></asp:TextBox>
                <br />
                <label class="label-info">Miktar :</label>
                <asp:TextBox TextMode="Number" ID="txtAmount" runat="server" CssClass="text-info"></asp:TextBox>
                <br />
                <label class="label-info">Boyut :</label>
                <asp:TextBox runat="server" ID="txtHeight" CssClass="text-info"></asp:TextBox>
                <br />
                <label class="label-info">Tutar :</label>
                <asp:TextBox Enabled="False" ID="txtTotal" runat="server" CssClass="text-info"></asp:TextBox>
                    <div align="right" >
                        <asp:Button ID="btnSave" class="btn btn-info" runat="server" OnClick="btnSave_OnClick" Text="Güncelle"/>
                        <asp:Button ID="btnCancel" class="btn btn-danger"  runat="server" OnClick="btnCancel_OnClick" Text="Vazgeç"/>
                    </div>
                </td>
            </tr>
                <br />
                <asp:Label runat="server" ID="lblDate" Visible="False"></asp:Label>
                <asp:Label runat="server" ID="lblOrderRef" Visible="False"></asp:Label>
           
        </table>
        </div>
        <!-- Modal footer -->
       

        <div>
            <table border="10" style="width: 900px;padding-top: 10px" align="right">
                <thead>
                    <tr>
                        <td>Müşteri Bilgileri</td>
                        <td>Müşteri Telefon Numarası</td>
                        <td>Müşteri Adresi</td>
                        <td>Sipariş Tarihi</td>
                        <td>İçecek</td>
                        <td>Miktar</td>
                        <td>İçecek Boyutu</td>
                        <td>Sipariş Toplamı</td>
                        <td>Siparişi Düzenle</td>
                        <td>Siparişi Sil</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_OnItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label0" runat="server" Text='<%#Eval("CLIENT_INFO") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("CLIENT_PHONE") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("CLIENT_ADDRESS") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("ORDER_DATE").ToString().Substring(0,10) %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("DRINK_CODE") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("DRINK_AMOUNT") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("DRINK_HEIGHT") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("ORDER_TOTAL") %>'></asp:Label></td>

                                <td align="center">
                                    <asp:LinkButton ID="Linkbutton1" CommandName="Update" runat="server" Text="Düzenle" CommandArgument='<%# Eval("ORDER_REF")%>' /></td>
                                <td align="center">
                                    <asp:LinkButton ID="Linkbutton2" CommandName="Delete" runat="server" Text="Sil" CommandArgument='<%# Eval("ORDER_REF")%>' /></td>
                                <td style="visibility: hidden; width: 1px; height: 1px">
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("ORDER_REF") %>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>

            </table>
        </div>
           
    </form>
</body>
</html>
