<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
 
    If Not IsPostBack Then
    
      ' Create the menu item bindings for the Menu control.
      Dim binding As MenuItemBinding
      
      binding = CreateMenuItemBinding("MapHomeNode", 0, "title", "url")
      NavigationMenu.DataBindings.Add(binding)

      binding = CreateMenuItemBinding("MapNode", 1, "title", "url")
      NavigationMenu.DataBindings.Add(binding)

      binding = CreateMenuItemBinding("MapNode", 2, "title", "url")
      NavigationMenu.DataBindings.Add(binding)
   
    End If
    
  End Sub

  ' This is a helper method to create a MenuItemBinding 
  ' object from the specified parameters.
  Function CreateMenuItemBinding(ByVal dataMember As String, ByVal depth As Integer, ByVal textField As String, ByVal navigateUrlField As String) As MenuItemBinding
  
    ' Create a new MenuItemBinding object.
    Dim binding As New MenuItemBinding()

    ' Set the properties of the MenuItemBinding object.
    binding.DataMember = dataMember
    binding.Depth = depth
    binding.TextField = textField
    binding.NavigateUrlField = navigateUrlField

    Return binding
    
  End Function
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemBindingCollection Add Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemBindingCollection Add Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"
        datasourceid="MenuSource"
        runat="server">        
      </asp:menu>
      
      <asp:xmldatasource id="MenuSource"
        datafile="Map.xml"
        runat="server"/>        

    </form>
  </body>
</html>

<!-- </Snippet1> -->
