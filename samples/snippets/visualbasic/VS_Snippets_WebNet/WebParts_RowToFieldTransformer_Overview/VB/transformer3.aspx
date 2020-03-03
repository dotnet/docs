<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ register tagprefix="uc1" 
    tagname="DisplayModeMenuVB" 
    src="~/displaymodemenuvb.ascx" %>
<%@ Register TagPrefix="wp" 
    NameSpace="Samples.AspNet.VB.Controls" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
   
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:webpartmanager id="manager" runat="server">
    <staticconnections>
      <asp:WebPartConnection ID="conn1" ProviderID="rp1" ConsumerID="fc1">
        <asp:RowToFieldTransformer FieldName="Zip Code"/>
      </asp:WebPartConnection>
    </staticconnections>
    </asp:webpartmanager>
  <uc1:displaymodemenuvb id="menu1" runat="server" />
  <table>
  <tr valign="top">
    <td>
      <asp:webpartzone id="zone1" headertext="zone1" runat="server">
        <zonetemplate>
          <wp:RowProviderWebPart Title="provider" ID="rp1" runat="server" />
          <wp:FieldConsumerWebPart Title="consumer" ID="fc1" runat="server" />
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
<!-- </Snippet3> -->