<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub EmployeeFormView_PageIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
  
    ' By default, if the FormView control is in edit mode and
    ' the user navigates to another page, the FormView control
    ' remains in edit mode. In this example, the ChangeMode 
    ' method is used to return the FormView control to read-only  
    ' mode whenever the user navigates to another record.
    EmployeeFormView.ChangeMode(FormViewMode.ReadOnly)
  
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView ChangeMode Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView ChangeMode Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        emptydatatext="No employees found."
        onpageindexchanged="EmployeeFormView_PageIndexChanged"   
        runat="server">
        
        <rowstyle backcolor="LightGreen"
          wrap="false"/>
        <editrowstyle backcolor="LightBlue"
          wrap="false"/>

        <itemtemplate>
          <table>
            <tr>
              <td rowspan="4">
                <asp:image id="EmployeeImage"
                  imageurl='<%# Eval("PhotoPath") %>'
                  alternatetext='<%# Eval("LastName") %>' 
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
                <asp:linkbutton id="Edit"
                  text="Edit"
                  commandname="Edit"
                  runat="server"/> 
              </td>
            </tr>
          </table>       
        </itemtemplate>
        <edititemtemplate>
          <table>
            <tr>
              <td rowspan="4">
                <asp:image id="EmployeeEditImage"
                  imageurl='<%# Eval("PhotoPath") %>'
                  alternatetext='<%# Eval("LastName") %>' 
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
                <asp:textbox id="FirstNameUpdateTextBox"
                  text='<%# Bind("FirstName") %>'
                  runat="server"/>
                <asp:textbox id="LastNameUpdateTextBox"
                  text='<%# Bind("LastName") %>'
                  runat="server"/>
              </td>
            </tr>
            <tr>
              <td>
                <b>Title:</b>
              </td>
              <td>
                <asp:textbox id="TitleUpdateTextBox"
                  text='<%# Bind("Title") %>'
                  runat="server"/> 
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:linkbutton id="UpdateButton"
                  text="Update"
                  commandname="Update"
                  runat="server"/>
                <asp:linkbutton id="CancelButton"
                  text="Cancel"
                  commandname="Cancel"
                  runat="server"/> 
              </td>
            </tr>
          </table>       
        </edititemtemplate> 
                  
      </asp:formview>

      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        updatecommand="Update [Employees] Set [LastName]=@LastName, [FirstName]=@FirstName, [Title]=@Title Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->