<!-- <snippet1> -->
<%@ Page Language="vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Button2_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    Dim mgr As WebPartManager = WebPartManager1
    Dim cal As New Calendar()
    cal.ID = "cal1"
    Dim calWebPart As GenericWebPart = mgr.CreateWebPart(cal)
    mgr.AddWebPart(calWebPart, WebPartZone1, 1)
  End Sub

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)

    If WebPartZone1.WebParts.Count > 1 Then
      Dim cal As WebPart = WebPartZone1.WebParts(1)
      If cal.Controls(0).GetType().Name = "Calendar" AndAlso _
        cal IsNot Nothing Then
        WebPartManager1.DeleteWebPart(cal)
      End If
    End If
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Adding a Server Control</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="WebPartManager1" 
        runat="server" />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:BulletedList  
            DisplayMode="HyperLink" 
            ID="BulletedList1" 
            runat="server"
            Title="My Links">
            <asp:ListItem Value="http://www.microsoft.com">
            Microsoft
            </asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">
            MSN
            </asp:ListItem>
            <asp:ListItem Value="http://www.contoso.com">
            Contoso Corp.
            </asp:ListItem>
          </asp:BulletedList>
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Delete Calendar" 
        OnClick="Button1_Click" />
      <asp:Button ID="Button2" runat="server" 
        Text="Add Calendar" 
        OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->