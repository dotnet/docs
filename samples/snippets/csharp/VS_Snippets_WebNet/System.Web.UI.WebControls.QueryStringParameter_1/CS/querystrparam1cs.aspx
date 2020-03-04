<%@ Page Language="C#" CodeFile="querystrparam1cs.aspx.cs" Inherits="querystrparam1cs_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<!-- <Snippet1> -->
      <asp:ListBox
        id ="ListBox1"
        runat="server"
        DataSourceID="SqlDataSource1"
        DataValueField="EmployeeID"
        DataTextField="LastName" />
    
<!-- Use a query string that includes empId=1 -->
    
<!-- Security Note: The SqlDataSource uses a QueryStringParameter,
     Security Note: which does not perform validation of input from the client.
     Security Note: To validate the value of the QueryStringParameter, handle the Selecting event. -->

      <asp:SqlDataSource
        id="SqlDataSource1"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:MyNorthwind %>"
        SelectCommand="Select EmployeeID, LastName From Employees where EmployeeID = @empId">
        <SelectParameters>
          <asp:QueryStringParameter Name="empId" QueryStringField="empId" />
        </SelectParameters>
      </asp:SqlDataSource>
<!-- </Snippet1> -->
      <hr />
<!-- <Snippet3> -->
      <asp:ListBox
        id ="ListBox2"
        runat="server"
        DataSourceID="AccessDataSource1"
        DataValueField="EmployeeID"
        DataTextField="LastName" />

      <asp:AccessDataSource
        id="AccessDataSource1"
        runat="server"
        DataFile="Northwind.mdb"
        SelectCommand="Select EmployeeID, LastName From Employees where EmployeeID = ?" />
      
<!-- </Snippet3> -->
<!-- <Snippet5> -->
      <asp:GridView
        id ="GridView1"
        runat="server"
        DataSourceID="MyAccessDataSource" />

      <asp:AccessDataSource
        id="MyAccessDataSource"
        runat="server"
        DataFile="Northwind.mdb"
        SelectCommand="Select EmployeeID, LastName, FirstName From Employees where EmployeeID = ?" />
      
<!-- </Snippet5> -->    
    </div>
    </form>
</body>
</html>
