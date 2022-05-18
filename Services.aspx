<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="Salon_CRM.Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <center>
        <asp:Label ID="Label1" CssClass=" label label-primary" runat="server" Text="Services"></asp:Label>
        <br /><br />
       
        <asp:GridView ID="GridView_services" runat="server"  AutoGenerateColumns="false"  CssClass="table table-bordered table-striped col-auto justify-content-center">
            <Columns>             
                <asp:BoundField DataField="id"/>
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="servicename" HeaderText="SERVICES" HeaderStyle-CssClass="labelstuff" />
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="servicecost" HeaderText="COST ($JMD)" HeaderStyle-CssClass="labelstuff" />     
                <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                         <asp:Button ID="Button_services_select" runat="server" Text="Select" CssClass="btn btn-success" OnClick="Button_services_select_Click" />        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br /><br />
        <asp:Label ID="Label2" runat="server" CssClass="label label-info" Text="Selected Services: "></asp:Label><br />
        <asp:TextBox ID="TextBox_services" CssClass="form-group" runat="server" Width="1414px"></asp:TextBox>
        <br /><br />
        <asp:Button ID="Button_services_bookappointment" CssClass="btn btn-primary" runat="server" Text="Book Appointment >>" />
    </center>
</asp:Content>
