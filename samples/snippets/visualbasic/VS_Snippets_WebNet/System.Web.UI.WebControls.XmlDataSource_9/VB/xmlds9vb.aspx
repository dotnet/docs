<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Xml.Xsl" %>

<script runat="server">
Private Sub TransformEventHandler(sender As Object, e as EventArgs)

  ' Add a dynamic transformation argument.
  Dim d As New DateTime
  d = DateTime.Now.AddDays(20)

  'Create an XsltArgumentList.
  Dim xslArg As XsltArgumentList = New XsltArgumentList
  xslArg.AddParam("purchdate", "", d.ToShortDateString())

  Dim aXmlDataSource as XmlDataSource = CType(sender, XmlDataSource)
  aXmlDataSource.TransformArgumentList = xslArg

End Sub ' TransformEventHandler
</script>

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
        datafile="bookstore.xml"
        transformfile="bookswithdiscount.xsl"
        ontransforming="TransformEventHandler" />

        <!- TreeView uses hierachical data, so the
            XmlDataSource uses an XmlHierarchicalDataSourceView
            when a TreeView is bound to it. -->

      <asp:treeview
        id="TreeView1"
        runat="server"
        datasourceid="XmlDataSource1">
        <databindings>
          <asp:treenodebinding depth="1" datamember="genre"
            textfield="name" valuefield="name"/>
          <asp:treenodebinding depth="2" datamember="book"
            textfield="title" valuefield="title"/>
          <asp:treenodebinding depth="3" datamember="chapter"
            textfield="name" valuefield="num"/>
        </databindings>
      </asp:treeview>

    </form>
  </body>
</html>
<!-- </Snippet1> -->