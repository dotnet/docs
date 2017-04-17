<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register 
    Namespace="Samples.AspNet.CS.Controls" 
    TagPrefix="aspSample"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="WebPartManager1" runat="server">
      </asp:WebPartManager>
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <aspSample:MyManagerIDLabel ID="mgrID" runat="server" 
            Title="Manager ID Label" 
            Description="Displays the ID of the current WebPartManger."/>
        </ZoneTemplate>
      </asp:WebPartZone>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->