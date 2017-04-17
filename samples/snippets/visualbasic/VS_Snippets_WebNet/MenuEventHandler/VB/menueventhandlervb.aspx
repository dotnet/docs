<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Create a new Menu control.
    Dim newMenu As New Menu()
          
    ' Set the properties of the Menu control.
    newMenu.ID = "NavigationMenu"
    newMenu.Orientation = Orientation.Vertical
    newMenu.Target = "_blank"

    ' Specify the data source for the menu.
    newMenu.DataSourceID = "MenuSource"

    ' Programmatically register the event-handling method
    ' for the MenuItemClick event of a Menu control. 
    AddHandler newMenu.MenuItemClick, AddressOf NavigationMenu_MenuItemClick

    ' Add the Menu control to the Controls collection
    ' of the PlaceHolder control.
    MenuPlaceHolder.Controls.Add(newMenu)
    
  End Sub

  Sub NavigationMenu_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs)

    ' Display the text of the menu item selected by the user.
    Message.Text = "You selected " & e.Item.Text & "."

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuEventHandler Example</h3>
    
      <asp:placeholder id="MenuPlaceHolder"
        runat="server"/>
        
      <asp:sitemapdatasource id="MenuSource"
        runat="server"/>
        
      <hr/>
      
      <asp:label id="Message"
        runat="server"/>  

    </form>
  </body>
</html>

<!-- </Snippet1> -->
