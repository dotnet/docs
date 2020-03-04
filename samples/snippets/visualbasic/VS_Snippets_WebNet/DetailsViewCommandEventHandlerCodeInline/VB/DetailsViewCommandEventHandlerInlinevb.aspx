<!-- <Snippet1> -->

<%@ page language="VB" %>

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
    customerDetailsView.AllowPaging = True
    
    Dim keyArray() As String = {"CustomerID"}
    customerDetailsView.DataKeyNames = keyArray
    
    ' Add a button field to the DetailsView control.
    Dim field As New ButtonField()
    field.ButtonType = ButtonType.Link
    field.CausesValidation = False
    field.Text = "Add to List"
    field.CommandName = "Add"

    customerDetailsView.Fields.Add(field)

    ' Programmatically register the event-handling method
    ' for the ItemDeleting event of a DetailsView control.
    AddHandler customerDetailsView.ItemCommand, _
      AddressOf CustomerDetailsView_ItemCommand

    ' Add the DetailsView object to the Controls collection
    ' of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView)

  End Sub
  
  Sub CustomerDetailsView_ItemCommand(ByVal sender As Object, _
    ByVal e As DetailsViewCommandEventArgs)

    ' Use the CommandName property to determine which button
    ' was clicked. 
    If e.CommandName = "Add" Then

      ' Get the DetailsView control that raised the event.
      Dim customerDetailsView As DetailsView = _
        CType(e.CommandSource, DetailsView)

      ' Add the current customer to the customer list. 

      ' Get the row that contains the company name. In this
      ' example, the company name is in the second row (index 1)  
      ' of the DetailsView control.
      Dim row As DetailsViewRow = customerDetailsView.Rows(1)

      ' Get the company's name from the appropriate cell.
      ' In this example, the company name is in the second cell  
      ' (index 1) of the row.
      Dim name As String = row.Cells(1).Text

      ' Create a ListItem object with the company name.
      Dim item As New ListItem(name)

      ' Add the ListItem object to the ListBox, if the 
      ' item doesn't already exist.
      If Not CustomerListBox.Items.Contains(item) Then
      
        CustomerListBox.Items.Add(item)
        
      End If

    End If

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewCommandEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>DetailsViewCommandEventHandler Example</h3>
      
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated DetailsView control.         -->       
      <asp:placeholder id="DetailsViewPlaceHolder"
        runat="server"/>
      
      <br/><br/>
      
      Selected Customers:<br/>
      <asp:listbox id="CustomerListBox"
        runat="server"/>
      
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the web.config file.                            -->
      <asp:sqldatasource id="DetailsViewSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], 
          [City], [PostalCode], [Country] From [Customers]"
        connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>  
  
    </form>
  </body>
</html>
<!-- </Snippet1> -->