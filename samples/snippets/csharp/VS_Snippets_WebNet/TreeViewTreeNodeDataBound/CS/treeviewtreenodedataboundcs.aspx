<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Data_Bound(Object sender, TreeNodeEventArgs e)
  {

    // Give the Chapter 2 node a custom image. 
    if(e.Node.Text == "Chapter 2")
    {
      e.Node.ImageUrl="Custom.jpg";
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeView TreeNodeDataBound Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView TreeNodeDataBound Example</h3>
    
      <asp:TreeView id="BookTreeView" 
        DataSourceID="BookXmlDataSource"
        LeafNodeStyle-ImageUrl="Leaf.jpg"
        ParentNodeStyle-ImageUrl="Parent.jpg"
        RootNodeStyle-ImageUrl="Root.jpg"   
        OnTreeNodeDataBound="Data_Bound"
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
