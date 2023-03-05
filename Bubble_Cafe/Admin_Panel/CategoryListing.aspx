<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="CategoryListing.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.CategoryListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="helper">
        <asp:ListView ID="lv_categories" runat="server" OnItemCommand="lv_categories_ItemCommand">
        <LayoutTemplate>
            <table class="categoryTable" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <td>No</td>
                        <td>Kategori Adı</td>
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
                <td>
                    <a href='CategoryEdit.aspx?cid=<%# Eval("ID") %>' class="editbutton">Düzenle</a>
                    <asp:LinkButton ID="lbtn_categorydelete" runat="server" CssClass="deletebutton" CommandName="remove" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
        <a href="CategoryAdd.aspx">
            <div class="categoryAddButton">
                Kategori Ekle
            </div>
        </a>
    </div>
</asp:Content>
