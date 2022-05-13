<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Salon_CRM.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <center>
            <br /><br />
            <asp:Label ID="Label1" runat="server" CssClass="label label-primary" Text="Login"></asp:Label>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label><br />
            <asp:TextBox ID="TextBox_login_email" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label><br />
            <asp:TextBox ID="TextBox_login_password" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />
            <asp:Button ID="Button_login_signup" runat="server" CssClass="btn btn-primary" Text="Sign In" />
            <br />
            <a runat="server" href= "~/CreateAccount">I do not have an account.</a>
        </center>
    </div>       
</asp:Content>
