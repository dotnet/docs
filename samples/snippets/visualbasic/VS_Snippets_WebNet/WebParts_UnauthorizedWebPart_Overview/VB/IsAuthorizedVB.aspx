<!-- <snippet1> -->
<%@ Page Language="vb" %>
<%@ Register Namespace="Samples.AspNet.VB.Controls" 
    TagPrefix="aspSample"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    Dim part As WebPart
    For Each part In mgr1.WebParts
      If mgr1.IsAuthorized(part) Then
        part.ExportMode = WebPartExportMode.All
      End If
    Next
  End Sub

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    Label2.Text = String.Empty
    Dim part As WebPart
    
    For Each part In mgr1.WebParts
      Label2.Text += part.ID & "<br />"
    Next

  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <aspSample:MyManagerAuthorize ID="mgr1" runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:BulletedList 
            ID="BulletedList1" 
            Runat="server"
            DisplayMode="HyperLink" 
            Title="Favorite Links"
            AuthorizationFilter="admin">
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
          <asp:Label ID="Label1" runat="server" 
            Text="Hello World"
            AuthorizationFilter="user" />
          <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </ZoneTemplate>
      </asp:WebPartZone>
      <hr />
      <asp:Button ID="Button1" runat="server" 
        Text="List WebPart Controls" OnClick="Button1_Click" />
      <br />
      <asp:Label ID="Label2" runat="server" 
        Text="" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->