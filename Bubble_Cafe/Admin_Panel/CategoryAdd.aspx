<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="CategoryAdd.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.CategoryAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="frame">
        <h3 class="target">Kategori Ekle</h3>
        <asp:Panel ID="pnl_success" runat="server" Visible="false" CssClass="success">Kategori Ekleme Başarılı</asp:Panel>
        <asp:Panel ID="pnl_fail" runat="server" Visible="false" CssClass="fail">
            <asp:Label ID="lbl_message" runat="server"></asp:Label>
        </asp:Panel>
        <div class="raw">
            <asp:TextBox ID="tb_addCategory" runat="server" CssClass="searchbox" placeholder="Kategori Adı Giriniz"></asp:TextBox></div>
        <div class="raw">
            <asp:LinkButton ID="lbtn_addCategoryName" runat="server" OnClick="lbtn_addCategoryName_Click" CssClass="editLinkButton">Kategori Ekle</asp:LinkButton></div>
    </div>
</asp:Content>
