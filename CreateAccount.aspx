<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Salon_CRM.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <center>
            <br /><br />
            <asp:Label ID="Label1" CssClass="label label-primary" runat="server" Text="Create Account"></asp:Label>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="First Name: "></asp:Label><br />
            <asp:TextBox ID="TextBox_createaccount_firstname" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="Last Name: "></asp:Label><br />
            <asp:TextBox ID="TextBox_createaccount_lastname" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="TextBox_createaccount_email" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="TextBox_createaccount_password" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label_createaccount_info" runat="server" Visible="false" ForeColor="Red" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button_createaccount_signup" runat="server" Text="Sign Up" class="btn btn-success" OnClick="Button_signup_Click" />
        </center>
    </div>    
</asp:Content>
