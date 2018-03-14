<!-- <Snippet1> -->

<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
  
    If Not IsPostBack Then

      ' Create a new MenuItemBinding object.
      Dim binding As New MenuItemBinding()

      ' Set the MenuItemBinding object's properties.
      binding.TextField = "Title"
      binding.ValueField = "Description"
      binding.ImageUrlField = "ImageUrl"
      binding.ToolTipField = "ToolTip"

      ' Add the MenuItemBinding object to the 
      ' DataBindings collection of the Menu control.
      NavigationMenu.DataBindings.Add(binding)
    
    End If
      
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemBinding Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>MenuItemBinding Constructor Example</h3>

      <asp:menu id="NavigationMenu"
        datasourceid="MenuSource"
        runat="server">        
      </asp:menu>

      <asp:xmldatasource id="MenuSource"
        datafile="MenuDepth.xml"
        runat="server"/> 

    </form>
  </body>
</html>

<!-- </Snippet1> -->