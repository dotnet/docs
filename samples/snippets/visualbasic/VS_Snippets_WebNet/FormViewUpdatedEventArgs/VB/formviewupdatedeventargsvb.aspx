<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub EmployeeFormView_ItemUpdated(ByVal sender As Object, ByVal e As FormViewUpdatedEventArgs) Handles EmployeeFormView.ItemUpdated

    ' Use the Exception property to determine whether an exception
    ' occurred during the update operation.
    If e.Exception Is Nothing Then
    
      ' Sometimes an error might occur that does not raise an 
      ' exception, but prevents the update operation from 
      ' completing. Use the AffectedRows property to determine 
      ' whether the record was actually updated. 
      If e.AffectedRows = 1 Then
      
        ' Use the Keys property to get the value of the key field.
        Dim keyFieldValue As String = e.Keys("EmployeeID").ToString()

        ' Display a confirmation message.
        MessageLabel.Text = "Record " & keyFieldValue & _
          " updated successfully. "

        ' Display the new and original values.
        DisplayValues(CType(e.NewValues, OrderedDictionary), CType(e.OldValues, OrderedDictionary))
      
      Else
      
        ' Display an error message.
        MessageLabel.Text = "An error occurred during the update operation."

        ' When an error occurs, keep the FormView
        ' control in edit mode.
        e.KeepInEditMode = True
        
      End If
    
    Else
          
      ' Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message

      ' Use the ExceptionHandled property to indicate that the 
      ' exception has already been handled.
      e.ExceptionHandled = True

      e.KeepInEditMode = True
    
    End If
    
  End Sub

  Sub DisplayValues(ByVal newValues As OrderedDictionary, ByVal oldValues As OrderedDictionary)

    MessageLabel.Text &= "<br/></br>"

    ' Iterate through the new and old values. Display the
    ' values on the page.
    Dim i As Integer
    For i = 0 To oldValues.Count - 1
    
      MessageLabel.Text &= "Old Value=" & oldValues(i).ToString() & _
        ", New Value=" & newValues(i).ToString() & "<br/>"
    Next

    MessageLabel.Text &= "</br>"

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewUpdatedEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewUpdatedEventArgs Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        emptydatatext="No employees found."
        runat="server">
        
        <itemtemplate>
          <table>
            <tr>
              <td rowspan="6">
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
              <td>
                <b>Hire Date:</b>                 
              </td>
              <td>
                <%# Eval("HireDate","{0:d}") %>
              </td>
            </tr>
            <tr style="height:150" valign="top">
              <td>
                <b>Address:</b>
              </td>
              <td>
                <%# Eval("Address") %><br/>
                <%# Eval("City") %> <%# Eval("Region") %>
                <%# Eval("PostalCode") %><br/>
                <%# Eval("Country") %>   
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
              <td rowspan="6">
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
                <b><asp:Label runat="server" 
                  AssociatedControlID="FirstNameUpdateTextBox" 
                  Text="Name" />:</b>
              </td>
              <td>
                <asp:textbox id="FirstNameUpdateTextBox"
                  text='<%# Bind("FirstName") %>'
                  accesskey="n" tabindex="1" runat="server"/>
                <asp:textbox id="LastNameUpdateTextBox"
                  text='<%# Bind("LastName") %>'
                  accesskey="l" tabindex="2" runat="server"/>
              </td>
            </tr>
            <tr>
              <td>
                <b><asp:Label runat="server" 
                  AssociatedControlID="TitleUpdateTextBox" 
                  Text="Title" />:</b>
              </td>
              <td>
                <asp:textbox id="TitleUpdateTextBox"
                  text='<%# Bind("Title") %>'
                  accesskey="t" tabindex="3" runat="server"/> 
              </td>
            </tr>
            <tr>
                <b><asp:Label runat="server" 
                  AssociatedControlID="HireDateUpdateTextBox" 
                  Text="Hire Date" />:</b>
              <td>
                <asp:textbox id="HireDateUpdateTextBox"
                  text='<%# Bind("HireDate", "{0:d}") %>'
                  accesskey="h" tabindex="4" runat="server" />
              </td>
            </tr>
            <tr style="height:150" valign="top">
              <td>
                <b><asp:Label runat="server" 
                  AssociatedControlID="AddressUpdateTextBox" 
                  Text="Address" />:</b>
              </td>
              <td>
                <asp:textbox id="AddressUpdateTextBox"
                  text='<%# Bind("Address") %>'
                  accesskey="a" tabindex="5" runat="server"/>
                <br/>
                <asp:textbox id="CityUpdateTextBox"
                  text='<%# Bind("City") %>'
                  accesskey="c" tabindex="6" runat="server"/> 
                <asp:textbox id="RegionUpdateTextBox"
                  text='<%# Bind("Region") %>'
                  width="40"
                  accesskey="r" tabindex="7" runat="server"/>
                <asp:textbox id="PostalCodeUpdateTextBox"
                  text='<%# Bind("PostalCode") %>'
                  width="60"
                  accesskey="p" tabindex="8" runat="server"/>
                <br/>
                <asp:textbox id="CountryUpdateTextBox"
                  text='<%# Bind("Country") %>'
                  accesskey="u" tabindex="9" runat="server"/> 
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:linkbutton id="UpdateButton"
                  text="Update" tabindex="10" 
                  commandname="Update"
                  runat="server"/>
                <asp:linkbutton id="CancelButton"
                  text="Cancel" tabindex="11" 
                  commandname="Cancel"
                  runat="server"/> 
              </td>
            </tr>
          </table>       
        </edititemtemplate>
                  
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
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [Address], [City], [Region], [PostalCode], [Country], [HireDate], [PhotoPath] From [Employees]"
        updatecommand="Update [Employees] Set [LastName]=@LastName, [FirstName]=@FirstName, [Title]=@Title, [Address]=@Address, [City]=@City, [Region]=@Region, [PostalCode]=@PostalCode, [Country]=@Country Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->