<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Home Page - DWA Model Case</title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>HH Randonneurs</h1>
                </div>

                <div id="div_header_LOGIN_STATUS">
                    <asp:Label ID="lbLoginInfo" runat="server"></asp:Label>.<br />
                    <asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click">LOGOUT</asp:LinkButton>
                </div>
            </div>



            <div id="div_LEFT">
                <div id="div_NAV">
                    <asp:HyperLink ID="hyperLinkHomePage" runat="server" CssClass="current_page_link" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLinkRiderList" runat="server" NavigateUrl="~/RiderListPage.aspx">Rider Lists</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLinkBrevetResults" runat="server">Brevet Results</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLinkBrevetRegistration" runat="server">Brevet Registration</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLinkBrevetManagent" runat="server" NavigateUrl="~/BrevetManagementPage.aspx">Brevet Management</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLinkRiderManagement" runat="server">Rider Management</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLinkClubManagement" runat="server" NavigateUrl="~/ClubManagementPage.aspx">Club Management</asp:HyperLink>
&nbsp;<br />
                    <br />
                    <asp:HyperLink ID="HyperLinkUpdateResults" runat="server">Update Results</asp:HyperLink>
                    <br />
                </div>
            </div>



            <div id="div_CENTER">
                Welcome to HH Randonneurs home page!<br />
                <br />
                <img src="images/brevet_rider.png" alt="Team image" /><br />
                <br />
                HH Randonncurs organize annual Super<br />
                Randonneur series of 200, 300, 400 and
                <br />
                600km brevets. In addition, we organize
                <br />
                1000 and 1200km brevets when possible.<br />
                <br />
                Whichever brevet you choose, we&#39;ll make it
                <br />
                an unforgettable ride<br />
                <br />
                <br />
            </div>



            <div id="div_RIGHT">
                You can view rider lists and brevet results without logging in.<br />
                <br />
                Login is required for brevet registrations.<br />
                Pre-registration for brevets is accepted up to one week before the
                <br />
                event.<br />
                <br />

                <asp:Panel ID="panelLogin" runat="server" GroupingText="Login" CssClass="loginPanel">
                    <asp:Label ID="lbUsername" runat="server" EnableViewState="False" Text="Username:"></asp:Label><br />
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="loginTextBox"></asp:TextBox><br />
                    <asp:Label ID="lbPassword" runat="server" Text="Password:"></asp:Label><br />
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="loginTextBox"></asp:TextBox><br />
                    <asp:Button ID="btLogin" runat="server" EnableTheming="False" Text="Login" OnClick="btLogin_Click" CssClass="loginButton" />
                </asp:Panel>

                <br />
                Links<br />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://en.wikipedia.org/wiki/Brevet">https://en.wikipedia.org/wiki/Brevet (cycling)</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="https://en.wikipedia.org/wiki/Paris-Brest-Paris">https://en.wikipedia.org/wiki/Paris-Brest-Paris</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.randonneurs.fi/">http://www.randonneurs.fi/</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.rusa.org/">http://www.rusa.org/</asp:HyperLink>
                <br />
                <br />
                <asp:Label ID="lbMessage" runat="server"></asp:Label>
                <br />
                <br />
                <br />
                <br />
            </div>



            <div id="div_FOOTER">
                <div id="div_footer_W3C_ICONS">
                    <a href="http://validator.w3.org/check?uri=referer">
                        <img class="w3c_icon" src="images/valid-xhtml10.png" alt="Valid XHTML 1.0 Transitional" /></a>
                    <a href="http://jigsaw.w3.org/css-validator/">
                        <img class="w3c_icon" src="images/vcss.png" alt="Valid CSS!" /></a>
                </div>

                <div id="div_footer_AUTHOR">
                    Risto Sardis Karhunen 2015 v1.0 </div>
            </div>


        </div>
        <!-- End of div_CONTAINER -->
    </form>
</body>
</html>
