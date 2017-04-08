<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeBinding Target Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeBinding Target Example</h3>
    
      <!-- Clicking the root node will navigate  -->
      <!-- the user to another page. Because the -->
      <!-- Target property is set to "_blank",   -->
      <!-- the linked page is displayed in a new -->
      <!-- window.                               -->
      <asp:TreeView id="BookTreeView" 
         DataSourceID="BookXmlDataSource"
         runat="server">
          
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" 
            Depth="0" 
            TextField="Title"
            NavigateUrl="~\Page1.aspx"
            Target="_blank"/>
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
