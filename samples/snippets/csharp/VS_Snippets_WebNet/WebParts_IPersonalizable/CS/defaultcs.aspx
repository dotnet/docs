<!-- <snippet10> -->
<%@ Page Language="C#"  %>
<%@ Register TagPrefix="dict" namespace="PersTest" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server"></asp:WebPartManager>
    &nbsp;<asp:LoginName ID="LoginName1" runat="server" />
        &nbsp;
        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="RedirectToLoginPage" />
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
    <div>
    <asp:WebPartZone ID="WebPartZone1" runat="server">
                 <ZoneTemplate>
        <dict:UrlListWebPart id="PersDict" title="Personalization Dictionary" runat="server" />
       
        </ZoneTemplate>
        </asp:WebPartZone>
    </div>
    </form>
</body>
</html>
<!-- </snippet10> -->