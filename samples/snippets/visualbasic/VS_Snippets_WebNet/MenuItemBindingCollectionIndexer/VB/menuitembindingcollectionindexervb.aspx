<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    If Not IsPostBack Then
    
      ' Use the indexer to retrieve the MenuItemBinding
      ' object at index 0.
      Dim binding As MenuItemBinding = NavigationMenu.DataBindings(0)

      ' Instead of binding the Text property of the Home
      ' menu item to a field from a data source, bind it
      ' to static text.
      binding.TextField = ""
      binding.Text = "Custom Menu Text"
    
    End If
      
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemBindingCollection Indexer Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemBindingCollection Indexer Example</h3>
    
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
        </DataBindings>
                
      </asp:menu>
      
      <asp:xmldatasource id="MenuSource"
        datafile="Map.xml"
        runat="server"/>        

    </form>
  </body>
</html>

<!-- </Snippet1> -->
