<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // Create a new TreeView control.
    TreeView NewTree = new TreeView();

    // Set the properties of the TreeView control.
    NewTree.ID = "BookTreeView";
    NewTree.DataSourceID = "BookXmlDataSource";

    // Create the tree node binding relationship.

    // Create the root node binding.
    TreeNodeBinding RootBinding = new TreeNodeBinding();
    RootBinding.DataMember = "Book";
    RootBinding.TextField = "Title";

    // Create the parent node binding.
    TreeNodeBinding ParentBinding = new TreeNodeBinding();
    ParentBinding.DataMember = "Chapter";
    ParentBinding.TextField = "Heading";

    // Create the leaf node binding.
    TreeNodeBinding LeafBinding = new TreeNodeBinding();
    LeafBinding.DataMember = "Section";
    LeafBinding.TextField = "Heading";

    // Add bindings to the DataBindings collection.
    NewTree.DataBindings.Add(RootBinding);
    NewTree.DataBindings.Add(ParentBinding); 
    NewTree.DataBindings.Add(LeafBinding);

    // Manually register the event handler for the TreeNodeExpanded event.
    NewTree.TreeNodeExpanded += new TreeNodeEventHandler(this.Node_Expand);

    // Add the TreeView control to the Controls collection of the PlaceHolder control.
    ControlPlaceHolder.Controls.Add(NewTree);

  }

  void Node_Expand(Object sender, TreeNodeEventArgs e)
  {

    // Display the expanded node.
    Message.Text = "You expanded: " + e.Node.Text;

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeView TreeNodeEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView TreeNodeEventHandler Example</h3>
      
      <asp:PlaceHolder id="ControlPlaceHolder" runat="server">
      </asp:PlaceHolder>
   
      <asp:XmlDataSource id="BookXmlDataSource"  
        DataFile="book.xml"
        runat="server">
      </asp:XmlDataSource>
      
      <br /><br />
      
      <asp:Label id="Message" runat="server"/>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->
