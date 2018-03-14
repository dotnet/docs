<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new TreeView control.
    Dim NewTree As TreeView = New TreeView

    ' Set the properties of the TreeView control.
    NewTree.ID = "BookTreeView"
    NewTree.DataSourceID = "BookXmlDataSource"

    ' Create the tree node binding relationship.

    ' Create the root node binding.
    Dim RootBinding As TreeNodeBinding = New TreeNodeBinding
    RootBinding.DataMember = "Book"
    RootBinding.TextField = "Title"

    ' Create the parent node binding.
    Dim ParentBinding As TreeNodeBinding = New TreeNodeBinding
    ParentBinding.DataMember = "Chapter"
    ParentBinding.TextField = "Heading"

    ' Create the leaf node binding.
    Dim LeafBinding As TreeNodeBinding = New TreeNodeBinding
    LeafBinding.DataMember = "Section"
    LeafBinding.TextField = "Heading"

    ' Add bindings to the DataBindings collection.
    NewTree.DataBindings.Add(RootBinding)
    NewTree.DataBindings.Add(ParentBinding)
    NewTree.DataBindings.Add(LeafBinding)

    ' Manually register the event handler for the TreeNodeExpanded event.
    AddHandler NewTree.TreeNodeExpanded, AddressOf Node_Expand

    ' Add the TreeView control to the Controls collection of the PlaceHolder control.
    ControlPlaceHolder.Controls.Add(NewTree)

  End Sub

  Sub Node_Expand(ByVal sender As Object, ByVal e As TreeNodeEventArgs)

    ' Display the expanded node.
    Message.Text = "You expanded: " & e.Node.Text

  End Sub

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
