<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderScreen.aspx.cs" Inherits="CofffeOrderApplication.OrderScreen" %>

<%@ Register Assembly="DevExpress.Web.ASPxRichEdit.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRichEdit" TagPrefix="dx" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.Bootstrap" Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Çaylarrr.org</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css">
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        /*body{
            color:aliceblue;
        }
        table{
            background-color:#ff6a00;
        }*/
        #TextArea1 {
            height: 94px;
        }

        footer {
            border-style:wave;
            border-width: 1px;
        }

        .auto-style1 {
            width: 493px;
        }
        .auto-style2 {
            width: 203px;
        }
        .auto-style3 {
            width: 201px;
        }
        .auto-style4 {
            width: 307px;
        }
        .auto-style5 {
            width: 1460px;
        }
        .auto-style6 {
            margin-left: 0px;
        }
        .auto-style7 {
            width: 259px;
        }
    </style>

</head>
<body style="background: antiquewhite">
    <form id="form2" runat="server">
        <div>
            <a href="OrderData.aspx">Bütün Siparişlerim</a>
            <h1 class="auto-style5" align="center" style="background-color: darkcyan" height="100px">
                
                <img src="Image/CoffeOrderImage/indir.png" height="50px" align="absmiddle" />

                Kahve Evi Sipariş Ekranı
            </h1>
            <div style="margin:50px 1px 1px 1px; float: right;position: marker ; margin-top: auto;top: 100px">
                <b>Siparişlerim</b> <br/>
                <dx:ASPxListBox ID="ASPxListBox1" runat="server" Height="444px" ValueType="System.String" Width="500px" CssClass="auto-style6">
                </dx:ASPxListBox>
                <br/>
                <div><b>Toplam Sipariş Tutarı : </b><b><asp:Label runat="server" ID="lblNetPrice">------</asp:Label> TL</b></div>
                <asp:Button runat="server" ID="btnAddOrder" OnClick="btnAddOrder_OnClick" Text="Sipariş Ver" Width="416px"/>
            </div>

            <table border="0" style="width: 500px" class="tablo">
                <thead><u><b>Müşteri Bilgileri</b></u></thead>
                <tbody>
                    <tr>
                        <td class="auto-style1">Ad Soyad</td>
                        <td aria-autocomplete="inline" class="auto-style11">
                            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="265px" Height="15px"></dx:ASPxTextBox>
                        </td>
                    </tr>
                <br />
                    <tr>
                        <td class="auto-style1">Telefon</td>
                        <td aria-autocomplete="inline" class="auto-style11">
                            <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="265px"></dx:ASPxTextBox>
                        </td>
                        <br />
                    </tr>
                <br />
                    <tr>
                        <td class="auto-style1">Adres</td>
                        <td aria-autocomplete="inline" class="auto-style11">
                            <textarea id="TextArea1" runat="server"  style="resize: none; " class="auto-style7"></textarea>

                        </td>

                    </tr>
                </tbody>
            </table>
            <br />
            <table>
                <thead>
                    <div><u><b>Ürünler</b></u></div>
                <br />
                </thead>
                <tbody>
                    <td class="auto-style2">
                        <img src="Image/CoffeOrderImage/indir.png" width="25px" height="25px" />
                        Kahveler
                    </td>

                    <td aria-autocomplete="inline" class="auto-style11">
                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" EnableTheming="True" Theme="Default" 
                                         OnSelectedIndexChanged="ASPxComboBox1_OnSelectedIndexChanged" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="Misto" Value="4.5" />
                                <dx:ListEditItem Text="Americano" Value="5.75" />
                                <dx:ListEditItem Text="Bianco" Value="6" />
                                <dx:ListEditItem Text="Cappucino" Value="7.5" />
                                <dx:ListEditItem Text="Macchiato" Value="6.75" />
                                <dx:ListEditItem Text="ConPanna" Value="8" />
                                <dx:ListEditItem Text="Mocha" Value="7.75" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td>
                        <span>Adet</span>
                        <input type="number" id="amount1" name="amount1"/>
                        <asp:HiddenField ID="NumericUpDown1" runat="server" />
                    </td>
                </tbody>
                <tbody>
                <td class="auto-style2">
                    <img src="Image/CoffeOrderImage/IceDrink.png" width="25px" height="25px" />
                    Soğuk İçecekler
                </td>

                <td aria-autocomplete="inline" class="auto-style11">
                    <dx:ASPxComboBox ID="cbxIceDrink" runat="server" EnableTheming="True" Theme="Default"
                                     OnSelectedIndexChanged="cbxIceDrink_OnSelectedIndexChanged" AutoPostBack="True">
                        <Items>
                            <dx:ListEditItem Text="Cola" Value="4.5" />
                            <dx:ListEditItem Text="Fanta" Value="5.75" />
                            <dx:ListEditItem Text="Soda" Value="6" />
                            <dx:ListEditItem Text="Juice" Value="7.5" />
                            <dx:ListEditItem Text="MilkShake" Value="8"/>
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td>
                    <span>Adet</span>
                    <input type="number" id="amount2" name="amount2"/>
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </td>
                </tbody>

                <tbody>
                <td class="auto-style2">
                    <img src="Image/CoffeOrderImage/HotChocolate.png" width="25px" height="25px" />
                    Sıcak İçecekler
                </td>

                <td aria-autocomplete="inline" class="auto-style11">
                    <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" EnableTheming="True" Theme="Default"
                                     OnSelectedIndexChanged="ASPxComboBox2_OnSelectedIndexChanged" AutoPostBack="True">
                        <Items>
                            <dx:ListEditItem Text="Çay" Value="3" />
                            <dx:ListEditItem Text="HotChocolate" Value="4.5" />
                            <dx:ListEditItem Text="ChaiTeaLatte" Value="6.5" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td>
                    <span>Adet</span>
                    <input type="number" id="amount3" name="amount3"/>
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                </td>
                </tbody>
            </table>
            <br />
            <table>
                <thead><u><b>Ekstralar</b></u></thead>
                <tbody>
                <tr>
                    <td class="auto-style3">Shot :</td>
                    <td aria-autocomplete="inline" class="auto-style11">
                        <dx:ASPxCheckBoxList ID="ASPxCheckBoxList1" runat="server" Width="365px">
                            <Items>
                                <dx:ListEditItem Text="1x" Value="0.75" />
                                <dx:ListEditItem Text="2x" Value="1.5" />
                            </Items>
                        </dx:ASPxCheckBoxList>
                    </td>
                </tr>
                </tbody>
                
                <tbody>
                <tr>
                    <td class="auto-style3">Süt :</td>
                    <td aria-autocomplete="inline" class="auto-style11">
                        <dx:ASPxCheckBoxList ID="ASPxCheckBoxList2" runat="server" Width="365px">
                            <Items>
                                <dx:ListEditItem Text="Yağsız" Value="0.75" />
                                <dx:ListEditItem Text="Soya" Value="1.5" />
                            </Items>
                        </dx:ASPxCheckBoxList>
                    </td>
                </tr>
                </tbody>
                <tbody>
                <tr>
                    <td class="auto-style3">İçecek Boyutu :</td>
                    <td aria-autocomplete="inline" class="auto-style11">
                        <dx:ASPxComboBox ID="ASPxComboBox3" runat="server" EnableTheming="True" Theme="Default" Width="364px">
                            <Items>
                                <dx:ListEditItem Text="Tall" Value="1" />
                                <dx:ListEditItem Text="Grande" Value="1.25" />
                                <dx:ListEditItem Text="Venti" Value="1.75" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                </tbody>
            </table>
            <footer class="auto-style4">
                <br/>
                <asp:Button runat="server" ID="btnClear" OnClick="btnClear_OnClick" Text="Temizle" />
                <asp:Button runat="server" ID="btnCalculate" OnClick="btnCalculate_OnClick" Text="Hesapla" />
            </footer>
        </div>
 
    </form>




</body>
</html>
