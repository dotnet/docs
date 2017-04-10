<%@ Page Language="C#" %>
<%@ register tagprefix="aspSample" namespace="Samples.AspNet.CS.Controls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>WebParts Designers Demo Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p style="font-family:tahoma;font-size:large;
            font-weight:bold">
            Custom WebParts Designers</p>
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
        <asp:WebPartZone ID="WebPartZone1" runat="server">
            <ZoneTemplate>
        <aspSample:BirthdayPart ID="bday" runat="server" />
            </ZoneTemplate>
        </asp:WebPartZone>
        <br />
    </div>
    </form>
</body>
</html>
