/* *************************************************************************
 * HomePage.cs   Original version: Kari Silpiö 20.3.2014 v1.0
 *               Modified by: Risto Sardis Karhunen 
 * -------------------------------------------------------------------------
 *  Application: DWA Model Case
 *  Class:       Code-behind class for the ASPX page HomePage.aspx
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by: Risto Sardis Karhunen"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
    }



    /* **********************************************************************
    * LOGIN MANAGEMENT CODE 
    * - This is the special code for the HOME PAGE only! 
    * - DO NOT change anything else but the HyperLink controls here!
    *   HyperLink controls are managed under comments (1), (2), and (3)
    *********************************************************************** */
    private void checkLogin()
    {
        Response.Cache.SetNoStore();   // Should disable browser's Back Button

        // (1) Hide all hyperlinks that are available for autenthicated users only
        HyperLinkBrevetRegistration.Visible = false;
        HyperLinkBrevetManagent.Visible = false;
        HyperLinkRiderManagement.Visible = false;
        HyperLinkClubManagement.Visible = false;
        HyperLinkUpdateResults.Visible = false;

       

        if (Session["username"] == null)
        {
            lbLoginInfo.Text = "You are not logged in";
            btLogout.Visible = false;
        }

        if (Session["username"] != null)
        {

            lbLoginInfo.Text = "You are logged in as " + Session["username"];
            btLogout.Visible = true;

            // (2) Show all hyperlinks that are available for autenthicated users only
            HyperLinkBrevetRegistration.Visible = true;
        }

        if (Session["administrator"] != null)
        {
            // (3) In addition, show all hyperlinks that are available for administrators only
            HyperLinkBrevetManagent.Visible = true;
            HyperLinkRiderManagement.Visible = true;
            HyperLinkClubManagement.Visible = true;
            HyperLinkUpdateResults.Visible = true;
        }
    }

    /// <summary>
    /// btLogin_Click: DO LOGIN
    /// </summary>
    protected void btLogin_Click(object sender, EventArgs e)
    {
        LoginDAO loginDAO = new LoginDAO();
        LoginRole loginRole;      
        loginRole = loginDAO.GetLoginRole(tbUsername.Text, tbPassword.Text);

        if (loginRole.Role == null)
        {
            lbMessage.Text = "Username/password do not match. Try again.";
        }

        if (loginRole.Role != null)
        {
            Session["username"] = tbUsername.Text;

            if (loginRole.Role == "administrator")
            {
                Session["administrator"] = tbUsername.Text;
            }

            lbMessage.Text = "";
            Page.Response.Redirect("HomePage.aspx");
        }
    }

    /// <summary>
    /// btLogin_Click: DO LOGOUT
    /// </summary>
    protected void btLogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["administrator"] = null;
        Page.Response.Redirect("HomePage.aspx");
    }
    /* LOGIN MANAGEMENT code ends here  */
}
// End
