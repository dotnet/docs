<!--<Snippet2>-->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS" assembly="Samples.AspNet.CS" %>
<%@Page  Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:accessdatasource
          id="AccessDataSource1"
          runat="server"
          datasourcemode="DataReader"
          datafile="Northwind.mdb"
          selectcommand="SELECT OrderID FROM Orders WHERE EmployeeID=2">
      </asp:accessdatasource>

      <br />
      <aspSample:debuginfocontrol
          id="DebugInfoControl1"
          runat="server"
          controlid="AccessDataSource1" />

    </form>
  </body>
</html>
<!--</Snippet2>-->