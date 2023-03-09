<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="CommentMoreDetail.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.CommentMoreDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="citdetail">
        <div class="citusername">
            <div style="float: left; font-size: 14pt;">
                <i class="fa-solid fa-at"></i>
                <asp:Literal ID="ltrl_citusernamecom" runat="server"></asp:Literal>
            </div>
            <div style="clear: both"></div>
        </div>
        <div class="citation">
            <asp:Literal ID="ltrl_comment" runat="server"></asp:Literal>
        </div>
        <div style="clear: both"></div>
        <div class="accept">
            <div class="accept">
                <asp:LinkButton ID="lbtn_acceptcitation" runat="server" CssClass="acceptbutton" OnClick="lbtn_acceptcitation_Click">Onayla</asp:LinkButton>
                <asp:LinkButton ID="lbtn_deletecitation" runat="server" CssClass="rejectbutton" OnClick="lbtn_deletecitation_Click">Sil</asp:LinkButton>
            </div>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
