<!-- <Snippet1> -->
<%@Page  Language="VB" %>
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
        datasourcemode="DataSet"
        datafile="~/App_Data/Northwind.mdb"
        selectcommand="SELECT EmployeeID,FirstName,LastName,Title FROM Employees"
        updatecommand="Update Employees SET FirstName=?,LastName=?,Title=? WHERE EmployeeID=@EmployeeID">
      </asp:accessdatasource>

      <asp:gridview
        id="GridView1"
        runat="server"
        autogeneratecolumns="False"
        datakeynames="EmployeeID"
        autogenerateeditbutton="True"
        datasourceid="AccessDataSource1">
        <columns>
          <asp:boundfield headertext="First Name" datafield="FirstName" />
          <asp:boundfield headertext="Last Name" datafield="LastName" />
          <asp:boundfield headertext="Title" datafield="Title" />
        </columns>
      </asp:gridview>

    </form>
  </body>
</html>
<!-- </Snippet1> -->