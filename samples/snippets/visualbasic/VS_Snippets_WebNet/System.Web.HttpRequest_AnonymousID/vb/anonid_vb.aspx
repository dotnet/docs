<!--<snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    If (Application("UserCount") IsNot Nothing) Then
      lblUserCount.Text = Application("UserCount").ToString()
      lblCurrentUser.Text = Request.AnonymousID
    End If
      
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>AnonymousID Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Number of users: 
        <asp:Label ID="lblUserCount" Runat="server"></asp:Label><br />
    Current user:
        <asp:Label ID="lblCurrentUser" Runat="server"></asp:Label><br />
    </div>
    </form>
</body>
</html>
<!--</snippet1>-->
