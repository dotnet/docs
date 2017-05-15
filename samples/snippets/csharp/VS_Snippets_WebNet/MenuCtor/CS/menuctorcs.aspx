<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  void Page_Load(Object sender, EventArgs e)
  {
    
    // Create a new Menu control.
    Menu newMenu = new Menu();
          
    // Set the properties of the Menu control.
    newMenu.ID = "NavigationMenu";
    newMenu.DisappearAfter = 2000;
    newMenu.Orientation = Orientation.Vertical;
    newMenu.Target = "_blank";
    newMenu.StaticMenuItemStyle.ForeColor = System.Drawing.Color.Black;
    newMenu.DynamicMenuItemStyle.ForeColor = System.Drawing.Color.Gray;
    
    // Create the menu structure.
    
    // Create the root menu item.
    MenuItem homeMenuItem;
    homeMenuItem = CreateMenuItem("Home", "Home.aspx", "Home");
    
    // Create the submenu items.
    MenuItem musicSubMenuItem;
    musicSubMenuItem = CreateMenuItem("Music", "Music.aspx", "Music");
    
    MenuItem moviesSubMenuItem;
    moviesSubMenuItem = CreateMenuItem("Movies", "Movies.aspx", "Movies");
    
    // Add the submenu items to the ChildItems
    // collection of the root menu item.
    homeMenuItem.ChildItems.Add(musicSubMenuItem);
    homeMenuItem.ChildItems.Add(moviesSubMenuItem);
    
    // Add the root menu item to the ItemsCollection 
    // of the Menu control.
    newMenu.Items.Add(homeMenuItem);
    
    // Add the Menu control to the Controls collection
    // of the PlaceHolder control.
    MenuPlaceHolder.Controls.Add(newMenu);
    
  }
  
  MenuItem CreateMenuItem(String text, String url, String toolTip)
  {
    
    // Create a new MenuItem object.
    MenuItem menuItem = new MenuItem();
    
    // Set the properties of the MenuItem object using
    // the specified parameters.
    menuItem.Text = text;
    menuItem.NavigateUrl = url;
    menuItem.ToolTip = toolTip;
    
    return menuItem;
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu Constructor Example</h3>
    
      <asp:placeholder id="MenuPlaceHolder"
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
