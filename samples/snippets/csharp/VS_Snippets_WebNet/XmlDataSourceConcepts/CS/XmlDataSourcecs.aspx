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
        id="PeopleDataSource"
        runat="server"
        DataFile="~/App_Data/people.xml" />

      <asp:TreeView
        id="PeopleTreeView"
        runat="server"
        DataSourceID="PeopleDataSource">
        <DataBindings>
          <asp:TreeNodeBinding DataMember="LastName"    TextField="#InnerText" />
          <asp:TreeNodeBinding DataMember="FirstName"   TextField="#InnerText" />
          <asp:TreeNodeBinding DataMember="Street"      TextField="#InnerText" />
          <asp:TreeNodeBinding DataMember="City"        TextField="#InnerText" />
          <asp:TreeNodeBinding DataMember="Region"      TextField="#InnerText" />
          <asp:TreeNodeBinding DataMember="ZipCode"     TextField="#InnerText" />
          <asp:TreeNodeBinding DataMember="Title"       TextField="#InnerText" />
          <asp:TreeNodeBinding DataMember="Description" TextField="#InnerText" />
        </DataBindings>
      </asp:TreeView>

    </form>
  </body>
</html>
<!-- </Snippet1> -->