<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="WriterAdd.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.WriterAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="frame">
        <h3 class="target">Yeni Yazar Ekle</h3>
        <asp:Panel ID="pnl_success" runat="server" Visible="false" CssClass="success">Yazar Başarıyla Eklendi</asp:Panel>
        <asp:Panel ID="pnl_fail" runat="server" Visible="false" CssClass="fail">
            <asp:Label ID="lbl_message" runat="server"></asp:Label>
        </asp:Panel>
        <div class="raw">
            <asp:TextBox ID="tb_addWriterName" runat="server" CssClass="searchbox" placeholder="Adı"></asp:TextBox>
            <asp:TextBox ID="tb_addWriterSurname" runat="server" CssClass="searchbox" placeholder="Soyadı"></asp:TextBox>
        </div>
        <div class="raw">
            <asp:LinkButton ID="lbtn_addWriter" runat="server" OnClick="lbtn_addWriter_Click" CssClass="editLinkButton">Uygula</asp:LinkButton></div>
    </div>
</asp:Content>
