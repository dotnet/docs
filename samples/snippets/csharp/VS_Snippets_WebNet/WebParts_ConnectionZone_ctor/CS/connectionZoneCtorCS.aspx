<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register tagprefix="uc1" 
    tagname="DisplayModeMenuCS"
    src="~/displaymodemenucs.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void Page_Init(object sender, EventArgs e)
  {
    ConnectionsZone connZone = new ConnectionsZone();
    connZone.ID = "connectionsZone1";
    connZone.HeaderText = "Connections Zone 1";
    form1.Controls.AddAt(form1.Controls.Count - 1, connZone);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Connection Zone Sample</title>
</head>
<body>
  <form id="form1" runat="server">
  <asp:webpartmanager runat="server" id="mgr">
    <staticconnections>
      <asp:webpartconnection id="connection1" 
        consumerconnectionpointid="ZipCodeConsumer"
        consumerid="zipConsumer"
        providerconnectionpointid="ZipCodeProvider" 
        providerid="zipProvider" />
    </staticconnections>
  </asp:webpartmanager>
  <uc1:displaymodemenucs id="menu1" runat="server" />
  <div>
  <asp:webpartzone id="WebPartZone1" runat="server">
    <zonetemplate>
      <aspsample:zipcodewebpart id="zipProvider" runat="server" 
        Title="Zip Code Provider" />
      <aspsample:weatherwebpart id="zipConsumer" runat="server" 
        Title="Zip Code Consumer" />
    </zonetemplate>
  </asp:webpartzone>
  </div>
  </form>
</body>
</html>
<!-- </snippet1> -->