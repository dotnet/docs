<!-- <snippet1> -->
<%@ Page Language="C#" %>

<%@ Import Namespace="System.Web.Configuration" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Text" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">
    public void Page_Load()
    {
        try
        {
            // Set the root path of the Web application that contains the
            // Web.config file that you want to access.
            string configPath = "/MyAppRoot";

            // Get the configuration object to access the related Web.config file.
            Configuration config = WebConfigurationManager.OpenWebConfiguration(configPath);

            // Get the object related to the <identity> section.
            IdentitySection section =
              (IdentitySection)config.GetSection("system.web/identity");

            // Read the <identity> section.
            StringBuilder identity = new StringBuilder();
            identity.Append("Impersonate: ");
            identity.Append(section.Impersonate.ToString());

            // Display the <identity> information.
            ConfigId.Text = identity.ToString();
        }
        catch (Exception e)
        {
            ConfigId.Text = e.ToString();
        }
    }
  </script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Read Configuration Settings</title>
</head>
<body>
    <h2>
        Read ASP.NET Configuration</h2>
    <p>
        This page displays the value of the <b>Impersonate</b> attribute of the <b>identity</b>
        section of an ASP.NET configuration.
    </p>
    <h3>
        Results</h3>
    <p>
        <asp:Label ID="ConfigId" BackColor="#dcdcdc" BorderWidth="1" runat="Server" /></p>
</body>
</html>
<!-- </snippet1> -->

