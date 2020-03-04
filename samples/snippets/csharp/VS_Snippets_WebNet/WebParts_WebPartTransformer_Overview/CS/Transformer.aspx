<!-- <Snippet1> -->
<%@ Page language="c#" trace="false" debug="true" %> 
<%@ register tagprefix="uc1" 
    tagname="DisplayModeMenuCS" 
    src="~/displaymodemenucs.ascx" %>
<%@ Register TagPrefix="wp" 
    NameSpace="Samples.AspNet.CS.Controls" %>

<script runat="server">

</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Web Parts Transformer Sample Page</title>
</head>
<body>
<form id="Form1" runat="server">

<asp:webpartmanager id="manager" runat="server">
  <staticconnections>
    <asp:webpartconnection id="conn1" providerid="p1" consumerid="c1">
      <wp:rowtostringtransformer />
    </asp:webpartconnection>
  </staticconnections>
</asp:webpartmanager>
<uc1:displaymodemenucs id="menu1" runat="server" />

<table>
<tr valign="top">
  <td>
  <asp:webpartzone id="zone1" headertext="zone1" runat="server">
    <zonetemplate>
      <wp:rowproviderwebpart id="p1" runat="server" />
      <wp:stringconsumerwebpart id="c1" runat="server" />
    </zonetemplate>
  </asp:webpartzone>
  </td>
  <td>
  <asp:connectionszone id="connectionszone1" runat="server" />
  </td>
</tr>
</table>

</form>
</body>
</html>
<!-- </Snippet1> -->