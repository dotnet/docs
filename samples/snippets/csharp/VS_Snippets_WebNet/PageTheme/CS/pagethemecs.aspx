<!-- <snippet2> -->
<%@ page language="C#" theme="MyTheme" %>
<!-- </snippet2> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  // <snippet1>
  void Page_PreInit(object sender, EventArgs e)
  {
    // Get the theme name from a QueryString variable
    string ThemeName;
    ThemeName = Request.QueryString["thename"];
    if (ThemeName != null)
    {
      Page.Theme = ThemeName;
    }
  }
  // </snippet1>

  protected void Page_Load(object sender, EventArgs e)
  {
    Test.Text = Page.Theme;
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
      <asp:button id="Test" runat="Server" Text="Default"/>
    </form>
  </body>
</html>
