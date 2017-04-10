<%--<snippet1>--%>
<%@ Page Language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    wpmgr.DisplayMode = WebPartManager.DesignDisplayMode
    
  End Sub

  Protected Sub Button2_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    wpmgr.DisplayMode = WebPartManager.BrowseDisplayMode
    
  End Sub
  
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="wpmgr" runat="server" />
      <asp:webpartzone id="WebPartZone1" runat="server" 
        layoutorientation="horizontal">
        <zonetemplate>
          <asp:textbox id="TextBox1" runat="server" title="Text input">
          </asp:textbox>
          <asp:calendar id="Calendar1" runat="server" title="Personal Calendar" />
        </zonetemplate>
      </asp:webpartzone>
      <asp:button id="Button1" runat="server" text="Design Mode" 
        onclick="Button1_Click" />
      <br />
      <asp:button id="Button2" runat="server" onclick="Button2_Click" 
        text="Browse Mode" />
    </form>
</body>
</html>
<%--</snippet1>--%>