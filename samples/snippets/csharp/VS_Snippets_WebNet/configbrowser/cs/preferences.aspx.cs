using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preferences : System.Web.UI.Page
{
    // <Snippet110>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Heading"] != null)
        {
            HeadingTextBox.Text = Session["Heading"].ToString();
        }

        if (Session["Path"] != null)
        {
            VirtualPathTextBox.Text = Session["Path"].ToString();
        }

        if (Session["Site"] != null)
        {
            SiteNameTextBox.Text = Session["Site"].ToString();
        }

        if (Session["SubPath"] != null)
        {
            SubPathTextBox.Text = Session["SubPath"].ToString();
        }

        if (Session["Server"] != null)
        {
            ServerTextBox.Text = Session["Server"].ToString();
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid != true)
        {
            ConfigFileRequiredFieldValidator.Visible = true;
        }
        else
        {
            Session["Heading"] = HeadingTextBox.Text;
            Session["Path"] = VirtualPathTextBox.Text;
            Session["Site"] = SiteNameTextBox.Text;
            Session["SubPath"] = SubPathTextBox.Text;
            Session["Server"] = ServerTextBox.Text;
            Server.Transfer("~/Default.aspx");
        }
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Default.aspx");
    }
    // </Snippet110>
}