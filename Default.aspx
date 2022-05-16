<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Salon_CRM._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div ID="banner" class="jumbotron">
        <h1>Beauty Matters</h1>
        <p class="lead">Welcome to Beauty Matters, where your beauty matters to us!</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Book Appointment &raquo;</a></p>
    </div>

    <div id="Opening Hours" class="row">
        <div class="col-md-4">
            <h2>Opening Hours</h2>
            <asp:Table ID="Table_Opening_Hours" runat="server" CellPadding="10" GridLines="Both" CssClass="table table-bordered table-striped">                
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label_sunday" runat="server" Text="Sunday"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label_sunday_time" runat="server" Text="11:00 am to 5:00 pm"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label_monday" runat="server" Text="Monday"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label_monday_time" runat="server" Text="9:00 am to 6:00 pm"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label_tuesday" runat="server" Text="Tuesday"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label_tuesday_time" runat="server" Text="9:00 am to 6:00 pm"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label_wednesday" runat="server" Text="Wednesday"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label_wednesday_time" runat="server" Text="9:00 am to 6:00 pm"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label_thursday" runat="server" Text="Thursday"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label_thursday_time" runat="server" Text="9:00 am to 6:00 pm"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label_friday" runat="server" Text="Friday"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label_friday_time" runat="server" Text="9:00 am to 4:00 pm"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label_saturday" runat="server" Text="Saturday"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label_saturday_time" runat="server" Text="CLOSED"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>           
        </div>

        <div id="Services" class="col-md-4">
            <h2>Services</h2>
            <asp:Table ID="Table_services" runat="server" CellPadding="10" GridLines="Both" CssClass="table table-bordered table-striped">
                <asp:TableRow>
                    <asp:TableCell>
                        Top Services
                    </asp:TableCell>
                    <asp:TableCell>
                        Prices
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Shampoo, Color and Treatment
                    </asp:TableCell>
                    <asp:TableCell>
                        $8,500
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>
                        Shampoo and Color
                    </asp:TableCell>
                    <asp:TableCell>
                        $8,000
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>
                        Relaxer Color and Cut
                    </asp:TableCell>
                    <asp:TableCell>
                        $13,000
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>
                        Relaxer and Treat
                    </asp:TableCell>
                    <asp:TableCell>
                        $8,000
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>
                        Cut and Curl
                    </asp:TableCell>
                    <asp:TableCell>
                        $2,500
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>
                        Shampoo Set
                    </asp:TableCell>
                    <asp:TableCell>
                        $3,500
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>            
            <p>
                <a class="btn btn-primary" runat="server" href="~/Services">Services &raquo;</a>
            </p>
        </div>

        <div class="col-md-4">
            <h2>Gallery</h2>
            <asp:Image ID="Image_homepage" runat="server" />
            <br /><br />
            <asp:Button ID="Button_homepage_gallery_previous" class="btn btn-primary" runat="server" Text=" < " OnClick="Button_homepage_gallery_previous_Click" />
            <asp:Button ID="Button_homepage_gallery_next" class="btn btn-primary" runat="server" Text=" > " OnClick="Button_homepage_gallery_next_Click" />
        </div>
    </div>
</asp:Content>
