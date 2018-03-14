<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub NavigationMenu_MenuItemDataBound(ByVal sender As Object, ByVal e As MenuEventArgs)

    ' Get the menu item being bound to data.
    Dim item As MenuItem = e.Item

    ' Use the Selected property to select the Home 
    ' menu item when the page is first loaded.
    If item.Text = "Home" Then
    
      item.Selected = True
    
    End If
      
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem Selected Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem Selected Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"
        datasourceid="MenuSource"
        onmenuitemdatabound="NavigationMenu_MenuItemDataBound" 
        runat="server">
        
        <staticselectedstyle backcolor="Yellow"/>
        
      </asp:menu>
      
      <asp:sitemapdatasource id="MenuSource"
        runat="server"/>        

    </form>
  </body>
</html>

<!-- </Snippet1> -->
