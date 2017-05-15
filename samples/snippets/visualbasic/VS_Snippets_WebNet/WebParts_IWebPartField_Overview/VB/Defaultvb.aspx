<!--<SNIPPET1>-->
<%@ page language="VB" debug="true" %>
<%@ Register tagprefix="IField" 
    Namespace="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!-- This code sample creates a page with two Web Parts controls 
and establishes a connection between the controls. -->
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IWebPartField Test Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:webpartmanager id="WebPartManager1" runat="server">
            <StaticConnections>
                <asp:WebPartConnection id="con1" ProviderID="provider1" 
                  ConsumerID="consumer1" 
                  ConsumerConnectionPointID="Connpoint1">
                </asp:WebPartConnection>
            </StaticConnections>
        </asp:webpartmanager>
        <asp:webpartzone id="WebPartZone1" runat="server">
            <zoneTemplate>
              <ifield:fieldproviderwebpart runat="Server" 
                ID="provider1" Title="Provider" />
              <ifield:fieldconsumerwebpart runat="Server" 
                ID="consumer1" Title="Consumer"/>
            </zoneTemplate>
        </asp:webpartzone>
    </div>
    </form>
</body>
</html>
<!--</SNIPPET1>-->