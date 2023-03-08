<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Bubble_Cafe.UserEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="AssetsSource/css/LoginStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="adminloginframe">
            <div class="adminloginbox">
                <img src="ImageSource/Bubble_Cafe_Brown.png" />
                <asp:Panel ID="pnl_loginerror" runat="server" Visible="false" CssClass="loginerror">
                    <asp:Label ID="lbl_adminloginerror" runat="server" CssClass="attention">deneme</asp:Label>
                </asp:Panel>
                <h2 class="entry">Düzenle</h2>
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
                    <asp:LinkButton ID="lbtn_usersignupp" runat="server" Text="Düzenle" CssClass="loginbutton" OnClick="lbtn_usersignupp_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
</asp:Content>
