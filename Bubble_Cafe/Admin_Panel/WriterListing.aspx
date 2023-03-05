<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="WriterListing.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.WriterListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="helper">
        <asp:ListView ID="lv_writer" runat="server" OnItemCommand="lv_writer_ItemCommand">
        <LayoutTemplate>
            <table class="categoryTable" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <td>No</td>
                        <td>Ad</td>
                        <td>Soyad</td>
                        <td>Seçenekler</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("ID") %></td>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("Surname") %></td>
                <td>
                    <a href='WriterEdit.aspx?wrid=<%# Eval("ID") %>' class="editbutton">Düzenle</a>
                    <asp:LinkButton ID="lbtn_writerdelete" runat="server" CssClass="deletebutton" CommandName="remove" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
        <a href="WriterAdd.aspx">
            <div class="categoryAddButton">
                Yeni Yazar Ekle
            </div>
        </a>
    </div>
</asp:Content>
