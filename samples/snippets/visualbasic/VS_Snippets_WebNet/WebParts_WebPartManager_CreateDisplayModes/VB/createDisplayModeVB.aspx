<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ Register Src="TextDisplayvb.ascx" 
    TagName="TextDisplay" 
    TagPrefix="uc2" %>
<%@ Register Src="DisplayModeMenuVB.ascx" 
    TagName="DisplayModeMenuVB" 
    TagPrefix="uc1" %>
<%@ Register Namespace="Samples.AspNet.VB.Controls" 
    TagPrefix="sample" 
    Assembly="CustomDisplayModeVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:DisplayModeMenuVB id="menu1" runat="server" />
    <div>
    <sample:NewWebPartManager runat="server" ID="wpgm1" />
    <br />
    <table style="width: 100%">
      <tr valign="top" align="center" >
        <td style="width: 100px; height: 123px">
          <asp:WebPartZone ID="WebPartZone1" runat="server">
            <ZoneTemplate>
              <uc2:TextDisplay ID="TextDisplay1" runat="server" />
            </ZoneTemplate>
          </asp:WebPartZone>
        </td>
        <td style="width: 100px; height: 123px">
          <asp:WebPartZone ID="WebPartZone2" runat="server" />
        </td>
      </tr>
    </table>
    <br />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->