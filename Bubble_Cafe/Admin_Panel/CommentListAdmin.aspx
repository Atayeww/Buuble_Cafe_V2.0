<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="CommentListAdmin.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.CommentListAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_commentaccept" runat="server">
        <ItemTemplate>
            <div class="commentframe">
                <div class="usercomment">
                    <div style="float:left; padding:5px 10px;">
                        <i class="fa-solid fa-at"></i><%# Eval("UserNickname") %>
                    </div>
                    <div style="float:right; padding:5px 10px;">
                        <%# Eval("CommentDateTime") %>
                    </div>
                </div>
                <br />
                <div class="commnetCom">
                    <%# Eval("Commnet") %>
                </div>
                <div style="clear:both"></div>
            </div>
            <div class="accept" style="width:200px;">
            <asp:LinkButton ID="lbtn_deletecitation" runat="server" CssClass="rejectbutton" OnClick="lbtn_deletecitation_Click">Reddet</asp:LinkButton>
        </div>
            <div style="clear:both"></div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
