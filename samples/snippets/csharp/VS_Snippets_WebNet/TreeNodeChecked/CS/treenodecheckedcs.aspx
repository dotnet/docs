<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Data_Bound(Object sender, TreeNodeEventArgs e)
  {

    // Check the depth of a node as it is being bound to data.
    // Initialize the Checked property to true if the depth is 1.
    if(e.Node.Depth == 1)
    {

      e.Node.Checked = true;

    }
    else
    {

      e.Node.Checked = false;

    }

  }

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
