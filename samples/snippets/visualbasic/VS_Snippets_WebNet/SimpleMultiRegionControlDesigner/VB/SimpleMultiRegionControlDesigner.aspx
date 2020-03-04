<!-- <Snippet8> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="aspSample" 
    Assembly="Samples.ASPNet.ControlDesigners_VB" 
    Namespace="Samples.ASPNet.ControlDesigners_VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Designers Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <aspSample:MyMultiRegionControl ID="myCtl" Runat=Server Width=200 Height=75 BorderStyle=solid >
        </aspSample:MyMultiRegionControl><br />
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <asp:RadioButton ID="RadioButton1" runat="server" />

    </div>
    </form>
</body>
</html>
<!-- </Snippet8> -->
