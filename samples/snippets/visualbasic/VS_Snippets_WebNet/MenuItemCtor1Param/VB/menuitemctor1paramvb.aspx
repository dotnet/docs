<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
  
    If Not IsPostBack Then
    
      ' Create the menu structure.

      ' Create the root menu item.
      Dim homeMenuItem As New MenuItem("Home")

      ' Create the submenu items.
      Dim musicSubMenuItem As New MenuItem("Music")
      Dim moviesSubMenuItem As New MenuItem("Movies")

      ' Add the submenu items to the ChildItems
      ' collection of the root menu item.
      homeMenuItem.ChildItems.Add(musicSubMenuItem)
      homeMenuItem.ChildItems.Add(moviesSubMenuItem)

      ' Add the root menu item to the Items collection 
      ' of the Menu control.
      NavigationMenu.Items.Add(homeMenuItem)
      
    End If
  
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem Constructor Example</h3>
    
      <asp:menu id="NavigationMenu"
        orientation="Vertical"
        target="_blank" 
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
