<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Panel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="BookAdd.aspx.cs" Inherits="Bubble_Cafe.Admin_Panel.BookAdd" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="frame">
        <h3 class="target">Kitap Ekle</h3>
        <asp:Panel ID="pnl_success" runat="server" Visible="false" CssClass="success">Kitap Ekleme Başarılı</asp:Panel>
        <asp:Panel ID="pnl_fail" runat="server" Visible="false" CssClass="fail">
            <asp:Label ID="lbl_message" runat="server"></asp:Label>
        </asp:Panel>
        <div style="float: left; width:49%;">
            <div class="raw">
                <label class="label">Kategoriler</label>
                <br />
                <asp:DropDownList ID="ddl_category" runat="server" CssClass="searchbox" AppendDataBoundItems="true">
                    <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="raw">
                 <label class="label">Kitap Adı</label>
                <br />
                <asp:TextBox ID="tb_addbook" runat="server" CssClass="searchbox"></asp:TextBox>
            </div>
            <div class="raw">
                 <label class="label">Yazar Adı ve Soyadı</label>
                <br />
                <asp:TextBox ID="tb_addwritername" runat="server" CssClass="searchbox"></asp:TextBox>
                <asp:TextBox ID="tb_addwritersurname" runat="server" CssClass="searchbox"></asp:TextBox>
            </div>
            <div class="raw">
                <label class="label">Yayınevi</label>
                <br />
                <asp:TextBox ID="tb_addpublisher" runat="server" CssClass="searchbox"></asp:TextBox>
            </div>
        </div>
        <div style="float: right; width:49%;">
            <div class="raw">
                <label class="label">Sayfa</label>
                <br />
                <asp:TextBox ID="tb_addpage" runat="server" CssClass="searchbox"></asp:TextBox>
            </div>
            <div class="raw">
                <label class="label">Basım Tarihi</label>
                <br />
                <asp:TextBox ID="tb_addreleaseData" runat="server" CssClass="searchbox"></asp:TextBox>
            </div>
            <div class="raw">
                <label class="label">Resim Ekle</label>
                <br />
                <asp:FileUpload ID="fu_addimage" runat="server"/>
            </div>
            <div class="raw" style="padding-top:40px;">
                <asp:LinkButton ID="lbtn_addBook" runat="server" CssClass="editLinkButton" OnClick="lbtn_addBook_Click">Kitap Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
