<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeViewBinding DataMember and Depth Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeViewBinding DataMember and Depth Example</h3>
    
      <!-- Set the DataMember and Depth properties of a -->
      <!-- TreeNodeBinding object declaratively. You  -->
      <!-- can render items at the same node level    -->
      <!-- by setting each item's Depth property to   -->
      <!-- the same value.                -->
      <asp:TreeView id="BookTreeView" 
        DataSourceID="BookXmlDataSource"
        runat="server">
          
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" Depth="0" TextField="Title"/>
          <asp:TreeNodeBinding DataMember="Chapter" Depth="1" TextField="Heading"/>
          <asp:TreeNodeBinding DataMember="Appendix" Depth="1" TextField="Heading"/>
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
