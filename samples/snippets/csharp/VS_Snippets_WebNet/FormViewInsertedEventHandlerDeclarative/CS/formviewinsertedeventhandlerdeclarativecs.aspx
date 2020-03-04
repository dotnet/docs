<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeeFormView_ItemInserted(Object sender, FormViewInsertedEventArgs e)
  {
    // Use the Exception property to determine whether an exception
    // occurred during the insert operation.
    if (e.Exception == null)
    {
      // Use the AffectedRows property to determine whether the
      // record was inserted. Sometimes an error might occur that 
      // does not raise an exception, but prevents the insert
      // operation from completing.
      if (e.AffectedRows == 1)
      {
        MessageLabel.Text = "Record inserted successfully.";
      }
      else
      {
        MessageLabel.Text = "An error occurred during the insert operation.";
        
        // Use the KeepInInsertMode property to keep the control in insert 
        // mode when an error occurs during the insert operation.
        e.KeepInInsertMode = true;
      }
    }
    else
    {
      // Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message;
      
      // Use the ExceptionHandled property to indicate that the 
      // exception jhas already been handled.
      e.ExceptionHandled = true;
      e.KeepInInsertMode = true;
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewInsertedEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewInsertedEventHandler Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        emptydatatext="No employees found."
        oniteminserted="EmployeeFormView_ItemInserted"  
        runat="server">

        <itemtemplate>
          <table>
            <tr>
              <td rowspan="5">
                <asp:image id="CompanyLogoImage"
                  imageurl="~/Images/Logo.jpg"
                  alternatetext="Company logo"
                  runat="server"/>
              </td>
              <td colspan="2">
                  &nbsp; 
              </td>
            </tr>
            <tr>
              <td>
                <b>Name:</b>
              </td>
              <td>
                <%# Eval("FirstName") %> <%# Eval("LastName") %>
              </td>
            </tr>
            <tr>
              <td>
                <b>Title:</b>
              </td>
              <td>
                <%# Eval("Title") %>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:linkbutton id="NewButton"
                  text="New"
                  commandname="New"
                  runat="server"/> 
              </td>
            </tr>
          </table>       
        </itemtemplate>
        <insertitemtemplate>
          <table>
            <tr>
              <td rowspan="4">
                <asp:image id="CompanyLogoEditImage"
                  imageurl="~/Images/Logo.jpg"
                  alternatetext="Company logo"
                  runat="server"/>
              </td>
              <td colspan="2">
                  &nbsp; 
              </td>
            </tr>
            <tr>
              <td>
                <b>Name:</b>
              </td>
              <td>
                <asp:textbox id="FirstNameInsertTextBox"
                  text='<%# Bind("FirstName") %>'
                  runat="server"/>
                <asp:textbox id="LastNameInsertTextBox"
                  text='<%# Bind("LastName") %>'
                  runat="server"/>
              </td>
            </tr>
            <tr>
              <td>
                <b>Title:</b>
              </td>
              <td>
                <asp:textbox id="TitleInsertTextBox"
                  text='<%# Bind("Title") %>'
                  runat="server"/> 
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:linkbutton id="InsertButton"
                  text="Insert"
                  commandname="Insert"
                  runat="server"/>
                <asp:linkbutton id="CancelButton"
                  text="Cancel"
                  commandname="Cancel"
                  runat="server"/> 
              </td>
            </tr>
          </table>       
        </insertitemtemplate> 
                  
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
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        insertcommand="Insert Into [Employees] ([LastName], [FirstName], [Title]) VALUES (@LastName, @FirstName, @Title)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->