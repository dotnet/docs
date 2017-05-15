<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeeFormView_ItemDeleting(Object sender, FormViewDeleteEventArgs e)
  {
    // Get the employee ID, name, and job title from the Keys and Values
    // properties.
    String keyValue = e.Keys["EmployeeID"].ToString();
    String employeeName = e.Values["FirstName"].ToString() +
      " " + e.Values["LastName"].ToString();
    String title = e.Values["Title"].ToString();

    // Cancel the delete operation if the user attempts to 
    // delete a protected record. In this example, records for
    // employees with a "Sales Manager" job title are protected.
    if (title.Equals("Sales Manager"))
    {
      e.Cancel = true;
      MessageLabel.Text = "You cannot delete record " +
        e.RowIndex.ToString() + ". " + employeeName +
        " (Employee Number " + keyValue.ToString() +
        ") is protected.";
    }

  }
   
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewDeleteEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewDeleteEventHandler Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        onitemdeleting="EmployeeFormView_ItemDeleting"  
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
                <asp:label id="FirstNameLabel"
                  text='<%#Bind("FirstName")%>'
                  font-bold="true"
                  runat="server"/>
                <asp:label id="LastNameLabel"
                  text='<%#Bind("LastName")%>'
                  font-bold="true"
                  runat="server"/>
                <br/>     
                <asp:label id="TitleLabel"
                  text='<%#Bind("Title")%>'
                  runat="server"/>        
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:button id="DeleteButton"
                  text="Delete Record"
                  commandname="Delete"
                  runat="server" />
              </td>
            </tr>
          </table>
        
        </itemtemplate>         
                  
      </asp:formview>
      
      <asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        deletecommand="Delete [Employees] Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->