<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeViewBinding Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeViewBinding Example</h3>
    
      <!-- Set the Text, ImageUrl, ImageToolTip, -->
      <!-- NavigateUrl, Value, and ToolTip       -->
      <!-- properties of a TreeNodeBinding       -->
      <!-- object declaratively.                 -->   
      <asp:TreeView id="BookTreeView" 
        DataSourceID="BookXmlDataSource"
        Target="_blank" 
        runat="server">
          
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Books" 
            Depth="0" 
            TextField="Text"/>
          <asp:TreeNodeBinding DataMember="Book" 
            Depth="1" 
            Text="Book Title" 
            ImageUrl="Image.jpg"
            ImageToolTip="Book Image" 
            NavigateUrl="http://www.microsoft.com" 
            Value="BookID" 
            ToolTip="Book Information"/>
          <asp:TreeNodeBinding DataMember="Description" 
            Depth="2" 
            TextField="Text"/>
          <asp:TreeNodeBinding DataMember="Price" 
            Depth="2" 
            TextField="Value"/>
        </DataBindings>
         
      </asp:TreeView>
      
      <asp:XmlDataSource id="BookXmlDataSource"  
        DataFile="Booklist.xml"
        runat="server">
      </asp:XmlDataSource>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->
