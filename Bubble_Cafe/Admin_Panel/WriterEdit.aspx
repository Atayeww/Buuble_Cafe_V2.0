<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="WriterEdit.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.WriterEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="frame">
        <h3 class="target">Yazar Biligilerini Düzenle</h3>
        <asp:Panel ID="pnl_success" runat="server" Visible="false" CssClass="success">Kategori Düzenleme Başarılı</asp:Panel>
        <asp:Panel ID="pnl_fail" runat="server" Visible="false" CssClass="fail">Kategori Düzenleme Başarısız</asp:Panel>
        <div class="raw">
            <label class="label">Yazar Adı ve Soyadı Giriniz</label><br />
            <asp:TextBox ID="tb_editWriterName" runat="server" CssClass="searchbox"></asp:TextBox>
            <asp:TextBox ID="tb_editWriterSurname" runat="server" CssClass="searchbox"></asp:TextBox>
        </div>
        <div class="raw">
            <asp:LinkButton ID="lbtn_editWriter" runat="server" OnClick="lbtn_editWriter_Click" CssClass="editLinkButton">Uygula</asp:LinkButton>
        </div>
    </div>
</asp:Content>
