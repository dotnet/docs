<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView EmptyDataText Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView EmptyDataText Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        emptydatatext="No records available." 
        runat="server">
        
        <EmptyDataRowStyle BackColor="Red"
          forecolor="White"
          font-size="14"
          font-italic="true" 
          height="100"/> 
        
        <itemtemplate>
        
          <table>
            <tr>
              <td>
                <asp:image id="EmployeeImage"
                  imageurl='<%# Eval("PhotoPath") %>'
                  alternatetext='<%# Eval("LastName") %>' 
                  runat="server"/>
              </td>
              <td>
                <h3><%# Eval("FirstName") %>&nbsp;<%# Eval("LastName") %></h3>      
                <%# Eval("Title") %>        
              </td>
            </tr>
          </table>
        
        </itemtemplate>
          
        <pagersettings position="Bottom"
          mode="NextPrevious"/> 
                  
      </asp:formview>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      
      <!-- The select query for the following SqlDataSource     -->
      <!-- control is intentionally set to return no results    -->
      <!-- to demonstrate the empty data row.                   -->  
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees] Where [EmployeeID]=1000"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->