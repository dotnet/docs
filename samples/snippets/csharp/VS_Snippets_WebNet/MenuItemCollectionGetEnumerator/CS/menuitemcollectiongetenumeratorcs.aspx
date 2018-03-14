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
    MenuItem musicMenuItem = NavigationMenu.FindItem(@"Home\Music");

    // Use the GetEnumerator method to create an enumerator 
    // that contains the submenu items of the Music menu item.
    IEnumerator menuItemEnumerator = musicMenuItem.ChildItems.GetEnumerator();

    Message.Text = "The submenu items of the Music menu item are: <br/><br/>";

    // Iterate though the enumerator to display the menu items.
    while (menuItemEnumerator.MoveNext())
    {

      Message.Text += ((MenuItem)(menuItemEnumerator.Current)).Text + "<br />";

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemCollection GetEnumerator Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemCollection GetEnumerator Example</h3>
    
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
