<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
  
    ' If the Menu control contains any root menu items, perform a
    ' preorder traversal of the tree and display the text of 
    ' menu items with a depth of 2.
    If NavigationMenu.Items.Count > 0 Then

      ' Iterate through the root menu items in the Items collection.
      Dim item As MenuItem
      
      For Each item In NavigationMenu.Items

        DisplayChildMenuText(item)

      Next

    Else

      Message.Text = "The Menu control does not have any items."

    End If
      
  End Sub

  Sub DisplayChildMenuText(ByVal item As MenuItem)

    ' Use the Depth property to determine the depth of a 
    ' menu item. Display only items with a depth of 2.
    If item.Depth = 2 Then
      Message.Text += item.Text + "<br />"
    End If

    ' Iterate through the child menu items of the parent menu item 
    ' passed into this method, and display their values.
    Dim childItem As MenuItem
    
    For Each childItem In item.ChildItems

      ' Recursively call the DisplayChildMenuText method to
      ' traverse the tree.
      DisplayChildMenuText(childItem)

    Next

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem Depth Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem Depth Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
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
      
      Menu items with a depth of 2:<br/><br/>
      <asp:label id="Message" 
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
