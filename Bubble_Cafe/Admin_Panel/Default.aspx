<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="float: left; margin-bottom: 20px;">
            <h3>Onay Bekleyen Alıntılar</h3>
            <asp:Repeater ID="rp_citationsAdmin" runat="server">
                <ItemTemplate>
                    <a href='CitationMoreDetail.aspx?citid=<%# Eval("ID") %>'>
                        <div class="citationDiv">
                            <div class="picture">
                                <img src='../ImageSource/<%# Eval("BookImage") %>' style="width: 260px" />
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
        </div>
        <br />
        <div style="clear:both">
            <h3>Onay Bekleyen Yorumlar</h3>
            <asp:Repeater ID="rp_commentaccept" runat="server">
                <ItemTemplate>
                    <a href='CommentMoreDetail.aspx?comid=<%# Eval("ID") %>'>
                        <div class="commentframe">
                            <div class="usercomment">
                                <div style="float: left; padding: 5px 10px;">
                                    <i class="fa-solid fa-at"></i><%# Eval("UserNickname") %>
                                </div>
                                <div style="float: right; padding: 5px 10px;">
                                    <%# Eval("CommentDateTime") %>
                                </div>
                            </div>
                            <br />
                            <div class="commnetCom">
                                <%# Eval("Commnet") %>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
