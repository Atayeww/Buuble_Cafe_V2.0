<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bubble_Cafe.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="AssetsSource/css/LoginStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="height:100%">
        <div class="adminloginframe">
            <div class="adminloginbox">
                <img src="ImageSource/Bubble_Cafe_Brown.png" />
                <asp:Panel ID="pnl_loginerror" runat="server" Visible="false" CssClass="loginerror">
                    <asp:Label ID="lbl_adminloginerror" runat="server" CssClass="attention">deneme</asp:Label>
                </asp:Panel>
                <h2 class="entry">Giriş Yapınız</h2>
                <br />
                <div class="raw">
                <asp:TextBox ID="tb_adminlogin" runat="server" placeholder="E-posta Adresi" CssClass="searchbox"></asp:TextBox>
                </div>
                <div class="raw">
                <asp:TextBox ID="tb_adminpassword" runat="server" placeholder="Şifre" CssClass="searchbox"></asp:TextBox>
                </div>
                <div class="raw">
                    <asp:LinkButton ID="lbtn_userlogin" runat="server" Text="Giriş Yap" CssClass="loginbutton" OnClick="lbtn_userlogin_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
