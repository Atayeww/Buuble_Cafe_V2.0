<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CitUserList.aspx.cs" Inherits="Bubble_Cafe.CitUserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="AssetsSource/css/StyleUserPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="citdetail">
        <div class="citimage">
            <asp:Image ID="img_picture" runat="server" />
        </div>
        <div class="citusername">
            <div style="float: left; font-size: 14pt;">
                <i class="fa-solid fa-at"></i>
                <asp:Literal ID="ltrl_citusername" runat="server"></asp:Literal>
            </div>
            <div class="liked">
                <i class="fa-solid fa-eye"></i>: 
                <asp:Literal ID="ltrl_citview" runat="server"></asp:Literal>
                <asp:LinkButton ID="lbtn_liked" runat="server" Style="margin-left: 20px;" OnClick="lbtn_liked_Click"><i class="fa-solid fa-thumbs-up"></i></asp:LinkButton>
                : 
                <asp:Literal ID="ltrl_likedshow" runat="server"></asp:Literal>
                <asp:LinkButton ID="lbtn_disliked" runat="server" Style="margin-left: 10px;" OnClick="lbtn_disliked_Click"><i class="fa-solid fa-thumbs-down"></i></asp:LinkButton>
            </div>
            <div style="clear: both;"></div>
        </div>
        <div class="citation">
            <asp:Literal ID="ltrl_citation" runat="server"></asp:Literal><br />
            <asp:Panel ID="pnl_citopinion" runat="server" Visible="false">
                <label style="font-weight: 800">İncelemeler : </label>
                <br />
                <asp:Literal ID="ltrl_citopinion" runat="server"></asp:Literal>
            </asp:Panel>
            <div style="font-weight: 800">
                Sayfa:
                <asp:Literal ID="ltrl_citpage" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="citinfo">
            <asp:Literal ID="ltrl_citbookname" runat="server"></asp:Literal>
            | 
            <asp:Literal ID="ltrl_citwrietr" runat="server"></asp:Literal>
            | 
            Sayfa:
            <asp:Literal ID="ltrl_citbookpage" runat="server"></asp:Literal>
        </div>
        <div style="clear: both"></div>
    </div>
</asp:Content>
