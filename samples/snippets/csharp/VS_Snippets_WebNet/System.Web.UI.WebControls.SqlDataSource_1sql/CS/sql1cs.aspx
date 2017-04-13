<!-- <Snippet1> -->
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          DataSourceMode="DataReader"
          ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
          SelectCommand="SELECT LastName FROM Employees">
      </asp:SqlDataSource>

      <asp:ListBox
          id="ListBox1"
          runat="server"
          DataTextField="LastName"
          DataSourceID="SqlDataSource1">
      </asp:ListBox>

    </form>
  </body>
</html>
<!-- </Snippet1> -->