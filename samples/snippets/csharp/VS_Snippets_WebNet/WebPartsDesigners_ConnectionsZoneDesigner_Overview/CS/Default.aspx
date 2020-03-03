<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="ccl" Namespace="Samples.AspNet.CS.Controls" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>EditorPartDesigner Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
        <ccl:ConnectionsZoneSample ID="CZS1" runat="server">
        </ccl:ConnectionsZoneSample>        
    </div>
    </form>
</body>
</html>
