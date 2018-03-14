<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:XmlDataSource
        runat="server"
        id="XmlDataSource1"
        DataFile="bookstore2.xml"
        XPath="bookstore/genre[@name='fiction']" />

      <asp:Repeater
        runat="server"
        DataSourceID="XmlDataSource1">
        <ItemTemplate>
            <h1><%# XPath ("book/title") %></h1>
            <b>Author:</b>
            <%# XPath ("book/author/firstname") %>
            <%# XPath ("book/author/lastname") %>
            <asp:Repeater
                 DataSource='<%# XPathSelect ("book/chapters") %>'
                 runat="server">
                <ItemTemplate>
                     <%# XPath ("chapter/@name") %>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
  </form>
  </body>
</html>
<!-- </Snippet1> -->