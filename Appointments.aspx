<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="Salon_CRM.Appointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <br /><br />
        <asp:Label ID="Label1" runat="server" CssClass="label label-primary" Text="Appointments"></asp:Label>
        <br /><br />        
        <asp:Label ID="Label_firstname_appointment" CssClass="h1" runat="server" Text="Jessica"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label_lastname_appointment" CssClass="h1" runat="server" Text="Skye"></asp:Label>
        <br /><br />
        <asp:Label ID="Label2" runat="server" CssClass="label label-info" Text="Pending Appointments"></asp:Label>
        <br />
        <asp:GridView ID="GridView_pending_appointments" runat="server"  AutoGenerateColumns="false"  CssClass="table table-bordered table-striped col-auto justify-content-center">
            <Columns>                
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="servicename" HeaderText="SERVICES" HeaderStyle-CssClass="labelstuff" />
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="appointmentdate" HeaderText="DATE" HeaderStyle-CssClass="labelstuff" />     
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="appointmenttime" HeaderText="TIME" HeaderStyle-CssClass="labelstuff" />                
            </Columns>
        </asp:GridView>
    </center>
</asp:Content>
