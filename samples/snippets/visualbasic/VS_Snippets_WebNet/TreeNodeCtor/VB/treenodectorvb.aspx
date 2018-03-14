<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)

    If Not IsPostBack Then

      ' Add the first tree to the TreeView control.
      CreateTree("Section 1")

      ' Add the second tree to the TreeView control.
      CreateTree("Section 2")

    End If

  End Sub

  Sub CreateTree(ByVal NodeText As String)

    ' Create the root node using the default constructor.
    Dim root As TreeNode = New TreeNode
    root.Text = NodeText

    ' Use the ChildNodes property of the root TreeNode to add child nodes.
    ' Create the node using the constructor that takes the text parameter.
    root.ChildNodes.Add(New TreeNode("Topic 1"))

    ' Create the node using the constructor that takes the text and value parameters.
    root.ChildNodes.Add(New TreeNode("Topic 2", "Value 2"))

    ' Create the node using the constructor that takes the text, value, 
    ' and imageUrl parameters.
    root.ChildNodes.Add(New TreeNode("Topic 3", "Value 3", "Image1.jpg"))

    ' Create the node using the constructor that takes the text, value, 
    ' imageUrl, navigateUrl, and target parameters.
    root.ChildNodes.Add(New TreeNode("Topic 4", "Value 4", "Image1.jpg", "http://www.microsoft.com", "_blank"))

    ' Add the root node to the Nodes collection of the TreeView control.
    DynamicTreeView.Nodes.Add(root)

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNode Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNode Constructor Example</h3>
      
      <asp:TreeView id="DynamicTreeView"
         EnableClientScript="false"
         ExpandDepth="2" 
         runat="server">
        
      </asp:TreeView>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
