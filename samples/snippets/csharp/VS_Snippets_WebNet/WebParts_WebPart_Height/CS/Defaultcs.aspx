<%--<snippet1>--%>
<%@ Page Language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Button1_Click(object sender, EventArgs e)
  {
    wpmgr.DisplayMode = WebPartManager.DesignDisplayMode;
  }
  protected void Button2_Click(object sender, EventArgs e)
  {
    wpmgr.DisplayMode = WebPartManager.BrowseDisplayMode;
  }

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