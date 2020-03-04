<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // Create an array of TreeNodeBinding objects and then use the
    // CopyTo method to copy the contents of the DataBindings collection
    // to the array.
    TreeNodeBinding[] bindings = new TreeNodeBinding[BookTreeView.DataBindings.Count];
    BookTreeView.DataBindings.CopyTo(bindings, 0);

    // Iterate through the array and display the value of the text field
    // property of each TreeNodeBinding object.
    MessageLabel.Text = "The field names for each node level are: <br/>";

    foreach (TreeNodeBinding binding in bindings)
    {

      MessageLabel.Text += binding.TextField + "<br/>";

    }

  }

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
