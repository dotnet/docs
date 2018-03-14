<!-- <snippet7> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="admin" TagName="administrator" Src="~/PersAdmin.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
        &nbsp;<asp:LoginName ID="LoginName1" runat="server" />
        &nbsp;
        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="RedirectToLoginPage" />
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        </div>
        <asp:WebPartManager ID="WebPartManager1" runat="server"></asp:WebPartManager>
        <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
        <admin:administrator id="admincontrol" runat="server" />
        </ZoneTemplate>
        </asp:WebPartZone>
    </form>
</body>
</html>
<!-- </snippet7> -->