<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  void NavigationMenu_MenuItemClick(Object sender, MenuEventArgs e)
  {

    // Retrieve the parent menu item of the selected menu item.
    MenuItem parent = e.Item.Parent;

    // Determine whether the selected menu item is a 
    // root menu item. Root menu items are stored in
    // a Menu control's Items collection. Other menu
    // items are stored in the parent menu item's
    // ChildItems collection.
    if (parent != null)
    {
      Message.Text = "The " + e.Item.Text + 
        " menu item has an index of " +
        parent.ChildItems.IndexOf(e.Item).ToString() +
        " in the parent menu item's ChildItems collection.";
    }
    else
    {
      Message.Text = "The " + e.Item.Text +
        " menu item has an index of " +
        NavigationMenu.Items.IndexOf(e.Item).ToString() +
        " in the Menu control's Items collection.";
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemCollection IndexOf Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemCollection IndexOf Example</h3>
    
      Select an item from the menu.
      <br/><br/>
    
      <asp:menu id="NavigationMenu"
        orientation="Vertical"
        target="_blank"
        onmenuitemclick="NavigationMenu_MenuItemClick"  
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
