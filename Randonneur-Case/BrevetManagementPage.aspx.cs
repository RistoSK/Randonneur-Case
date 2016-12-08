/* **************************************************************************
 * DepartmentManagementPage.cs  Original version: Kari Silpiö 18.3.2014 v1.0
 *                              Modified by     : Risto Sardis Karhunen 
 * -------------------------------------------------------------------------
 *  Application: DWA Model Case
 *  Class:       Code-behind class for DepartmentManagementPage.aspx
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by: Risto Sardis Karhunen"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************** */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class BrevetManagementPage : System.Web.UI.Page
{
    private BrevetDAO BrevetDAO = new BrevetDAO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true); // true = login is required for accessing this page

        if (this.IsPostBack == false)
        {
            viewStateNew();
            createBrevetList(); // Populate Department List for the first time
        }

        addButtonScripts();
    }
    
    private void addButtonScripts()
    {
        btDelete.Attributes.Add("onclick",
          "return confirm('Are you sure you want to delete the data?');");
    }

    private void createBrevetList()
    {
        List<Brevet> BrevetList = BrevetDAO.GetAllBrevetsOrderedByName();

        listBoxBrevets.Items.Clear();
        if (BrevetList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Brevet brevet in BrevetList)
            {
                String text = brevet.Location;
                ListItem listItem = new ListItem(text, "" + brevet.BrevetId);
                listBoxBrevets.Items.Add(listItem);
            }
        }
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Brevet brevet = screenToModel();
        int insertOk = BrevetDAO.InsertBrevet(brevet);

        if (insertOk == 0) // Insert succeeded
        {
            createBrevetList();
            listBoxBrevets.SelectedValue = brevet.BrevetId.ToString();
            viewStateDetailsDisplayed();
            showNoMessage();
        }
        else if (insertOk == 1)
        {
            showErrorMessage("Brevet id " + brevet.BrevetId +
              " is already in use. No record inserted into the database.");
            tbID.Focus();
        }
        else
        {
            showErrorMessage("No record inserted into the database. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        int BrevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);
        int deleteOk = BrevetDAO.DeleteBrevet(BrevetId);

        if (deleteOk == 0) // Delete succeeded
        {
            createBrevetList();
            viewStateNew();
            showNoMessage();
        }
        else if (deleteOk == 1)
        {
            showErrorMessage("No record deleted. " +
              "Please delete the brevet's id first.");
        }
        else
        {
            showErrorMessage("No record deleted. " +
             "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void btNew_Click(object sender, EventArgs e)
    {
        viewStateNew();
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        Brevet brevet = screenToModel();
        int updateOk = BrevetDAO.UpdateBrevet(brevet);

        if (updateOk == 0) // Update succeeded
        {
            String selectedValue = listBoxBrevets.SelectedValue;

            createBrevetList();
            listBoxBrevets.SelectedValue = selectedValue;
            showNoMessage();
        }
        else
        {
            showErrorMessage("No record updated. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void listBoxClubs_SelectedIndexChanged(object sender, EventArgs e)
    {
        int BrevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);
        Brevet brevet = BrevetDAO.GetBrevetByBrevetId(BrevetId);

        if (brevet != null)
        {
            modelToScreen(brevet);
            viewStateDetailsDisplayed();
            showNoMessage();
        }
    }

    private void modelToScreen(Brevet brevet)
    {
        tbID.Text = "" + brevet.BrevetId;
        tbLocation.Text = brevet.Location;
        tbClimbing.Text = brevet.Climbing.ToString();
        tbDistance.Text = brevet.Distance.ToString();
        tbDate.Text = brevet.Date.ToString("yyyy-MM-dd"); ;
    }

    private void resetForm()
    {
        tbID.Text = "";
        tbLocation.Text = "";
        tbClimbing.Text = "";
        tbDistance.Text = "";
        tbDate.Text = "";    
    }

    private Brevet screenToModel()
    {
        Brevet brevet = new Brevet();
        brevet.BrevetId = Convert.ToInt32(tbID.Text.Trim());
        brevet.Location = tbLocation.Text.Trim();
        brevet.Climbing = Convert.ToInt32(tbClimbing.Text.Trim());
        brevet.Distance = Convert.ToInt32(tbDistance.Text.Trim());
        return brevet;
    }

    private void showErrorMessage(String message)
    {
        lbMessage.Text = message;
        lbMessage.ForeColor = System.Drawing.Color.Red;
    }

    private void showNoMessage()
    {
        lbMessage.Text = "";
        lbMessage.ForeColor = System.Drawing.Color.Black;
    }

    private void viewStateDetailsDisplayed()
    {
        tbID.Enabled = false;
        btAdd.Enabled = false;
        btDelete.Enabled = true;
        btNew.Enabled = true;
        btUpdate.Enabled = true;
    }

    private void viewStateNew()
    {
        tbID.Enabled = true;
        tbID.Focus();
        btAdd.Enabled = true;
        btDelete.Enabled = false;
        btNew.Enabled = true;
        btUpdate.Enabled = false;
        resetForm();
        listBoxBrevets.SelectedIndex = -1;
        showNoMessage();
    }


    /* **********************************************************************
    * LOGIN MANAGEMENT CODE 
    * - This is the special code to be used on your ASPX pages.
    * - DO NOT change anything else but the HyperLink controls here!
    *   HyperLink controls are managed under comments (1), (2), and (3)
    *********************************************************************** */
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
            HyperLinkRiderManagement.Visible = true ;
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
    /* LOGIN MANAGEMENT code ends here  */
}
// End
