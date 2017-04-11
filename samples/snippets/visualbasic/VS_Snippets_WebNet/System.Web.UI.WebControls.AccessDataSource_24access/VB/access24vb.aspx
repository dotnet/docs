<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

  Label1.Text = AccessDataSource1.ConnectionString

End Sub 'Page_Load
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:AccessDataSource
        id="AccessDataSource1"
        runat="server"
        DataFile="Northwind.mdb">
      </asp:AccessDataSource>

      <asp:Label
        id="Label1"
        runat="server">
      </asp:Label>

    </form>
  </body>
</html>
<!-- </Snippet1> -->