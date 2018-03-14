<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeeFormView_ItemInserting(Object sender, FormViewInsertEventArgs e)
  {

    MessageLabel.Text = "";

    // Iterate through the items in the Values collection
    // and verify that the user entered a value for each 
    // text box displayed in the insert item template. Cancel
    // the insert operation if the user left a text box empty.
    foreach (DictionaryEntry entry in e.Values)
    {
      if (entry.Value.Equals(""))
      {
        // Use the Cancel property to cancel the 
        // insert operation.
        e.Cancel = true;

        MessageLabel.Text += "Please enter a value for the " +
          entry.Key.ToString() + " field.<br/>";

      }
    }
  }

  void EmployeeFormView_ModeChanged(Object sender, EventArgs e)
  {
    // Clear the MessageLabel Label control when the FormView
    // control changes modes.
    MessageLabel.Text = "";
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewInsertEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewInsertEventArgs Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        emptydatatext="No employees found."
        oniteminserting="EmployeeFormView_ItemInserting"
        onmodechanged="EmployeeFormView_ModeChanged"
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
                <b><asp:Label
                  runat="server" 
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
                <b><asp:Label
                  runat="server" 
                  AssociatedControlID="TitleInsertTextBox" 
                  Text="Title" />:</b>
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