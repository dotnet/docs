<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Data_Bound(Object sender, TreeNodeEventArgs e)
  {

    // Determine the depth of a node as it is bound to data.
    // If the depth is 1, show a check box.
    if(e.Node.Depth == 1)
    {

      e.Node.ShowCheckBox = true;

    }
    else
    {

      e.Node.ShowCheckBox = false;

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNode ShowCheckBox Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNode ShowCheckBox Example</h3>
    
      <asp:TreeView id="BookTreeView" 
         DataSourceID="BookXmlDataSource"
         OnTreeNodeDataBound="Data_Bound"
         ShowCheckBoxes="None"
         ExpandDepth="2"  
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
