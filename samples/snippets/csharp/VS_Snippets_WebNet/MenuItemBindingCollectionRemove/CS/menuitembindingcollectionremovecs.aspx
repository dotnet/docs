<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

void Page_Load(Object sender, EventArgs e)
  {
    if(!IsPostBack)
    {
      // Create the menu item bindings for the Menu control.
      MenuItemBinding binding;
      
      binding = CreateMenuItemBinding("MapHomeNode", 0, "title", "url");
      NavigationMenu.DataBindings.Add(binding);

      binding = CreateMenuItemBinding("MapNode", 1, "title", "url");
      NavigationMenu.DataBindings.Add(binding);

      binding = CreateMenuItemBinding("MapNode", 2, "title", "url");
      NavigationMenu.DataBindings.Add(binding);
        
      // Use the Remove method to remove the last MenuItemBinding 
      // object.
        NavigationMenu.DataBindings.Remove(binding);

    }
  }

  // This is a helper method to create a MenuItemBinding 
  // object from the specified parameters.
  MenuItemBinding CreateMenuItemBinding(String dataMember, int depth, String textField, String navigateUrlField)
  {
    // Create a new MenuItemBinding object.
    MenuItemBinding binding = new MenuItemBinding();

    // Set the properties of the MenuItemBinding object.
    binding.DataMember = dataMember;
    binding.Depth = depth;
    binding.TextField = textField;
    binding.NavigateUrlField = navigateUrlField;

    return binding;
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemBindingCollection Remove Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemBindingCollection Remove Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"
        datasourceid="MenuSource"
        runat="server">
        
        <DataBindings>
          <asp:menuitembinding datamember="MapHomeNode" 
            depth="0"
            textfield="title" 
            navigateurlfield="url"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="1"
            textfield="title" 
            navigateurlfield="url"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="2"
            textfield="title" 
            navigateurlfield="url"/>
          <asp:menuitembinding datamember="ExtraMapNode" 
            depth="3"
            textfield="title" 
            navigateurlfield="url"/>
        </DataBindings>
                
      </asp:menu>
      
      <asp:xmldatasource id="MenuSource"
        datafile="Map.xml"
        runat="server"/>        

    </form>
  </body>
</html>

<!-- </Snippet1> -->
