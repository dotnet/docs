<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Declare an array of MenuItemBinding objects.
    Dim bindingArray(NavigationMenu.DataBindings.Count - 1) As MenuItemBinding

    ' Use the CopyTo method to copy the MenuItemBinding objects 
    ' from the collection into the array.
    NavigationMenu.DataBindings.CopyTo(bindingArray, 0)

    ' Display the properties of the MenuItemBinding objects 
    ' in the Bindings collection.
    Message.Text = "The properties of the MenuItemBinding objects are: <br/><br/>"

    Dim binding As MenuItemBinding
    
    For Each binding In bindingArray
    

      Message.Text &= "DataMember=" & binding.TextField & _
        " Depth=" & binding.Depth.ToString() & "<br />"

    Next
    
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemBindingCollection CopyTo Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemBindingCollection CopyTo Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"
        datasourceid="MenuSource"
        runat="server">
        
        <DataBindings>
          <asp:menuitembinding datamember="MapHomeNode" 
            depth="0"
            textfield="title" 
            navigateurlfield="url"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="1"
            textfield="title" 
            navigateurlfield="url"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="2"
            textfield="title" 
            navigateurlfield="url"/>
        </DataBindings>
                
      </asp:menu>
      
      <hr/>
      
      <asp:label id="Message" 
        runat="server"/>
      
      <asp:xmldatasource id="MenuSource"
        datafile="Map.xml"
        runat="server"/>        

    </form>
  </body>
</html>

<!-- </Snippet1> -->
