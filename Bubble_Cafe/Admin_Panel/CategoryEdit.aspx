<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.CategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="frame">
        <h3 class="target">Kategori Düzenle</h3>
        <asp:Panel ID="pnl_success" runat="server" Visible="false" CssClass="success">Kategori Düzenleme Başarılı</asp:Panel>
        <asp:Panel ID="pnl_fail" runat="server" Visible="false" CssClass="fail">Kategori Düzenleme Başarısız</asp:Panel>
        <div class="raw">
            <asp:TextBox ID="tb_editCategory" runat="server" CssClass="searchbox"></asp:TextBox></div>
        <div class="raw">
            <asp:LinkButton ID="lbtn_editCategoryName" runat="server" OnClick="lbtn_editCategoryName_Click" CssClass="editLinkButton">Kategori Düzenle</asp:LinkButton></div>
    </div>
</asp:Content>
