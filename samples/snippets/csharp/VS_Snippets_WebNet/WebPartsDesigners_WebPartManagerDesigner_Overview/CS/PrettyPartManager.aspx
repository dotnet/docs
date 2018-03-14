<%@ Page Language="C#" %>
<%@ register tagprefix="ccl" namespace="Samples.AspNet.CS.Controls" %>
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
            WebPartManager with Custom Designer</p>
        <ccl:PrettyPartManager ID="PrettyPartManager1" runat="server">
        </ccl:PrettyPartManager>
    </div>
    </form>
</body>
</html>
