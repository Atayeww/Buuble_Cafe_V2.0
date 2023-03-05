<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Bubble_Cafe.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KayıtOl</title>
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
                <h2 class="entry">Kayıt Ol</h2>
                <br />
                <div class="raw">
                <asp:TextBox ID="tb_username" runat="server" placeholder="Ad" CssClass="searchbox"></asp:TextBox>
                </div>
                <div class="raw">
                <asp:TextBox ID="tb_usersurname" runat="server" placeholder="Soyad" CssClass="searchbox"></asp:TextBox>
                </div>
                <div class="raw">
                <asp:TextBox ID="tb_usernickname" runat="server" placeholder="Kullanıcı Adı" CssClass="searchbox"></asp:TextBox>
                </div>
                <div class="raw">
                <asp:TextBox ID="tb_adminlogin" runat="server" placeholder="E-posta Adresi" CssClass="searchbox"></asp:TextBox>
                </div>
                <div class="raw">
                <asp:TextBox ID="tb_adminpassword" runat="server" placeholder="Şifre" CssClass="searchbox"></asp:TextBox>
                </div>
                <div class="raw">
                    <asp:LinkButton ID="lbtn_usersignup" runat="server" Text="Kayıt Ol" CssClass="loginbutton" OnClick="lbtn_usersignup_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
