<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bubble Cafe Giriş</title>
    <link href="Assets/css/AdminLoginStyle.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server" style="height:100%">
        <div class="adminloginframe">
            <div class="adminloginbox">
                <img src="Assets/images/Bubble_Cafe_Icon_White.png" />
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
                    <asp:LinkButton ID="lbtn_adminlogin" runat="server" OnClick="lbtn_adminlogin_Click" Text="Giriş Yap" CssClass="loginbutton"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
