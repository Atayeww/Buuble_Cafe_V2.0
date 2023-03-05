<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="CitationListing.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.CitationListing" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_citationsAdmin" runat="server">
        <ItemTemplate>
            <a href='CitationMoreDetail.aspx?citid=<%# Eval("ID") %>'>
                <div class="citationDiv">
                <div class="picture">
                    <img src ='../ImageSource/<%# Eval("BookImage") %>' style="width:260px"/>
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
