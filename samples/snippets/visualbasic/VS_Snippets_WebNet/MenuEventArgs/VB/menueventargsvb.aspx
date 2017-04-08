<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub MenuItemDataBound_NavigationMenu(ByVal sender As Object, ByVal e As MenuEventArgs)
  
    ' Display an image for the Home menu item only by
    ' setting its ImageUrl property.
    If e.Item.Text = "Home" Then
    
      e.Item.ImageUrl = "Images\Home.jpg"
      
    End If
      
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuEventArgs Example</title>
</head>
<body>
    <form id="Form1" runat="server">
    
      <h3>MenuEventArgs Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        datasourceid="menusource" 
        onmenuitemdatabound="MenuItemDataBound_NavigationMenu" 
        runat="server">

      </asp:menu>
      
      <asp:SiteMapDataSource id="MenuSource"
        Runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
