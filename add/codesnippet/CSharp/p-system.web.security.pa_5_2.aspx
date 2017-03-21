<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Runtime.InteropServices" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        try 
        {
            // Determine whether Passport is the type of authentication
            // this page is set to use. (Authentication information
            // is set in the Web.config file.)
            if (!(this.Context.User.Identity is PassportIdentity))
            {
                // If this page isn't set to use Passport authentication,
                // quit now.
                this.Response.Write("Error: Passport authentication failed. " + 
                    "Make sure that the Passport SDK is installed " +
                    "and your Web.config file is configured correctly.");
                return;
            }

            // Expire the page to avoid the browser's cache.
           Response.Cache.SetNoStore(); 


            // Get a version of the Identity value that is cast as type
            // PassportIdentity. 
            PassportIdentity identity = (this.Context.User.Identity as PassportIdentity);    
            // Determine whether the user is already signed in with a valid
            // and current ticket. Passing -1 for the parameter values 
            // indicates the default values will be used.
            if (identity.GetIsAuthenticated(-1, -1, -1))
            {
                this.Response.Write("Welcome to the site.<br /><br />");
                // Print the Passport sign in button on the screen.
                this.Response.Write(identity.LogoTag2());
                // Make sure the user has core profile information before
                // trying to access it.
                if (identity.HasProfile("core"))
                {
                    this.Response.Write("<b>You have been authenticated as " + 
                        "Passport identity:" + identity.Name + "</b></p>");
                }
            }
    
            // Determine whether the user has a ticket.
            else if (identity.HasTicket)
            {
                // If the user has a ticket but wasn't authenticated, that 
                // means the ticket is stale, so the login needs to be refreshed.
                // Passing true as the fForceLogin parameter value indicates that 
                // silent refresh will be accepted.
                identity.LoginUser(null, -1, true, null, -1, null, -1, true, null);
            }

            // If the user does not already have a ticket, ask the user
            // to sign in.
            else
            {
                this.Response.Write("Please sign in using the link below.<br /><br />");
                // Print the Passport sign in button on the screen.
                this.Response.Write(identity.LogoTag2());
            }
        }
        catch (System.Runtime.InteropServices.COMException comError)
        {
            this.Response.Write("An error occured while working with the " +
                "Passport SDK.");
        }
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>ASP.NET Example</title>
</head>
    <body>
        <form id="form1" runat="server">
        </form>
    </body>
</html>