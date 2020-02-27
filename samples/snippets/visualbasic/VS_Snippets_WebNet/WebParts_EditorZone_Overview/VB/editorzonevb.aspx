<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ register tagprefix="uc1" 
  tagname="DisplayModeMenuVB" 
  src="displaymodevb.ascx" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  ' <snippet3>

  Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
    If EditorZone1.ApplyVerb.Enabled = True Then
      EditorZone1.ApplyVerb.Enabled = False
    Else
      EditorZone1.ApplyVerb.Enabled = True
    End If
  End Sub
 
  Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
    EditorZone1.BorderWidth = 2
    EditorZone1.BorderColor = System.Drawing.Color.DarkBlue
  End Sub

  Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = "<br />"
    Dim part As EditorPart
    For Each part In EditorZone1.EditorParts
      Label1.Text += part.ID + "<br />"
    Next part
  End Sub

  Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
    EditorZone1.InstructionText = "My custom instruction text."
  End Sub
  ' </snippet3>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>EditorZoneBase Examples</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="mgr" runat="server" />
    <uc1:DisplayModeMenuVB runat="server" id="displaymodemenu1" />
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