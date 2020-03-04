<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register tagprefix="uc1" 
  tagname="DisplayModeMenuCS" 
  src="displaymodecs.ascx" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  // <snippet3>

  void Button1_Click(object sender, EventArgs e)
  {
    if (EditorZone1.ApplyVerb.Enabled == true)
      EditorZone1.ApplyVerb.Enabled = false;
    else
      EditorZone1.ApplyVerb.Enabled = true;
  }

  void Button2_Click(object sender, EventArgs e)
  {
    EditorZone1.BorderWidth = 2;
    EditorZone1.BorderColor = System.Drawing.Color.DarkBlue;
  }

  void Button3_Click(object sender, EventArgs e)
  {
    Label1.Text = "<br />";
    foreach (EditorPart part in EditorZone1.EditorParts)
    {
      Label1.Text += part.ID + "<br />";
    }
  }

  void Button4_Click(object sender, EventArgs e)
  {
    EditorZone1.InstructionText = "My custom instruction text.";
  }
  // </snippet3>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>EditorZoneBase Examples</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="mgr" runat="server" />
    <uc1:DisplayModeMenuCS runat="server" id="displaymodemenu1" />
    <asp:WebPartZone ID="WebPartZone1" runat="server">
      <ZoneTemplate>
        <asp:BulletedList 
          ID="BulletedList1" 
          Runat="server"
          DisplayMode="HyperLink" 
          Title="Favorite Links" >
          <asp:ListItem Value="http://msdn.microsoft.com">
            MSDN
          </asp:ListItem>
          <asp:ListItem Value="http://www.asp.net">
            ASP.NET
          </asp:ListItem>
          <asp:ListItem Value="http://www.msn.com">
            MSN
          </asp:ListItem>
        </asp:BulletedList>
        <asp:Calendar ID="Calendar1" Runat="server" 
          Title="My Calendar" />
      </ZoneTemplate>
    </asp:WebPartZone>
    <!-- <snippet2> -->
    <asp:EditorZone ID="EditorZone1" runat="server" >
      <VerbStyle Font-Italic="true" />
      <EditUIStyle BackColor="lightgray" />
      <PartChromeStyle BorderWidth="1" />
      <LabelStyle Font-Bold="true" />
      <CancelVerb Text="Cancel Changes" />
      <ZoneTemplate>
        <asp:AppearanceEditorPart ID="AppearanceEditorPart1" 
          runat="server" />
        <asp:LayoutEditorPart ID="LayoutEditorPart1" 
          runat="server" />
      </ZoneTemplate>
    </asp:EditorZone>
    <!-- </snippet2> -->
    <hr />
    <asp:Button ID="Button1" runat="server" Width="200"
      Text="Enable or Disable Apply" OnClick="Button1_Click" />
    <br />
    <asp:Button ID="Button2" runat="server" Width="200"
      Text="Set Zone BorderColor" OnClick="Button2_Click" />
    <br />
    <asp:Button ID="Button3" runat="server" Width="200"
      Text="Display EditorPart Collection" OnClick="Button3_Click" />
    <asp:Label ID="Label1" runat="server" />
    <br />
    <asp:Button ID="Button4" runat="server" Width="200"
      Text="Set Instruction Text" OnClick="Button4_Click" /> 
  </form>
</body>
</html>
<!-- </snippet1> -->