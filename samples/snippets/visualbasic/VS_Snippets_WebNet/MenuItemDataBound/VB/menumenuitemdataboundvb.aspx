<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub NavigationMenu_MenuItemDataBound(ByVal sender As Object, ByVal e As MenuEventArgs)
  
    ' Modify the text of the Home menu item by 
    ' adding parenthesis around the text. 
    If e.Item.Text = "Home" Then
    
      e.Item.Text = "(" & e.Item.Text & ")"
    
    End If
      
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu MenuItemDataBound Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu MenuItemDataBound Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"
        datasourceid="MenuSource"
        onmenuitemdatabound="NavigationMenu_MenuItemDataBound"    
        runat="server">

      </asp:menu>
      
      <asp:SiteMapDataSource id="MenuSource"
        runat="server"/>        

    </form>
  </body>
</html>

<!-- </Snippet1> -->
