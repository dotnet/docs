<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    
    If Not IsPostBack Then
      
      ' Create the menu structure.
    
      ' Create the root menu item.
      Dim homeMenuItem As MenuItem
      homeMenuItem = CreateMenuItem("Home", "Home.aspx", "Home")
    
      ' Create the submenu items.
      Dim musicSubMenuItem As MenuItem
      musicSubMenuItem = CreateMenuItem("Music", "Music.aspx", "Music")
    
      Dim moviesSubMenuItem As MenuItem
      moviesSubMenuItem = CreateMenuItem("Movies", "Movies.aspx", "Movies")
    
      ' Add the submenu items to the ChildItems
      ' collection of the root menu item.
      homeMenuItem.ChildItems.Add(musicSubMenuItem)
      homeMenuItem.ChildItems.Add(moviesSubMenuItem)
    
      ' Add the root menu item to the Items collection 
      ' of the Menu control.
      NavigationMenu.Items.Add(homeMenuItem)
      
    End If
    
  End Sub
  
  Function CreateMenuItem(ByVal text As String, ByVal url As String, ByVal toolTip As String) As MenuItem
    
    ' Create a new MenuItem object.
    Dim menuItem As New MenuItem()
    
    ' Set the properties of the MenuItem object using
    ' the specified parameters.
    MenuItem.Text = text
    MenuItem.NavigateUrl = url
    MenuItem.ToolTip = toolTip
    
    Return MenuItem
    
  End Function

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
