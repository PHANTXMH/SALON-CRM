<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Salon_CRM.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>        
        <br /><br />
        <asp:Label ID="Label1" runat="server" CssClass="label label-success" Text="Today's Appointments"></asp:Label>
        <br /><br />            
        <asp:GridView ID="GridView_dashboard_today_appointment" runat="server"  AutoGenerateColumns="false"  CssClass="table table-bordered table-striped col-auto justify-content-center">
            <Columns>     
                <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="Button_dashboard_view_services" runat="server"  Text="View" BackColor="dodgerblue" ForeColor="White" CssClass="btn" OnClick="Button_dashboard_view_services_Click"/>           
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id"/>
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="clientname" HeaderText="CLIENT'S NAME" HeaderStyle-CssClass="labelstuff" />
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="appointmenttime" DataFormatString = "{0:hh\:mm}" HeaderText="APPOINTMENT TIME" HeaderStyle-CssClass="labelstuff" />                
                <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                         <asp:Button ID="Button_dashboard_complete" runat="server"  Text="Completed" BackColor="LimeGreen" ForeColor="White" CssClass="btn" OnClick="Button_dashboard_complete_Click"  />           
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br /><br />
        <asp:GridView ID="GridView_dashboard_appointment_services" runat="server"  AutoGenerateColumns="false"  CssClass="table table-bordered table-striped col-auto justify-content-center">
            <Columns>                
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="servicename" HeaderText="SERVICES" HeaderStyle-CssClass="labelstuff" />                                            
            </Columns>
        </asp:GridView>
        <br /><br />
        <asp:Label ID="Label2" runat="server" CssClass="label label-info" Text="Upcoming Appointments"></asp:Label>
        <br /><br />
         <asp:GridView ID="GridView_dashboard_all_appointment" runat="server"  AutoGenerateColumns="false"  CssClass="table table-bordered table-striped col-auto justify-content-center">
            <Columns>    
                <asp:BoundField DataField="id"/>
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="clientname" HeaderText="CLIENT'S NAME" HeaderStyle-CssClass="labelstuff" />
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="appointmentdate" DataFormatString = "{0:MMM dd, yyyy}" HeaderText="APPOINTMENT DATE" HeaderStyle-CssClass="labelstuff" />
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="appointmenttime" DataFormatString = "{0:hh\:mm}" HeaderText="APPOINTMENT TIME" HeaderStyle-CssClass="labelstuff" />                            
            </Columns>
        </asp:GridView>
    </center>
</asp:Content>
