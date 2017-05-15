<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Node_Changed(Object sender, EventArgs e)
  {

    Message.Text = BookTreeView.SelectedNode.Text + " node selected.";

  }

  void Node_Expanded(Object sender, TreeNodeEventArgs e)
  {

    Message.Text = e.Node.Text + " node expanded.";

  }

  void Node_Collapsed(Object sender, TreeNodeEventArgs e)
  {

    Message.Text = "";

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeBinding SelectAction Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeBinding SelectAction Example</h3>
    
      <asp:TreeView id="BookTreeView"
        Font-Names= "Arial"
        ForeColor="Blue"
        DataSourceID="BookXmlDataSource"
        EnableClientScript="false" 
        OnSelectedNodeChanged="Node_Changed"
        OnTreeNodeExpanded="Node_Expanded"
        OnTreeNodeCollapsed="Node_Collapsed"   
        runat="server">
        
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" 
            TextField="Title"
            SelectAction="Expand"/>
          <asp:TreeNodeBinding DataMember="Chapter" 
            TextField="Heading"
            SelectAction="Expand"/>
        </DataBindings>
        
      </asp:TreeView>
      
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
