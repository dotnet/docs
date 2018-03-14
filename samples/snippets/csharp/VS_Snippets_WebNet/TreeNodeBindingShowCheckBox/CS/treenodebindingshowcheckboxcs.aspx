<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void BookTreeView_CheckChanged(Object sender, TreeNodeEventArgs e)
  {
   
    // Display the nodes that have their check box selected.
    Message.Text = "You selected the following check boxes: ";
   
    foreach(TreeNode node in BookTreeView.CheckedNodes)
    {
    
      Message.Text += node.Text + " ";
    
    }
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeBinding ShowCheckBox Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeBinding ShowCheckBox Example</h3>
    
      <asp:treeview id="BookTreeView" 
         datasourceid="BookXmlDataSource"
         expanddepth="2"
         OnTreeNodeCheckChanged="BookTreeView_CheckChanged"   
         runat="server">
         
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" 
            TextField="Title"/>
          <asp:TreeNodeBinding DataMember="Chapter" 
            TextField="Heading"
            ShowCheckBox="True"/>
        </DataBindings>
         
      </asp:treeview>
      
      <asp:xmldatasource id="BookXmlDataSource"  
         datafile="Book.xml"
         runat="server">
      </asp:xmldatasource>
      
      <br/><br/>
      
      <asp:label id="Message"
        runat="server"/>
      
      <hr/>
      
      <asp:button id="SubmitButton"
        Text="Submit"
        runat="server"/>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->
