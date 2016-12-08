/* **************************************************************************
 * DepartmentManagementPage.cs  Original version: Kari Silpiö 18.3.2014 v1.0
 *                              Modified by     : Risto Sardis Karhunen 
 * -------------------------------------------------------------------------
 *  Application: DWA Model Case
 *  Class:       Code-behind class for DepartmentManagementPage.aspx
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************** */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class RiderListPage : System.Web.UI.Page
{
    private BrevetDAO brevetDAO = new BrevetDAO();
    private BrevetRiderDAO brevetRiderDAO = new BrevetRiderDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true); // true = login is required for accessing this page

        if (this.IsPostBack == false)
        {
            populateBrevetList(); // Populate Department List for the first time
        }


    }
    private void createRiderBrevetList(int brevetId)
    {
        List<BrevetRider> brevetRiderList = brevetRiderDAO.GetRidersByBrevet(brevetId);

        listBoxBrevets.Items.Clear();
        {
            foreach (BrevetRider brevetRider in brevetRiderList)
            {
                String text = brevetRider.Rider.Surname + ", " + brevetRider.Rider.GivenName + ": " + brevetRider.Rider.Club;
                ListItem listItem = new ListItem(text);
                ListBoxRiderList.Items.Add(listItem);
            }
        }
    }


    protected void listBoxBrevets_SelectedIndexChanged(object sender, EventArgs e)
    {
        int brevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);
        createRiderBrevetList(brevetId);
    }
    private void populateBrevetList()
    {
        List<Brevet> brevetList = brevetDAO.GetAllBrevetsOrderedByName();

        listBoxBrevets.Items.Clear();
        {
            foreach (Brevet brevet in brevetList)
            {
                String text = brevet.Distance + " " + brevet.Date.ToString() + " " + brevet.Location;
                ListItem listItem = new ListItem(text, "" + brevet.BrevetId);
                listBoxBrevets.Items.Add(listItem);
            }
        }
    }

    private void checkLogin(bool loginRequired)
    {
        Response.Cache.SetNoStore();    // Should disable browser's Back Button

        // (1) Hide all hyperlinks that are available for autenthicated users only
        HyperLinkBrevetRegistration.Visible = false;
        HyperLinkBrevetManagent.Visible = false;
        HyperLinkRiderManagement.Visible = false;
        HyperLinkClubManagement.Visible = false;
        HyperLinkUpdateResults.Visible = false;

        if (loginRequired == true && Session["username"] == null)
        {
            Page.Response.Redirect("HomePage.aspx");  // Jump to the login page.
        }

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

    protected void btLogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["administrator"] = null;
        Page.Response.Redirect("HomePage.aspx");
    }
}
// End
