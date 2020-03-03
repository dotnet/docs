<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB"
    Assembly="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>IDataItemContainer - VB Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

      <aspSample:SimpleSpreadsheetControl
          id="SimpleSpreadsheet1"
          runat="server"
          datasourceid="AccessDataSource1" />

      <asp:accessdatasource
          id="AccessDataSource1"
          runat="server"
          datasourcemode="DataReader"
          datafile="Northwind.mdb"
          SelectCommand="SELECT OrderID,CustomerID,OrderDate,RequiredDate,ShippedDate
          FROM Orders WHERE EmployeeID =
          (SELECT EmployeeID FROM Employees WHERE LastName = 'King')">
      </asp:accessdatasource>

    </form>
  </body>
</html>
<!-- </Snippet1> -->