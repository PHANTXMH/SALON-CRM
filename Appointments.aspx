<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="Salon_CRM.Appointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Make new Appointment " OnClick="Button1_Click" />
    <center>
        <br /><br />
        <asp:Label ID="Label1" runat="server" CssClass="label label-primary" Text="Appointments"></asp:Label>
        <br /><br />        
        <asp:Label ID="Label_firstname_appointment" style="font-family:'Brush Script MT'; font-size:2em;" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label_lastname_appointment" style="font-family:'Brush Script MT'; font-size:2em;" runat="server" ></asp:Label>
        <br /><br />
        <asp:Label ID="Label2" runat="server" CssClass="label label-success" Text="Pending Appointments"></asp:Label>
        <br />
        <asp:GridView ID="GridView_pending_appointments" runat="server"  AutoGenerateColumns="false"  CssClass="table table-bordered table-striped col-auto justify-content-center">
            <Columns>               
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataFormatString = "{0:MMM dd, yyyy}" DataField="appointmentdate" HeaderText="DATE" HeaderStyle-CssClass="labelstuff" />     
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="appointmenttime" DataFormatString = "{0:hh\:mm}" HeaderText="TIME" HeaderStyle-CssClass="labelstuff" />                
            </Columns>
        </asp:GridView>  
        <br /><br />
        <asp:Label ID="Label3" runat="server" CssClass="label label-info" Text="Bookings"></asp:Label>
        <br /><br />        
        <asp:GridView ID="GridView_appointment_new_bookings" runat="server" AutoGenerateColumns="false" class="table table-bordered table-striped col-auto justify-content-center">
            <Columns>             
                <asp:BoundField DataField="id"/>
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="servicename" HeaderText="SERVICES" HeaderStyle-CssClass="labelstuff" />
                <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="servicecost" HeaderText="COST ($JMD)" HeaderStyle-CssClass="labelstuff" />     
                <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                           <asp:Button ID="Button_appointments_remove_bookings" runat="server" CssClass="btn btn-danger" Text="Remove" OnClick="Button_appointments_remove_bookings_Click" />         
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </center>      
    <asp:Label ID="Label4" runat="server" CssClass="label label-info" Text="Total: "></asp:Label>  
    <asp:TextBox ID="TextBox_appointment_total" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
    <br /><br />
     <asp:Label ID="Label5" runat="server" CssClass="label label-info" Text="Select Date and Time"></asp:Label>
    <center>       
        <asp:Calendar ID="Calendar_appointment" runat="server"></asp:Calendar><br />
        <asp:DropDownList ID="DropDownList_appointment_time_selection" CssClass="form-control" runat="server"></asp:DropDownList>
        <br /><br />
        <asp:Label ID="Label_confirm_button_info" runat="server" Visible="false" ForeColor="Red" Text="Label"></asp:Label><br />
        <asp:Button ID="Button_appointment_confirm" runat="server" CssClass="btn btn-success" Text="Confirm Appointment" OnClick="Button_appointment_confirm_Click" />
    </center>
</asp:Content>
