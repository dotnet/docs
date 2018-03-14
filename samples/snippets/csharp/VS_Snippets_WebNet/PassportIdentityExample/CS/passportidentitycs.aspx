<!-- <Snippet1> -->
<!-- 
This example demonstrates implementing the soft sign-in authentication approach. 
In order for the example to work, the following requirements must be met. 
You can find details on these requirements in the Passport SDK documentation.

1. You must modify the Web.config file associated with this page so that 
authentication mode is set to "Passport".
2. You must have the Passport SDK installed.
3. You must have a Passport Site ID for the site where your page resides. 
If your Site ID is in the PREP environment, you will also need a PREP Passport.
4. You must have installed the encryption key you received after registering 
your site and receiving a site ID.
5. You must have the Passport Manager object settings correctly configured for 
your site.
-->

<!-- </Snippet1> -->
<!-- <Snippet2> -->
<!-- To view this code example in a fully-working sample, see the 
PassportIdentity Class topic. -->

<!-- </Snippet2> -->

<!-- <Snippet3> -->
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
//<Snippet4>
//<Snippet5>
//<Snippet6>
            PassportIdentity identity = (this.Context.User.Identity as PassportIdentity);    
            // Determine whether the user is already signed in with a valid
            // and current ticket. Passing -1 for the parameter values 
            // indicates the default values will be used.
            if (identity.GetIsAuthenticated(-1, -1, -1))
            {
                this.Response.Write("Welcome to the site.<br /><br />");
                // Print the Passport sign in button on the screen.
                this.Response.Write(identity.LogoTag2());
//</Snippet6>
                // Make sure the user has core profile information before
                // trying to access it.
                if (identity.HasProfile("core"))
                {
                    this.Response.Write("<b>You have been authenticated as " + 
                        "Passport identity:" + identity.Name + "</b></p>");
                }
            }
//</Snippet5>            
    
            // Determine whether the user has a ticket.
            else if (identity.HasTicket)
            {
                // If the user has a ticket but wasn't authenticated, that 
                // means the ticket is stale, so the login needs to be refreshed.
                // Passing true as the fForceLogin parameter value indicates that 
                // silent refresh will be accepted.
                identity.LoginUser(null, -1, true, null, -1, null, -1, true, null);
            }
//</Snippet4>

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
<!-- </Snippet3> -->
