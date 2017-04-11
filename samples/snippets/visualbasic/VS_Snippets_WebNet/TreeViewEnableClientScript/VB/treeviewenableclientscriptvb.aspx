<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeView EnableClientScript Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView EnableClientScript Example</h3>
    
      <asp:TreeView id="BookTreeView" 
        DataSourceID="BookXmlDataSource"
        EnableClientScript="true"
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
