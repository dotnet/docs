<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Get the Classical menu item using the Items
    ' and ChildItems collections.
    Dim item As MenuItem = NavigationMenu.Items(0).ChildItems(0).ChildItems(0)

    ' Create the delimiter array using the PathSeparator value.
    ' This array is used by the the Split method to parse the
    ' value path string. 
    Dim DelimiterArray(1) As Char
    DelimiterArray(0) = NavigationMenu.PathSeparator
    
    ' Parse the value path of the Classical menu item 
    ' using the Split method.
    Dim nodeValues() As String = item.ValuePath.Split(DelimiterArray)
    
    ' Display the original and parsed values.
    Message.Text = "The original value path for the Classical menu item is <b>" & _
      item.ValuePath & "</b>.<br/>"
    Message.Text &= "The individual values that make up the value " & _
      "path are: <br/>"

    Dim menuValue As String
    For Each menuValue In nodeValues
    
      Message.Text &= "- <b>" & menuValue & "</b><br/>"
    
    Next
    
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem ValuePath Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem ValuePath Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="1"
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
      
      <asp:label id="Message" 
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
