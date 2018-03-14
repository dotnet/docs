<!-- <Snippet1> -->
<%@ Page LANGUAGE="VB" SMARTNAVIGATION="false" %>
<%@ Import Namespace="System.Xml" %>

<script runat="server" >

  Private Sub Button1_Click(sender As Object, e As EventArgs)

    Dim myXml As New XmlDocument
    myXml = CType(XmlSource.GetXmlDocument(), XmlDocument)

    Dim path As String = "bookstore/book/@publicationdate"
    Dim nodeList As XmlNodeList = myXml.SelectNodes(path)

    Dim aDate As XmlNode
    For Each aDate In  nodeList
      Dim helper As Integer = Int32.Parse(aDate.Value) + 2
      aDate.Value = helper.ToString()
    Next aDate

    XmlSource.Save()
    Repeater1.DataBind()

  End Sub 'Button1_Click
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" runat="server" >

      <asp:XmlDataSource
        runat="server"
        ID="XmlSource"
        XPath="bookstore/book[@genre='novel']"
        DataFile="Booksort2.xml"
        EnableViewState="True"
        EnableCaching="False" />

      <asp:Repeater
        runat="server"
        ID="Repeater1"
        DataSourceID="XmlSource" >
          <ItemTemplate >
            <h1><%# XPath ("title/text()") %> </h1>
              <b>Author:</b><%# XPath ("author/first-name/text()") %> <%# XPath ("author/last-name/text()") %>
              <b>PublicationDate:</b><%# XPath ("@publicationdate") %>
              <b>Price:</b><%# XPath ("price/text()") %>
          </ItemTemplate>
      </asp:Repeater>


      <p><asp:Button
        runat="server"
        ID="Button1"
        onclick="Button1_Click"
        Text="Add 2 years to the Publication Date!" /></p>
</form>
</body>
</html>
<!-- </Snippet1> -->