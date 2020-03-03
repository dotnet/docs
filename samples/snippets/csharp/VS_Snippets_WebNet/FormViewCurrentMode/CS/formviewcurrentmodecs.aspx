<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeeFormView_OnPageIndexChanging(Object sender, FormViewPageEventArgs e)
  {
    // Cancel the paging operation if the user attempts to navigate 
    // to another record while the FormView control is in edit mode. 
    if (EmployeeFormView.CurrentMode == FormViewMode.Edit)
    {
      e.Cancel = true;
      MessageLabel.Text = 
        "Please complete the update operation before navigating to another record.";
    }
  }

  void EmployeeFormView_OnModeChanged(Object sender, EventArgs e)
  {
    // Clear the message label.
    MessageLabel.Text = "";
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        emptydatatext="No employees found."
        onpageindexchanging="EmployeeFormView_OnPageIndexChanging" 
        onmodechanged="EmployeeFormView_OnModeChanged"  
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
      
      <br/><br/>
      
      <asp:Label id="MessageLabel"
        forecolor="Red"
        runat="server"/> 

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