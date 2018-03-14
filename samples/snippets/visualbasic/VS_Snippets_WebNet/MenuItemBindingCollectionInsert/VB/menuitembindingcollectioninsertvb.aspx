<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
 
    If Not IsPostBack Then
    
      ' Create the MenuItemBinding object to insert.
      Dim binding As MenuItemBinding      
      binding = CreateMenuItemBinding("MapNode", 1, "title", "url")

      ' Use the Insert method to add the MenuItemBinding 
      ' object to the Bindings collection at index 1.
      NavigationMenu.DataBindings.Insert(1, binding)
      
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
    <title>MenuItemBindingCollection Insert Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemBindingCollection Insert Example</h3>
    
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
