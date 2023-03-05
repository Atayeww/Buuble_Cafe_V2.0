<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="UsersListing.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.UsersListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="helper">
        <asp:ListView ID="lv_users" runat="server" OnItemCommand="lv_users_ItemCommand">
            <LayoutTemplate>
                <table class="categoryTable" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <td>No</td>
                            <td>Adı</td>
                            <td>Soyadı</td>
                            <td>Kullanıcı Adı</td>
                            <td>Email</td>
                            <td>Şifre</td>
                            <td>Durum</td>
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
                    <td><%# Eval("Nickname") %></td>
                    <td><%# Eval("Mail") %></td>
                    <td><%# Eval("Password") %></td>
                    <td><%# Eval("State") %></td>
                    <td>
                    <asp:LinkButton ID="lbtn_userdelete" runat="server" CssClass="deletebutton" CommandName="remove" CommandArgument='<%# Eval("ID") %>'>Engelle</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
