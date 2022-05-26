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
                        <asp:Button ID="Button_services_select" runat="server"  Text="Select" BackColor="LimeGreen" ForeColor="White" CssClass="btn" OnClick="Button_services_select_Click" />            
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br /><br />        
        <asp:Button ID="Button_services_bookappointment" CssClass="btn btn-primary" runat="server" Enabled="false" Text="Book Appointment >>" OnClick="Button_services_bookappointment_Click" />
    </center>
</asp:Content>
