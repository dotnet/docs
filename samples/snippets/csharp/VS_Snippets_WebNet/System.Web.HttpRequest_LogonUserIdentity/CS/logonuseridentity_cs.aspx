<!--<snippet1>-->
<%@ Page Language="C#" %>
<%@ import Namespace="System.IO" %>

<script runat="server">
    
    /* NOTE: To use this sample, create a c:\temp  folder,
    *  add the ASP.NET account (in IIS 5.x <machinename>\ASPNET,
    *  in IIS 6.x NETWORK SERVICE), and give it write permissions
    *  to the folder.*/

    private const string INFO_DIR = @"c:\temp\";

    private void Page_Load(object sender, System.EventArgs e)
    {
        // Validate that user is authenticated
        if (!Request.LogonUserIdentity.IsAuthenticated)
            Response.Redirect("LoginPage.aspx");
        
        // Create a string that contains the file path
        string strFilePath = INFO_DIR + "CS_Log.txt";
        
        Response.Write("Writing log file to " + strFilePath + "...");
        
        // Create stream writer object and pass it the file path
        StreamWriter sw = File.CreateText(strFilePath);
        
        // Write user info to log
        sw.WriteLine("Access log from " + DateTime.Now.ToString());
        sw.WriteLine("User: " + Request.LogonUserIdentity.User);
        sw.WriteLine("Name: " + Request.LogonUserIdentity.Name);
        sw.WriteLine("AuthenticationType: " + Request.LogonUserIdentity.AuthenticationType);
        sw.WriteLine("ImpersonationLevel: " + Request.LogonUserIdentity.ImpersonationLevel);
        sw.WriteLine("IsAnonymous: " + Request.LogonUserIdentity.IsAnonymous);
        sw.WriteLine("IsGuest: " + Request.LogonUserIdentity.IsGuest);
        sw.WriteLine("IsSystem: " + Request.LogonUserIdentity.IsSystem);
        sw.WriteLine("Owner: " + Request.LogonUserIdentity.Owner);
        sw.WriteLine("Token: " + Request.LogonUserIdentity.Token);

        // Close the stream to the file.
        sw.Close();
    }  
</script>
<!--</snippet1>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
