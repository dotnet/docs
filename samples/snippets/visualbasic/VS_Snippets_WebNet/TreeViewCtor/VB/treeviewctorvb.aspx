<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new TreeView control.
    Dim NewTree As New TreeView

    ' Set the properties of the TreeView control.
    NewTree.ID = "BookTreeView"
    NewTree.DataSourceID = "BookXmlDataSource"

    ' Create the tree node binding relationship.

    ' Create the root node binding.
    Dim RootBinding As New TreeNodeBinding
    RootBinding.DataMember = "Book"
    RootBinding.TextField = "Title"

    ' Create the parent node binding.
    Dim ParentBinding As New TreeNodeBinding
    ParentBinding.DataMember = "Chapter"
    ParentBinding.TextField = "Heading"

    ' Create the leaf node binding.
    Dim LeafBinding As New TreeNodeBinding
    LeafBinding.DataMember = "Section"
    LeafBinding.TextField = "Heading"

    ' Add bindings to the DataBindings collection.
    NewTree.DataBindings.Add(RootBinding)
    NewTree.DataBindings.Add(ParentBinding)
    NewTree.DataBindings.Add(LeafBinding)

    ' Manually register the event handler for the SelectedNodeChanged event.
    AddHandler NewTree.SelectedNodeChanged, AddressOf Node_Change

    ' Add the TreeView control to the Controls collection of the PlaceHolder control.
    ControlPlaceHolder.Controls.Add(NewTree)

  End Sub

  Sub Node_Change(ByVal sender As Object, ByVal e As EventArgs)

    ' Retrieve the TreeView control from the Controls collection of the PlaceHolder control.
    Dim LocalTree As TreeView = CType(ControlPlaceHolder.FindControl("BookTreeView"), TreeView)

    ' Display the selected node.
    Message.Text = "You selected: " & LocalTree.SelectedNode.Text

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeView Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView Constructor Example</h3>
      
      <asp:PlaceHolder id="ControlPlaceHolder" runat="server">
      </asp:PlaceHolder>
   
      <asp:XmlDataSource id="BookXmlDataSource"  
        DataFile="Book.xml"
        runat="server">
      </asp:XmlDataSource>
      
      <br /><br />
      
      <asp:Label id="Message" runat="server"/>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->
