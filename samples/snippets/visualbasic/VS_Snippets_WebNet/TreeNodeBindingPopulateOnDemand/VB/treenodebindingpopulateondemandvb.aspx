<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a TreeNodeBinding object and set its 
    ' properties.
    Dim binding As TreeNodeBinding = New TreeNodeBinding
    binding.DataMember = "Section"
    binding.Depth = 2
    binding.TextField = "Heading"

    ' Set the PopulateOnDemand property of the
    ' TreeNodeBinding object programmatically.
    binding.PopulateOnDemand = False

    ' Add the TreeNodeBinding object to the DataBindings
    ' collection of the TreeView control.
    BookTreeView.DataBindings.Add(binding)

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeBinding PopulateOnDemand Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeBinding PopulateOnDemand Example</h3>
    
      <asp:TreeView id="BookTreeView" 
        DataSourceID="BookXmlDataSource"
        ExpandDepth="2"  
        runat="server">
         
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" 
            TextField="Title"/>
          <asp:TreeNodeBinding DataMember="Chapter" 
            TextField="Heading"
            PopulateOnDemand="False"/>
          <asp:TreeNodeBinding DataMember="Section" 
            TextField="Heading"/>
        </DataBindings>
         
      </asp:TreeView>
      
      <asp:XmlDataSource id="BookXmlDataSource"  
        DataFile="Book.xml"
        runat="server">
      </asp:XmlDataSource>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->
