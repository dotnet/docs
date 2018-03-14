<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  void Page_Load(Object sender, EventArgs e)
  {

    // Display the submenu items of the Music
    // menu item. 

    // Retrieve the Music menu item.
    MenuItem musicMenuItem = NavigationMenu.FindItem(@"Home");

    // Declare an array of MenuItem objects.
         MenuItem[] musicItemArray = new MenuItem[musicMenuItem.ChildItems.Count];

    // Use the CopyTo method to copy the submenu items 
    // of the Music menu item into the array.
    musicMenuItem.ChildItems.CopyTo(musicItemArray, 0);
    
    // Display the menu items.
    Message.Text = "The submenu items of the Home menu item are: <br/><br/>";

    foreach (MenuItem item in musicItemArray)
    {

      Message.Text += item.Text + "<br />";

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemCollection CopyTo Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemCollection CopyTo Example</h3>
    
      <asp:menu id="NavigationMenu"
        orientation="Vertical"
        target="_blank" 
        runat="server">
        
        <items>
          <asp:menuitem text="Home"
            tooltip="Home">
            <asp:menuitem text="Music"
              tooltip="Music">
              <asp:menuitem text="Classical"
                tooltip="Classical"/>
              <asp:menuitem text="Rock"
                tooltip="Rock"/>
              <asp:menuitem text="Jazz"
                tooltip="Jazz"/>
            </asp:menuitem>
            <asp:menuitem text="Movies"
              tooltip="Movies">
              <asp:menuitem text="Action"
                tooltip="Action"/>
              <asp:menuitem text="Drama"
                tooltip="Drama"/>
              <asp:menuitem text="Musical"
                tooltip="Musical"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>

      </asp:menu>
      
      <hr/>

      <asp:label id="Message" 
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
