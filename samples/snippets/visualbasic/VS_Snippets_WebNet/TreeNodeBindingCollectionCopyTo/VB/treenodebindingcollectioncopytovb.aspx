<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create an array of TreeNodeBinding objects and then use the
    ' CopyTo method to copy the contents of the DataBindings collection
    ' to the array.
    Dim bindings(BookTreeView.DataBindings.Count - 1) As TreeNodeBinding
    BookTreeView.DataBindings.CopyTo(bindings, 0)

    ' Iterate through the array and display the value of the text field
    ' property of each TreeNodeBinding object.
    MessageLabel.Text = "The field names for each node level are: <br/>"

    
    Dim binding As TreeNodeBinding
    For Each binding In bindings

      MessageLabel.Text &= binding.TextField & "<br/>"

    Next

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeBindingCollection CopyTo Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeBindingCollection CopyTo Example</h3>
    
      <asp:TreeView id="BookTreeView" 
         DataSourceID="BookXmlDataSource"
         runat="server">
         
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" 
            TextField="Title"/>
          <asp:TreeNodeBinding DataMember="Chapter" 
            TextField="Heading"/>
          <asp:TreeNodeBinding DataMember="Section" 
            TextField="Subject"/>
        </DataBindings>
         
      </asp:TreeView>
      
      <asp:XmlDataSource id="BookXmlDataSource"  
         DataFile="Book.xml"
         runat="server">
      </asp:XmlDataSource>
    
      <br/>
    
      <asp:Label id="MessageLabel" runat="server"/>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->
