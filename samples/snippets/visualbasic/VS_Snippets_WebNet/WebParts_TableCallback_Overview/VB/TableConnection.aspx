<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ Register tagprefix="wp" Namespace="Samples.AspNet.VB.Controls"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ITable Test Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- A static or dynamic connection is required to 
             link two Web Parts controls. --->
        <asp:webpartmanager id="WebPartManager1" runat="server">
            <StaticConnections>
                <asp:WebPartConnection id="wp1" ProviderID="provider1" 
                   ConsumerID="consumer1">
                </asp:WebPartConnection>
            </StaticConnections>
        </asp:webpartmanager>
        <asp:webpartzone id="WebPartZone1" runat="server">
            <zoneTemplate>
            <!-- The following two lines define the two 
                 connected controls. --->
            <wp:TableProviderWebPart ID="provider1" runat="server" 
               title="Web Parts Table Provider Control" />
            <wp:TableConsumerWebPart ID="consumer1" runat="server" 
               title="Web Parts Table Consumer Control"/>
            </zoneTemplate>
        </asp:webpartzone>
    </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->
