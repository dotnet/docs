<!-- <Snippet5> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:XmlDataSource
        id="PeopleDataSource"
        runat="server"
        TransformFile="~/App_Data/names.xsl"
        DataFile="~/App_Data/people.xml" />

      <asp:TreeView
        id="PeopleTreeView"
        runat="server"
        DataSourceID="PeopleDataSource">
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Name"   TextField="#InnerText" />
        </DataBindings>
      </asp:TreeView>

    </form>
  </body>
</html>
<!-- </Snippet5> -->