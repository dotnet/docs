<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new GridView control.
    Dim customersGridView As New GridView()

    ' Set the GridView object's properties.
    customersGridView.ID = "CustomersGridView"
    customersGridView.DataSourceID = "CustomersSource"
    customersGridView.AutoGenerateColumns = True
    customersGridView.EmptyDataText = "No data available."
    customersGridView.AllowPaging = True
    customersGridView.AutoGenerateEditButton = True
    customersGridView.PagerSettings.Mode = PagerButtons.Numeric
    customersGridView.PagerSettings.Position = PagerPosition.Bottom
    customersGridView.PagerSettings.PageButtonCount = 10
    customersGridView.PagerStyle.BackColor = System.Drawing.Color.LightBlue
    Dim keyArray() As String = {"CustomerID"}
    customersGridView.DataKeyNames = keyArray

    ' Programmatically register the event-handling methods.
    AddHandler customersGridView.PageIndexChanging, AddressOf CustomersGridView_PageIndexChanging
    AddHandler customersGridView.RowCancelingEdit, AddressOf CustomersGridView_RowCancelingEdit

    ' Add the GridView control to the Controls collection
    ' of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customersGridView)
    
  End Sub

  Sub CustomersGridView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

    ' User the sender parameter to retrieve the GridView control
    ' that raised the event.
    Dim customersGridView As GridView = CType(sender, GridView)
    
    ' Cancel the paging operation if the user attempts to navigate
    ' to another page while the GridView control is in edit mode. 
    If customersGridView.EditIndex <> -1 Then
    
      ' Use the cancel property to cancel the paging operation.
      e.Cancel = True
      
      ' Display an error message.
      Dim newPageNumber As Integer = e.NewPageIndex + 1
      Message.Text = "Please update the record before moving to page " & _
        newPageNumber.ToString() & "."
    
    Else
    
      ' Clear the error message.
      Message.Text = ""
    
    End If
    
  End Sub

  Sub CustomersGridView_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
  
    ' Clear the error message.
    Message.Text = ""
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewPageEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewPageEventHandler Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>  

      <asp:placeholder id="GridViewPlaceHolder"
        runat="server" />
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update Customers SET CompanyName=@CompanyName, Address=@Address, City=@City, PostalCode=@PostalCode, Country=@Country WHERE (CustomerID = @CustomerID)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->