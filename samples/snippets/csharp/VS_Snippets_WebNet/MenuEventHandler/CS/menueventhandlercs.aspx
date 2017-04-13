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
    newMenu.Orientation = Orientation.Vertical;
    newMenu.Target = "_blank";

    // Specify the data source for the menu.
    newMenu.DataSourceID = "MenuSource";

    // Programmatically register the event-handling method
    // for the MenuItemClick event of a Menu control. 
    newMenu.MenuItemClick += new MenuEventHandler(this.NavigationMenu_MenuItemClick);

    // Add the Menu control to the Controls collection
    // of the PlaceHolder control.
    MenuPlaceHolder.Controls.Add(newMenu);
    
  }

  void NavigationMenu_MenuItemClick(Object sender, MenuEventArgs e)
  {

    // Display the text of the menu item selected by the user.
    Message.Text = "You selected " + e.Item.Text + ".";

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuEventHandler Example</h3>
    
      <asp:placeholder id="MenuPlaceHolder"
        runat="server"/>
        
      <asp:sitemapdatasource id="MenuSource"
        runat="server"/>
        
      <hr/>
      
      <asp:label id="Message"
        runat="server"/>  

    </form>
  </body>
</html>

<!-- </Snippet1> -->
