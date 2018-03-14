<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Create a new DetailsView object.
    Dim customerDetailsView As New DetailsView()

    ' Set the DetailsView object's properties.
    customerDetailsView.ID = "CustomerDetailsView"
    customerDetailsView.DataSourceID = "DetailsViewSource"
    customerDetailsView.AutoGenerateRows = True
    customerDetailsView.AutoGenerateEditButton = True
    customerDetailsView.AllowPaging = True
    customerDetailsView.PagerSettings.Position = PagerPosition.Bottom

    Dim keyArray() As String = {"CustomerID"}
    customerDetailsView.DataKeyNames = keyArray
    
    ' Programmatically register the event-handling methods
    ' for the DetailsView control.
    AddHandler customerDetailsView.ItemUpdating, _
      AddressOf CustomerDetailsView_ItemUpdating
    AddHandler customerDetailsView.ModeChanging, _
      AddressOf CustomerDetailsView_ModeChanging

    ' Add the DetailsView object to the Controls collection
    ' of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView)

  End Sub
  
  Sub CustomerDetailsView_ItemUpdating(ByVal sender As Object, _
    ByVal e As DetailsViewUpdateEventArgs)

    ' Validate the field values entered by the user. This
    ' example determines whether the user left any fields
    ' empty. Use the NewValues property to access the new 
    ' values entered by the user.
    Dim emptyFieldList As ArrayList = _
      ValidateFields(CType(e.NewValues, IOrderedDictionary))

    If emptyFieldList.Count > 0 Then

      ' The user left some fields empty. Display an error message.
      
      ' Use the Keys property to retrieve the key field value.
      Dim keyValue As String = e.Keys("CustomerID").ToString()

      MessageLabel.Text = _
        "You must enter a value for all fields of record " & _
        keyValue & ".<br/>The following fields are missing:<br/><br/>"

      ' Display the missing fields.
      Dim value As String
      For Each value In emptyFieldList
      
        ' Use the OldValues property access the original value
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

    Function ValidateFields(ByVal list As IOrderedDictionary) _
      As ArrayList
    
        ' Create an ArrayList object to store the
        ' names of any empty fields.
        Dim emptyFieldList As New ArrayList()

        ' Iterate though the field values entered by
        ' the user and check for an empty field. Empty
        ' fields contain a null value.
        Dim entry As DictionaryEntry
    
        For Each entry In list
    
            If entry.Value Is Nothing Then
      
                ' Add the field name to the ArrayList object.
                emptyFieldList.Add(entry.Key.ToString())
        
            End If
        Next

        Return emptyFieldList
  
    End Function

  Sub CustomerDetailsView_ModeChanging(ByVal sender As Object, ByVal e As DetailsViewModeEventArgs)
  
    If e.CancelingEdit Then
      
      ' The user canceled the update operation.
      ' Clear the error message label.
      MessageLabel.Text = ""
    
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewUpdateEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewUpdateEventHandler Example</h3>
        
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated DetailsView control.         -->       
      <asp:placeholder id="DetailsViewPlaceHolder"
        runat="server"/>
        
      <br/><br/>
      
      <asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the web.config file.                            -->
      <asp:sqldatasource id="DetailsViewSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], 
          [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update [Customers] Set 
          [CompanyName]=@CompanyName, [Address]=@Address, 
          [City]=@City, [PostalCode]=@PostalCode, 
          [Country]=@Country Where [CustomerID]=@CustomerID"
        connectionstring=
          "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
s    </form>
  </body>
</html>

<!-- </Snippet1> -->