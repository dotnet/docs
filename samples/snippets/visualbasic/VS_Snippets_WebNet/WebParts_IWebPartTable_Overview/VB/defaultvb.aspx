<!--<SNIPPET1>-->
<%@ page language="VB" %>
<%@ Register tagprefix="ITable" 
    Namespace="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ITable Test Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:webpartmanager id="WebPartManager1" runat="server">
      <StaticConnections>
        <asp:WebPartConnection id="wp1" ProviderID="provider1" 
          ConsumerID="consumer1">
        </asp:WebPartConnection>
      </StaticConnections>
    </asp:webpartmanager>
    <asp:webpartzone id="WebPartZone1" runat="server">
      <zoneTemplate>
        <itable:TableProviderWebPart ID="provider1" runat="Server" 
          title="Web Parts Table Provider Control" />
        <itable:TableConsumer ID="consumer1" runat="Server" 
          title="Web Parts Table Consumer Control"/>
      </zoneTemplate>
    </asp:webpartzone>
    </div>
    </form>
</body>
</html>
<!--</SNIPPET1>-->