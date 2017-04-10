using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.Text;
using System.Collections.Specialized;

public partial class FormsAuthenticationConfiguration_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    // Access the AuthenticationSection section to get 
    // the current cookie name.
    protected void GetCookieName()
    {
              
        StringBuilder buffer = new StringBuilder();

        try
        {

	    // <Snippet21>
            // Get the configuration file. Replace the name configTarget
            // with the name of your site.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration("/configTarget");


            // Get the external Authentication section.
            AuthenticationSection authenticationSection =
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");

            // Get the external Forms section .
            FormsAuthenticationConfiguration formsAuthentication =
              authenticationSection.Forms;

            string cookieName = formsAuthentication.Name;
            // </Snippet21>
  
            buffer.AppendLine(String.Format("Cookie name: {0} <br/>", cookieName));
            
            // Display cookie name
            // Label1.Text = buffer.ToString();
        }
        catch (ConfigurationErrorsException e)
        {
            buffer.AppendLine(String.Format("[Accessing AuthenticationSection: {0}]",
                e.ToString()));
            // Display error.
            // Label1.Text = buffer.ToString();
        }

    }

  
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetCookieName();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // Label1.Text = "[Cookie name goes here]";
    }
}