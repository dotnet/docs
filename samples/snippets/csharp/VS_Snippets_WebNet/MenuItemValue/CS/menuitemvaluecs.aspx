<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void NavigationMenu_MenuItemClick(Object sender, MenuEventArgs e)
  {
    // Display the selected menu item.
    if (e.Item.Parent != null)
    {
      Message.Text = "You selected " + e.Item.Value + 
        " from " + e.Item.Parent.Value + ".";
    }
    else
    {
      Message.Text = "You selected " + e.Item.Value + ".";
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem Value Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem Value Example</h3>
    
      Select an item from the menu:<br/><br/>
 
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="1"
        staticsubmenuindent="10" 
        orientation="Vertical"
        onmenuitemclick="NavigationMenu_MenuItemClick"  
        runat="server">
        
        <dynamicselectedstyle backcolor="yellow"/>
        <staticselectedstyle backcolor="yellow"/>

        <items>
          <asp:menuitem text="Home"
            tooltip="Home">
            <asp:menuitem text="Category"
              value="Category 1"
              tooltip="Category 1">
              <asp:menuitem text="Topic"
                value="Topic 1"
                tooltip="Topic 1"/>
              <asp:menuitem text="Topic"
                value="Topic 2"
                tooltip="Topic 2"/>
              <asp:menuitem text="Topic"
                value="Topic 3"
                tooltip="Topic 3"/>
            </asp:menuitem>
            <asp:menuitem text="Category"
              value="Category 2"
              tooltip="Category 2">
              <asp:menuitem text="Topic"
                value="Topic 1"
                tooltip="Topic 1"/>
              <asp:menuitem text="Topic"
                value="Topic 2"
                tooltip="Topic 2"/>
              <asp:menuitem text="Topic"
                value="Topic 3"
                tooltip="Topic 3"/>
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
