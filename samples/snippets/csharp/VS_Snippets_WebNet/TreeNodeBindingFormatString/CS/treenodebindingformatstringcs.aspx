<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeBinding FormatString Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeBinding FormatString Example</h3>
    
      <!-- Use the FormatString property to apply   -->
      <!-- a custom format string to the root node. -->
      <!-- The placeholder ({0}) is automatically   -->
      <!-- replaced with the value of the field     -->
      <!-- specified in the TextField property.     -->
      <asp:TreeView id="BookTreeView" 
         DataSourceID="BookXmlDataSource"
         runat="server">
          
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" 
            Depth="0"
            TextField="Title" 
            FormatString="Best Seller: {0}"/>
          <asp:TreeNodeBinding DataMember="Chapter" 
            Depth="1" 
            TextField="Heading"/>
          <asp:TreeNodeBinding DataMember="Appendix" 
            Depth="1" 
            TextField="Heading"/>
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
