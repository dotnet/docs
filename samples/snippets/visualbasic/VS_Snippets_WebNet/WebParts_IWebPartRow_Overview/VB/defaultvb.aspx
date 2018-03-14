<!--<SNIPPET1>-->
<%@ page language="VB" %>
<%@ Register tagprefix="IRow" 
    Namespace="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IRow Test Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:webpartmanager ID="WebPartManager1" runat="server">
        <staticconnections>
          <asp:webpartconnection ID="wp1" ProviderID="provider1" 
            ConsumerID="consumer1">
          </asp:webpartconnection>
        </staticconnections>
      </asp:webpartmanager>
       
        <asp:webpartzone ID="WebPartZone1" runat="server">
          <ZoneTemplate>
            <irow:RowProviderWebPart ID="provider1" runat="server" 
              Title="Row Provider Control" />
            <irow:RowConsumerWebPart ID="consumer1" runat="server" 
              Title="Row Consumer Control" />
          </ZoneTemplate>
        </asp:webpartzone>
    </div>
    </form>
</body>
</html>
<!--</SNIPPET1>-->