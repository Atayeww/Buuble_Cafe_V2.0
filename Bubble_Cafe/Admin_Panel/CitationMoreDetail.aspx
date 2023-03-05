<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="CitationMoreDetail.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.CitationMoreDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="citdetail">
        <div class="citimage">
            <asp:Image ID="img_picture" runat="server" Style="width: 600px;" />
        </div>
        <div class="citusername">
            <div style="float: left; font-size: 14pt;">
                <i class="fa-solid fa-at"></i>
                <asp:Literal ID="ltrl_citusername" runat="server"></asp:Literal>
            </div>
            <div style="clear: both"></div>
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
        <div class="accept">
            <asp:LinkButton ID="lbtn_acceptcitation" runat="server" CssClass="acceptbutton" OnClick="lbtn_acceptcitation_Click">Onayla</asp:LinkButton>
            <asp:LinkButton ID="lbtn_deletecitation" runat="server" CssClass="rejectbutton" OnClick="lbtn_deletecitation_Click">Reddet</asp:LinkButton>
        </div>
    </div>
</asp:Content>
