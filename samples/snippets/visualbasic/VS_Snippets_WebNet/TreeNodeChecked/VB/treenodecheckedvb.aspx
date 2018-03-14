<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Data_Bound(ByVal sender As Object, ByVal e As TreeNodeEventArgs)

    ' Check the depth of a node as it is being bound to data.
    ' Initialize the Checked property to true if the depth is 1.
    If e.Node.Depth = 1 Then

      e.Node.Checked = True

    Else

      e.Node.Checked = False

    End If

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNode Checked Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNode Checked Example</h3>
    
      <asp:TreeView id="NewsgroupTreeView" 
        DataSourceID="NewsgroupXmlDataSource"
        OnTreeNodeDataBound="Data_Bound"
        ShowCheckBoxes="All"
        ExpandDepth="2"  
        runat="server">
         
        <DataBindings>
          <asp:TreeNodeBinding DataMember="category" TextField="Name"/>
          <asp:TreeNodeBinding DataMember="group" TextField="Name"/>
        </DataBindings>
         
      </asp:TreeView>
      
      <asp:XmlDataSource id="NewsgroupXmlDataSource"  
        DataFile="Newsgroup.xml"
        runat="server">
      </asp:XmlDataSource>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->
