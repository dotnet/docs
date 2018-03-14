<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Node_Changed(ByVal sender As Object, ByVal e As EventArgs)

    Message.Text = BookTreeView.SelectedNode.Text & " node selected."

  End Sub

  Sub Node_Expanded(ByVal sender As Object, ByVal e As TreeNodeEventArgs)

    Message.Text = e.Node.Text & " node expanded."

  End Sub

  Sub Node_Collapsed(ByVal sender As Object, ByVal e As TreeNodeEventArgs)

    Message.Text = ""

  End Sub

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
