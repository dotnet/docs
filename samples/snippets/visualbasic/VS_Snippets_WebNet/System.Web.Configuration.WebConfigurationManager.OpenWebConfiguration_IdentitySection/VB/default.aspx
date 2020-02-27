<!-- <snippet1> -->

<%@ Page Language="VB" %>

<%@ Import Namespace="System.Web.Configuration" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Text" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Set the root path of the Web application that contains the
        ' Web.config file that you want to access.
        Dim configPath As String = "/MyAppRoot"
        
        ' Get the configuration object to access the related Web.config file.
        Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the object related to the <identity> section.
        Dim section As New IdentitySection
        section = config.GetSection("system.web/identity")
        
        ' Read the <identity> section.
        Dim identity As New StringBuilder
        identity.Append("Impersonate: ")
        identity.Append(section.Impersonate.ToString())

        ' Display the <identity> information.
        ConfigId.Text = identity.ToString()

    End Sub
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
