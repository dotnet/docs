<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void MenuItemDataBound_NavigationMenu(Object sender, MenuEventArgs e)
  {
    // Display an image for the Home menu item only by
    // setting its ImageUrl property.
    if (e.Item.Text == "Home")
    {
      // Use an @-quoted string to bypass the escape sequence
      // processing.
      e.Item.ImageUrl = @"Images\Home.jpg";
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuEventArgs Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        datasourceid="menusource" 
        onmenuitemdatabound="MenuItemDataBound_NavigationMenu" 
        runat="server">

      </asp:menu>
      
      <asp:SiteMapDataSource id="MenuSource"
        Runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
