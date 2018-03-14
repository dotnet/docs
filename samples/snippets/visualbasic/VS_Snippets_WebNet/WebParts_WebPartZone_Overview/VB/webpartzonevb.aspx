<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ Register TagPrefix="cc1" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="MyWebPartZoneVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="WebPartManager1" runat="server" />
      <!-- <snippet2> -->
      <cc1:MyWebPartZone ID="MyWebPartZone1" runat="server">
        <VerbStyle Font-Italic="true" />
        <PartChromeStyle BackColor="lightblue" />
        <PartStyle BackColor="gray" />
        <PartTitleStyle Font-Bold="true" />
        <ZoneTemplate>
          <asp:Calendar ID="Calendar1" runat="server" 
            Title="My Calendar" />
        </ZoneTemplate>
      </cc1:MyWebPartZone>
      <!-- </snippet2> -->
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->