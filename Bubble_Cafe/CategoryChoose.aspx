<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CategoryChoose.aspx.cs" Inherits="Bubble_Cafe.CategoryChoose" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_citations" runat="server">
        <ItemTemplate>
            <a href='CitUserList.aspx?citid=<%# Eval("ID") %>'>
                <div class="citationDiv">
                <div class="picture">
                    <img src ='ImageSource/<%# Eval("BookImage") %>' style="width:256px"/>
                </div>
                <div class="bookinfo">
                    <%# Eval("BookName") %> | <%# Eval("BookWriters") %> | <%# Eval("BookCategories") %>
                </div>
                <div class="bookcitation">
                    <%# Eval("Citation") %>
                </div>
            </div>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
