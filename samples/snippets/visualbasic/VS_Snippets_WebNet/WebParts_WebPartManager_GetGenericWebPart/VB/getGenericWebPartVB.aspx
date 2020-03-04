<!-- <snippet1> -->
<%@ Page Language="vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
 
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    Label1.Text = "<h2>Server Control</h2>"
    Label1.Text += "Server Control ID:  " + Calendar1.ID
    Label2.Text = "<h2>GenericWebPart Controls</h2>"
    Dim part As GenericWebPart
    part = mgr.GetGenericWebPart(Calendar1)
    If part IsNot Nothing Then
      Label2.Text += _
        "GenericWebPart ID:  " & part.ID & "<br />"
      Label2.Text += _
        "Underlying Control ID: " + part.ChildControl.ID
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:Calendar ID="Calendar1" runat="server"
            Title="My Calendar" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Get GenericWebPart"
        OnClick="Button1_Click" />
      <hr />
      <asp:Label ID="Label1" runat="server" Text="" />
      <br />
      <asp:Label ID="Label2" runat="server" Text="" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->