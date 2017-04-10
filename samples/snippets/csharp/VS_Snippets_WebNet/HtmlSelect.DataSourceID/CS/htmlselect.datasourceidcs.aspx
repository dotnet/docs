<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HtmlSelect.DataSourceID</title>
</head>
<body>
<form id="Form1" runat="server">
  <div>

    <h3> HtmlSelect.DataSourceID Example </h3>

    <p>Select an item from the list</p>

    <select id="Select1"
      name="Select1"
      datasourceid="SqlDataSource1"
      datatextfield="ProductName"
      runat="server">
    </select>

    <asp:sqldatasource id="SqlDataSource1"          
      connectionstring="workstation id=localhost;integrated security=SSPI;initial catalog=Northwind"
      selectcommand="SELECT * FROM [Products] Where ProductID <= 5"
      runat="server">
    </asp:sqldatasource>

  </div>
</form>
</body>
</html>
<!--</Snippet1>-->
