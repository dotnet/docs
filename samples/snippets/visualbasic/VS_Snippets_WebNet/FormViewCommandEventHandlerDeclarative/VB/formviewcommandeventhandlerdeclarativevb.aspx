<!-- <Snippet1> -->
<%@ page language="VB" %>
<%@ import namespace="System.Data"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub EmployeesFormView_ItemCommand(ByVal sender As Object, ByVal e As FormViewCommandEventArgs) Handles EmployeesFormView.ItemCommand

    ' The ItemCommand event is raised when any button within
    ' the FormView control is clicked. Use the CommandName property 
    ' to determine which button was clicked. 
    If e.CommandName = "Display" Then

      ' Use the Row property to retrieve the data row.
      Dim row As FormViewRow = EmployeesFormView.Row

      ' Retrieve the FirstNameLabel and LastNameLabel Label controls 
      ' from data row.
      Dim firstNameLabel As Label = CType(row.FindControl("FirstNameLabel"), Label)
      Dim lastNameLabel As Label = CType(row.FindControl("LastNameLabel"), Label)

      If firstNameLabel IsNot Nothing And lastNameLabel IsNot Nothing Then

        ' Display the employee's name.
        MessageLabel.Text = firstNameLabel.Text & " " & _
          lastNameLabel.Text()
        
      End If
      
    End If
    
  End Sub

  Sub EmployeesFormView_PageIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EmployeesFormView.PageIndexChanged
    
    ' Clear the message label when the user navigates to 
    ' a different record.
    MessageLabel.Text = ""

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" > 
  <head runat="server">
    <title>FormViewCommandEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewCommandEventHandler Example</h3>
        
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated FormView control.            -->       
      <asp:formview id="EmployeesFormView"
        datasourceid="EmployeeSource"
        allowpaging="True"
        headertext="Employee Name"
        runat="server">
      
        <itemtemplate>
        
          <asp:label id="FirstNameLabel"
            text='<%# Eval("FirstName") %>'
            runat="server"/>
          <br/>
          <asp:label id="LastNameLabel"
            text='<%# Eval("LastName") %>'
            runat="server"/>
          <br/>
          <asp:button
            id="DisplayButton"
            text="Display Employee"
            commandname="Display" 
            runat="server"/>
        
        </itemtemplate>
        
      </asp:formview>
            
      <br/><br/>
      
      <asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName] From [Employees]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
          
    </form>
  </body>
</html>

<!-- </Snippet1> -->
