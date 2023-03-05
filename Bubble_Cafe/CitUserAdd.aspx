<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CitUserAdd.aspx.cs" Inherits="Bubble_Cafe.CitUserAdd" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnl_login" runat="server" Visible="false" CssClass="user">
        <div class="frame">
            <asp:Panel ID="pnl_success" runat="server" Visible="false" CssClass="success">Alıntı Yapma Başarılı</asp:Panel>
            <asp:Panel ID="pnl_fail" runat="server" Visible="false" CssClass="fail">
                <asp:Label ID="lbl_message" runat="server"></asp:Label>
            </asp:Panel>
            <div style="width: 50%; float: left;">
                <div class="row">
                    <asp:DropDownList ID="ddl_addCitCategory" runat="server" CssClass="textbox" AppendDataBoundItems="true">
                        <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_addCitBookName" runat="server" CssClass="textbox" placeholder="Kitap Adını Giriniz"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_addCitWriterName" runat="server" CssClass="textbox" Width="200px" placeholder="Yazar Adını Giriniz"></asp:TextBox>
                    <asp:TextBox ID="tb_addCitWriterSurname" runat="server" CssClass="textbox" Width="200px" placeholder="Yazar Soyadını Giriniz"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_addCitPage" runat="server" CssClass="textbox" placeholder="Alıntı Sayfasını Giriniz"></asp:TextBox>
                </div>
                <div class="row">
                    Alıntı Yap
                <br />
                    <asp:TextBox ID="tb_addCitation" runat="server" TextMode="MultiLine" CssClass="textbox" Height="350px" Width="500px"></asp:TextBox>
                </div>
            </div>
            <div style="width: 50%; float: right;">
                <div class="row">
                    <asp:TextBox ID="tb_addCitPublisher" runat="server" CssClass="textbox" placeholder="Yayınevi Adını Giriniz"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_addCitReleaseDate" runat="server" CssClass="textbox" placeholder="Basım Tarihini Giriniz"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_addCitPageBook" runat="server" CssClass="textbox" placeholder="Kitap Sayfasını Giriniz"></asp:TextBox>
                </div>
                <div class="row">
                    Yorum ve Düşündükleriniz
                <br />
                    <asp:TextBox ID="tb_addOpinion" runat="server" TextMode="MultiLine" CssClass="textbox" Height="250px" Width="500px"></asp:TextBox>
                </div>
                <div class="row" style="padding-top: 40px;">
                    <asp:LinkButton ID="lbtn_addCitation" runat="server" CssClass="editLinkButton" OnClick="lbtn_addCitation_Click">Alıntı Yap</asp:LinkButton>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnl_notlogin" runat="server" Visible="true" CssClass="user">
        <div class="letter">
            <h2>
                Lütfen Üye Girişi Yapınız!
            </h2>
        </div>
    </asp:Panel>
</asp:Content>
