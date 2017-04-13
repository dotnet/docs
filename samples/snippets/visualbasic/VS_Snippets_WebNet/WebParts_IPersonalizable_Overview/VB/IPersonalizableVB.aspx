<!-- <snippet1> -->
<%@ Page Language="VB"  %>
<%@ Register TagPrefix="dict" 
    namespace="Samples.AspNet.VB.Controls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IPersonalizable</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:WebPartManager ID="mgr" runat="server" />
    <div>
    <asp:WebPartZone ID="WebPartZone1" runat="server">
      <ZoneTemplate>
        <dict:urllistwebpart id="listwp1" runat="server"
          title="URL List WebPart" />
      </ZoneTemplate>
    </asp:WebPartZone>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->