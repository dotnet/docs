<!-- <Snippet1> -->

<%@ page language="VB" %>
<%@ import namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub EmployeeFormView_ItemCreated(ByVal sender As Object, ByVal e As EventArgs)
  
    ' Use the Row property to retrieve the data row from 
    ' the FormView control.
    Dim row As FormViewRow = EmployeeFormView.Row
    
    ' Get the data item bound to the FormView control.
    Dim rowView As DataRowView = CType(EmployeeFormView.DataItem, DataRowView)

    ' Set the ToolTip property of the data row. 
    row.ToolTip = rowView("FirstName").ToString() & " " & _
      rowView("LastName").ToString()
  
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView Row Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView Row Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        onitemcreated="EmployeeFormView_ItemCreated"  
        runat="server">
        
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
          
      </asp:formview>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->