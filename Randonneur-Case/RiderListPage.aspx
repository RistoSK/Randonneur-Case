<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiderListPage.aspx.cs" Inherits="RiderListPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Rider List - DWA Model Case</title>
    <style type="text/css">
        .detail_textbox {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Rider Lists</h1>
                </div>

                <div id="div_header_LOGIN_STATUS">
                    <asp:Label ID="lbLoginInfo" runat="server"></asp:Label>.<br />
                    <asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click" CausesValidation="False">LOGOUT</asp:LinkButton>
                </div>
            </div>



            <div id="div_LEFT">
                <div id="div_NAV">



            <div id="div_LEFT0">
                <div id="div_NAV0">
                    <asp:HyperLink ID="hyperLinkHomePage" runat="server" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLinkRiderList" runat="server" CssClass="current_page_link" NavigateUrl="~/RiderListPage.aspx">Rider Lists</asp:HyperLink>
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



                </div>
            </div>



            <div id="div_CENTER">
                <div class="div_center_HEADER">
                    Select a Brevet</div>

                <div id="div_center_LISTBOX">
                    <asp:ListBox ID="listBoxBrevets" runat="server" AutoPostBack="True" CssClass="listbox_main" OnSelectedIndexChanged="listBoxBrevets_SelectedIndexChanged"></asp:ListBox>
                </div>

                <div id="div_center_IMAGE">
                    <img id="main_image" src="images/brevet.png" alt="Brevet manegement image" />
                </div>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Rider List</div>

                <!-- End of div_right_DETAILS -->


                <!-- End of div_right_VALIDATORS -->
                <asp:ListBox ID="ListBoxRiderList" runat="server" Height="456px"  Width="452px"></asp:ListBox>
            </div>
            <!-- End of div_RIGHT -->



              <div id="div_FOOTER">
                <div id="div_footer_W3C_ICONS">
                    <a href="http://validator.w3.org/check?uri=referer">
                        <img class="w3c_icon" src="images/valid-xhtml10.png" alt="Valid XHTML 1.0 Transitional" /></a>
                    <a href="http://jigsaw.w3.org/css-validator/">
                        <img class="w3c_icon" src="images/vcss.png" alt="Valid CSS!" /></a>
                </div>

                <div id="div_footer_AUTHOR">
                    Student Name 2014 v1.0
                </div>
            </div>


        </div>
        <!-- End of div_CONTAINER -->
    </form>
</body>
</html>
