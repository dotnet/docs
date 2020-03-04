<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Sub Page_Load(ByVal sender As [Object], ByVal e As EventArgs) 
    
    If Not IsPostBack Then
        
        ' Use the Add and RemoveAt methods to programmatically 
        ' remove the third level menu item style and replace 
        ' it with a new style, in this case replacing the green background
        ' and yellow text with the blue background and white text. 
        Dim newStyle As New MenuItemStyle()
        newStyle.BackColor = System.Drawing.Color.Blue
        newStyle.ForeColor = System.Drawing.Color.White
        
        ' Remove the last of the three menu item styles. Note that
        ' since the collection has a zero-based index, the third
        ' entry has an index value of 2.
        MainMenuID.LevelMenuItemStyles.RemoveAt(2)
        MainMenuID.LevelMenuItemStyles.Add(newStyle)
    End If
 
End Sub 'Page_Load
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemStyleCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemStyleCollection Example</h3>
         <!--Add MenuItemStyle objects to the MenuItemStyleCollection -->
         <!--using LevelMenuItemStyles.   -->
         <!--Note that each menu item style represents a level in the menu -->

      <asp:Menu id="MainMenuID"
       Font-Names= "Arial"
        ForeColor="Blue"
        runat="server">
         
         <LevelMenuItemStyles>
         <asp:MenuItemStyle BackColor="Azure" 
             Font-Italic="true"
             Font-Names="Arial"
             ForeColor="Black" />
         
           <asp:MenuItemStyle BackColor="Black" 
             Font-Italic="false"
             Font-Names="Arial"
             ForeColor="White" />
             
         <asp:MenuItemStyle BackColor="Green" 
             Font-Italic="true"
             Font-Names="Arial"
             ForeColor="Yellow" />
       
         </LevelMenuItemStyles>

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

        
      </asp:Menu>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
