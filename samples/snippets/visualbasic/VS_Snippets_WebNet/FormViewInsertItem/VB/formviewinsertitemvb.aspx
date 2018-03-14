<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub InsertButton_Click(ByVal sender As Object, ByVal e As EventArgs)

    Try
    
      ' Use the InsertItem method to programmatically insert
      ' the current record in the FormView control. 
      EmployeeFormView.InsertItem(True)
      MessageLabel.Text = ""
    
    Catch ex As HttpException
    
      MessageLabel.Text = "The FormView control must be in insert mode to insert a record."
    
    End Try

  End Sub

  Sub CancelButton_Click(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Return the FormView control to read-only
    ' mode.
    EmployeeFormView.ChangeMode(FormViewMode.ReadOnly)
    MessageLabel.Text = ""

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView InsertItem Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView InsertItem Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        emptydatatext="No employees found."
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
                <b><asp:Label runat="server" 
                  AssociatedControlID="FirstNameInsertTextBox" 
                  Text="Name" />:</b>
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
                <b><asp:Label runat="server" 
                  AssociatedControlID="TitleInsertTextBox" 
                  Text="Title" />:</b>
              </td>
              <td>
                <asp:textbox id="TitleInsertTextBox"
                  text='<%# Bind("Title") %>'
                  runat="server"/> 
              </td>
            </tr>
          </table>       
        </insertitemtemplate> 
                  
      </asp:formview>
      
      <hr/>
      
      <asp:Button id="InsertButton"
        text="Insert Record"
        onclick="InsertButton_Click" 
        runat="server"/>
        
      <asp:Button id="CancelButton"
        text="Cancel"
        onclick="CancelButton_Click" 
        runat="server"/>
        
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