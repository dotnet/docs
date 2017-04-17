<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub EmployeeFormView_ItemUpdating(ByVal sender As Object, ByVal e As FormViewUpdateEventArgs) Handles EmployeeFormView.ItemUpdating
  
    ' Validate the field values entered by the user. This
    ' example determines whether the user left any fields
    ' empty. Use the NewValues property to access the new 
    ' values entered by the user.
        Dim emptyFieldList As ArrayList = ValidateFields(e.NewValues)

    If emptyFieldList.Count > 0 Then

      ' The user left some fields empty. Display an error message.
      
      ' Use the Keys property to retrieve the key field value.
      Dim keyValue As String = e.Keys("EmployeeID").ToString()

      MessageLabel.Text = "You must enter a value for each field of record " & _
        keyValue & ".<br/>The following fields are missing:<br/><br/>"

      ' Display the missing fields.
      Dim value As String
      For Each value In emptyFieldList
      
        ' Use the OldValues property to access the original value
        ' of a field.
        MessageLabel.Text &= value & " - Original Value = " & _
          e.OldValues(value).ToString() & "<br />"
        
      Next

      ' Cancel the update operation.
      e.Cancel = True

    Else
    
      ' The field values passed validation. Clear the
      ' error message label.
      MessageLabel.Text = ""
      
    End If

  End Sub

  Function ValidateFields(ByVal list As IOrderedDictionary) As ArrayList
    
    ' Create an ArrayList object to store the
    ' names of any empty fields.
    Dim emptyFieldList As New ArrayList()

    ' Iterate though the field values entered by
    ' the user and check for an empty field. Empty
    ' fields contain a null value.
    Dim entry As DictionaryEntry
    
    For Each entry In list
    
      If entry.Value Is String.Empty Then
      
        ' Add the field name to the ArrayList object.
        emptyFieldList.Add(entry.Key.ToString())
        
      End If
      
    Next

    Return emptyFieldList
  
  End Function
  
  Sub EmployeeFormView_ModeChanging(ByVal sender As Object, ByVal e As FormViewModeEventArgs) Handles EmployeeFormView.ModeChanging
  
    If e.CancelingEdit Then
      
      ' The user canceled the update operation.
      ' Clear the error message label.
      MessageLabel.Text = ""
    
    End If
    
  End Sub
  
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
        headertext="Employee Record"
        emptydatatext="No employees found."
        runat="server">
        
        <headerstyle backcolor="CornFlowerBlue"
          forecolor="White"
          font-size="14"
          horizontalalign="Center"  
          wrap="false"/>
        <rowstyle backcolor="LightBlue"
          wrap="false"/>
        <pagerstyle backcolor="CornFlowerBlue"/>

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
            <tr style="height:150; vertical-align:top">
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
              <td>
                <b>Hire Date:</b>                 
              </td>
              <td>
                <asp:textbox id="HireDateUpdateTextBox"
                  text='<%# Bind("HireDate", "{0:d}") %>'
                  runat="server"/>
              </td>
            </tr>
            <tr style="height:150; vertical-align:top">
              <td>
                <b>Address:</b>
              </td>
              <td>
                <asp:textbox id="AddressUpdateTextBox"
                  text='<%# Bind("Address") %>'
                  runat="server"/>
                <br/>
                <asp:textbox id="CityUpdateTextBox"
                  text='<%# Bind("City") %>'
                  runat="server"/> 
                <asp:textbox id="RegionUpdateTextBox"
                  text='<%# Bind("Region") %>'
                  width="40"
                  runat="server"/>
                <asp:textbox id="PostalCodeUpdateTextBox"
                  text='<%# Bind("PostalCode") %>'
                  width="60"
                  runat="server"/>
                <br/>
                <asp:textbox id="CountryUpdateTextBox"
                  text='<%# Bind("Country") %>'
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
          
        <pagersettings position="Bottom"
          mode="Numeric"/> 
                  
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