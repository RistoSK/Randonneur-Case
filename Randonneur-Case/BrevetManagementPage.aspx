<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrevetManagementPage.aspx.cs" Inherits="BrevetManagementPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Brevet Management - DWA Model Case</title>
    <style type="text/css">
        .detail_textbox {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Brevet Management</h1>
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
                    <asp:HyperLink ID="HyperLinkRiderList" runat="server">Rider Lists</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLinkBrevetResults" runat="server">Brevet Results</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLinkBrevetRegistration" runat="server">Brevet Registration</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLinkBrevetManagent" runat="server" NavigateUrl="~/BrevetManagementPage.aspx" CssClass="current_page_link">Brevet Management</asp:HyperLink>
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
                    Brevets</div>

                <div id="div_center_LISTBOX">
                    <asp:ListBox ID="listBoxBrevets" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listBoxClubs_SelectedIndexChanged" CssClass="listbox_main"></asp:ListBox>
                </div>

                <div id="div_center_IMAGE">
                    <img id="main_image" src="images/brevet.png" alt="Brevet manegement image" />
                </div>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Brevet Details
                </div>

                <div id="div_right_DETAILS">

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbBrevetId" runat="server" Text="Brevet ID :" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbID" runat="server" CssClass="detail_textbox" MaxLength="4"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorClubid"
                            runat="server" ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbID" CssClass="validatorMessage"></asp:RequiredFieldValidator>
                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbDistance" runat="server" Text="Distance :" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbDistance" runat="server" CssClass="detail_textbox" MaxLength="50"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbDistance" CssClass="validatorMessage"></asp:RequiredFieldValidator>
                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbDate" runat="server" Text="Date :" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbDate" runat="server" CssClass="detail_textbox" MaxLength="10"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbDate" CssClass="validatorMessage"></asp:RequiredFieldValidator>
                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbLocation" runat="server" Text="Location :" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbLocation" runat="server" CssClass="detail_textbox" MaxLength="100"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbLocation" CssClass="validatorMessage"></asp:RequiredFieldValidator>
                    </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbClimbing" runat="server" Text="Climbing :" CssClass="detail_label"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tbClimbing" runat="server" CssClass="detail_textbox" MaxLength="10" Width="251px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbClimbing" CssClass="validatorMessage"></asp:RequiredFieldValidator>
                </div>
                <!-- End of div_right_DETAILS -->


                <div id="div_right_BUTTONS">
                    <asp:Button ID="btNew" runat="server" Text="New" OnClick="btNew_Click" CausesValidation="False" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btAdd" runat="server" Text="Add" OnClick="btAdd_Click" CausesValidation="True" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btUpdate" runat="server" Text="Update" OnClick="btUpdate_Click" CausesValidation="True" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btDelete" runat="server" Text="Delete" OnClick="btDelete_Click" CausesValidation="False" CssClass="div_right_buttons_button" />
                </div>


                <div id="div_right_VALIDATORS">
                    <div>
                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                    </div>

                    <asp:RangeValidator ID="RangeValidator_ClubID" runat="server"
                        ControlToValidate="tbDistance" ErrorMessage="Distance should be either 200, 300, 400, 600, 1000 , 1200"
                        Type="Integer" MinimumValue="10" MaximumValue="9999"
                        SetFocusOnError="True" CssClass="validatorMessage"></asp:RangeValidator>
                    <br />

                    <asp:RangeValidator ID="RangeValidator_Climbing" runat="server"
                        ControlToValidate="tbClimbing" ErrorMessage="Climbing should be between 0 and 99999"
                        Type="Integer" MinimumValue="0" MaximumValue="100000"
                        SetFocusOnError="True" CssClass="validatorMessage"></asp:RangeValidator>
                    <br />
                    <br />

                </div>
                <!-- End of div_right_VALIDATORS -->
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
