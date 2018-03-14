<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub MenuItemClick_NavigationMenu(ByVal sender As Object, ByVal e As MenuEventArgs)
  
    ' Use the Parent property to access the 
    ' parent menu item of the menu item clicked
    ' by the user.
    Dim parentItem As MenuItem = e.Item.Parent

    ' Display the parent menu item.
    If parentItem IsNot Nothing Then

      Message.Text = "You are in the " & parentItem.Text & _
        " category."
    
    Else
    
      Message.Text = "The selected menu item is a root menu item."
      
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem Parent Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem Parent Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        onmenuitemclick="MenuItemClick_NavigationMenu"
        runat="server">
      
        <items>
          <asp:menuitem text="Home"
            tooltip="Home">
            <asp:menuitem text="Music"
              tooltip="Music">
              <asp:menuitem text="Classical"
                tooltip="Classical"/>
              <asp:menuitem text="Rock"
                tooltip="Rock"/>
              <asp:menuitem text="Jazz"
                tooltip="Jazz"/>
            </asp:menuitem>
            <asp:menuitem text="Movies"
              tooltip="Movies">
              <asp:menuitem text="Action"
                tooltip="Action"/>
              <asp:menuitem text="Drama"
                tooltip="Drama"/>
              <asp:menuitem text="Musical"
                tooltip="Musical"/>
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
