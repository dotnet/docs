<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ register tagprefix="uc1" 
  tagname="DisplayModeMenuVB" 
  src="displaymodevb.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  ' <snippet3> 

  ' <snippet4> 
  Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
    If EditorZone1.ApplyVerb.Enabled Then
      EditorZone1.ApplyVerb.Enabled = False
    Else
      EditorZone1.ApplyVerb.Enabled = True
    End If
  End Sub
  ' </snippet4>
  ' <snippet5> 
  Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
    If EditorZone1.CancelVerb.Enabled Then
      EditorZone1.CancelVerb.Enabled = False
    Else
      EditorZone1.CancelVerb.Enabled = True
    End If
  End Sub
  ' </snippet5>
  ' <snippet6>
  Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = "<br />"
    Dim part As EditorPart
    For Each part In EditorZone1.EditorParts
      Label1.Text += part.ID + "<br />"
    Next part
  End Sub
  ' </snippet6>
  ' <snippet7>
  Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
    If EditorZone1.OKVerb.Enabled Then
      EditorZone1.OKVerb.Enabled = False
    Else
      EditorZone1.OKVerb.Enabled = True
    End If

  End Sub
  ' </snippet7>
  
  ' </snippet3>
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>EditorZoneBase Examples</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" />
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
    <aspSample:MyEditorZone ID="EditorZone1" runat="server">
      <ApplyVerb Text="Apply Changes" />
      <CancelVerb Text="Cancel Changes" />
      <OKVerb Text="Finished" />
      <ZoneTemplate>
        <asp:AppearanceEditorPart ID="AppearanceEditorPart1" 
          runat="server" />
        <asp:LayoutEditorPart ID="LayoutEditorPart1" 
          runat="server" />
      </ZoneTemplate>
    </aspSample:MyEditorZone>
    <!-- </snippet2> -->
    <hr />
    <asp:Button ID="Button1" runat="server" Width="200"
      Text="Toggle ApplyVerb Enabled" OnClick="Button1_Click" />
    <br />
    <asp:Button ID="Button2" runat="server" Width="200"
      Text="Toggle CancelVerb Enabled" OnClick="Button2_Click" />
    <br />
    <asp:Button ID="Button3" runat="server" Width="200"
      Text="Display EditorParts Collection" OnClick="Button3_Click" />
    <asp:Label ID="Label1" runat="server" />
    <br />
    <asp:Button ID="Button4" runat="server" Width="200"
      Text="Toggle OKVerb Enabled" OnClick="Button4_Click" /> 
  </form>
</body>
</html>
<!-- </snippet1> -->