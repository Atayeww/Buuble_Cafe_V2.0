<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="BookListing.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.BookListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="helper">
        <asp:ListView ID="lv_booklisting" runat="server" OnItemCommand="lv_booklisting_ItemCommand">
            <LayoutTemplate>
                <table class="categoryTable" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <td>No</td>
                            <td>Kitap Adı</td>
                            <td>Kategori</td>
                            <td>Yazar</td>
                            <td>Yayın Evi</td>
                            <td>Sayfa</td>
                            <td>Basım Tarihi</td>
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
                    <td><%# Eval("Category") %></td>
                    <td><%# Eval("Writer") %></td>
                    <td><%# Eval("Publisher") %></td>
                    <td><%# Eval("Page") %></td>
                    <td><%# Eval("ReleaseDate") %></td>
                    <td style="width:150px">
                        <a href='BookEdit.aspx?bid=<%# Eval("ID") %>' class="editbutton">Düzenle</a>
                        <asp:LinkButton ID="lbtn_bookdelete" runat="server" CssClass="deletebutton" CommandName="remove" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <a href="BookAdd.aspx">
            <div class="categoryAddButton">
                Kitap Ekle
            </div>
        </a>
    </div>
</asp:Content>
