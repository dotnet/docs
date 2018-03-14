<!-- <Snippet1> -->
<%@ page language="C#" %>
<%@ import namespace="System.Data"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeesFormView_ItemCommand(Object sender, FormViewCommandEventArgs e)
  {

    // The ItemCommand event is raised when any button within
    // the FormView control is clicked. Use the CommandName property 
    // to determine which button was clicked. 
    if (e.CommandName == "Display")
    {

      // Use the Row property to retrieve the data row.
      FormViewRow row = EmployeesFormView.Row;

      // Retrieve the FirstNameLabel and LastNameLabel Label controls 
      // from data row.
      Label firstNameLabel = (Label)row.FindControl("FirstNameLabel");
      Label lastNameLabel = (Label)row.FindControl("LastNameLabel");

      if (firstNameLabel != null && lastNameLabel != null)
      {
        // Display the employee's name.
        MessageLabel.Text = firstNameLabel.Text + " " + 
          lastNameLabel.Text;
      }
      
    }
    
  }

  void EmployeesFormView_PageIndexChanged(Object sender, EventArgs e)
  {
    
    // Clear the message label when the user navigates to 
    // a different record.
    MessageLabel.Text = "";

  }

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
        onitemcommand="EmployeesFormView_ItemCommand"
        onpageindexchanged="EmployeesFormView_PageIndexChanged"
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
