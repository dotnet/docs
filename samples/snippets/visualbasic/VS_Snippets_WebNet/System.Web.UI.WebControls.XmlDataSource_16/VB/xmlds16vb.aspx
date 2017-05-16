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
        runat="server"
        datafile="books.xml"
        enablecaching="True"
        cacheduration="60"
        cacheexpirationPolicy="Sliding" />

      <!- TreeView uses hierachical data, so the
          XmlDataSource uses an XmlHierarchicalDataSourceView
          when a TreeView is bound to it. -->

      <asp:treeview
        id="TreeView1"
        runat="server"
        datasourceid="XmlDataSource1">
        <databindings>
          <asp:treenodebinding datamember="book" textfield="title"/>
        </databindings>
      </asp:treeview>

    </form>
  </body>
</html>
<!-- </Snippet1> -->