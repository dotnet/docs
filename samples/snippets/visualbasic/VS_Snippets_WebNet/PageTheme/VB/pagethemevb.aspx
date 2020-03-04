    <!-- <snippet2> -->
<%@ page language="VB" theme="MyTheme" %>
    <!-- </snippet2> -->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  ' <snippet1>
  Public Sub Page_PreInit(ByVal Sender As Object, ByVal e As EventArgs)
        
    ' Get the theme name from a QueryString variable
    Dim ThemeName As String
    ThemeName = Request.QueryString("thename")
    If ThemeName <> Nothing Then
      Page.Theme = ThemeName
    End If
  End Sub
  ' </snippet1>
    
  Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    Test.Text = Page.Theme
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
      <asp:button id="Test" runat="Server" Text="Default"/>
    </form>
  </body>
</html>

