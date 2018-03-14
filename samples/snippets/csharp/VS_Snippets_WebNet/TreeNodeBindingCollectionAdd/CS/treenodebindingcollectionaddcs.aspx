<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // Use the Remove method to remove the TreeNodeBinding object
    // for the third-level nodes (index 2).
    TreeNodeBinding oldBinding = BookTreeView.DataBindings[2];
    BookTreeView.DataBindings.Remove(oldBinding);

    // Create a new TreeNodeBinding object and set its properties.
    TreeNodeBinding newBinding = new TreeNodeBinding();
    newBinding.DataMember = "Section";
    newBinding.TextField = "Subject";

    // Use the Add method to add the TreeNodeBinding object to the 
    // DataBindings collection.
    BookTreeView.DataBindings.Add(newBinding);

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeBindingCollection Add and Remove Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeBindingCollection Add and Remove Example</h3>
    
      <asp:TreeView id="BookTreeView" 
        DataSourceID="BookXmlDataSource"
        runat="server">
         
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" TextField="Title"/>
          <asp:TreeNodeBinding DataMember="Chapter" TextField="Heading"/>
          <asp:TreeNodeBinding DataMember="Section" TextField="Heading"/>
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
