<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:xmldatasource
        id="XmlDataSource1"
        runat="server" >
        <data>
          <Books>
            <LanguageBooks>
              <Book Title="Pure JavaScript" Author="Wyke, Gilliam, and Ting"/>
              <Book Title="Effective C++ Second Edition" Author="Scott Meyers"/>
              <Book Title="Assembly Language Step-By-Step" Author="Jeff Duntemann"/>
              <Book Title="Oracle PL/SQL" Author="Steven Feuerstein"/>
            </LanguageBooks>
            <SecurityBooks>
              <Book Title="Counter Hack" Author="Ed Skoudis"/>
            </SecurityBooks>
          </Books>
        </data>
        </asp:xmldatasource>

      <!- TreeView uses hierachical data, so the
          XmlDataSource uses an XmlHierarchicalDataSourceView
          when a TreeView is bound to it. -->

      <asp:treeview
        id="TreeView1"
        runat="server"
        datasourceid="XmlDataSource1">
        <databindings>
          <asp:treenodebinding datamember="Book" textfield="Title"/>
        </databindings>
      </asp:treeview>

    </form>
  </body>
</html>
<!-- </Snippet1> -->