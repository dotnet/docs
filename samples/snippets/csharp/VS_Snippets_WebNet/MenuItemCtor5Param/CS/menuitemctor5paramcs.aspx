<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  void Page_Load(Object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      // Create the menu structure.

      // Create the root menu item.
      MenuItem homeMenuItem = new MenuItem("Home", "Root",
        @"Images\Home.jpg", "Home.aspx", "_self");

      // Create the submenu items.
      MenuItem musicSubMenuItem = new MenuItem("Music", "Category 1",
        @"Images\Music.jpg", "Music.aspx", "_blank");
      MenuItem moviesSubMenuItem = new MenuItem("Movies", "Category 2",
        @"Images\Movies.jpg", "Movies.aspx", "_blank");

      // Add the submenu items to the ChildItems
      // collection of the root menu item.
      homeMenuItem.ChildItems.Add(musicSubMenuItem);
      homeMenuItem.ChildItems.Add(moviesSubMenuItem);

      // Add the root menu item to the Items collection 
      // of the Menu control.
      NavigationMenu.Items.Add(homeMenuItem);
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem Constructor Example</h3>
    
      <asp:menu id="NavigationMenu"
        orientation="Vertical"
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
