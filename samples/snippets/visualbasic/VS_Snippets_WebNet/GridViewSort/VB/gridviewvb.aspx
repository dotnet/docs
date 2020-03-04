<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView Example</h3>

                
<!-- <Snippet2> -->
<asp:GridView ID="EmployeesGridView" 
  DataSourceID="EmployeesSqlDataSource" 
  DataKeyNames="EmployeeID" 
  AllowSorting="True"
  RunAt="Server" />
   
<asp:SqlDataSource ID="EmployeesSqlDataSource"  
  SelectCommand="SELECT EmployeeID, LastName, FirstName FROM Employees" 
  Connectionstring="<%$ ConnectionStrings:NorthwindConnectionString %>" 
  RunAt="server" />
<!-- </Snippet2> -->
  
      </form>
  </body>
</html>

