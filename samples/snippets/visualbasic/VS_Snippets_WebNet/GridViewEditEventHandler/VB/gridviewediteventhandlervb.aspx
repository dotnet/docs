<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">       

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
    ' Create a new GridView control.
    Dim customersGridView As New GridView()

    ' Set the GridView control's properties.
    customersGridView.ID = "CustomersGridView"
    customersGridView.DataSourceID = "CustomersSqlDataSource"
    customersGridView.AutoGenerateColumns = True
    customersGridView.AutoGenerateEditButton = True
    customersGridView.AllowPaging = True
    Dim keyArray() As String = {"CustomerID"}
    customersGridView.DataKeyNames = keyArray
      
    ' Programmatically register the event-handling method.
    AddHandler customersGridView.RowEditing, AddressOf CustomersGridView_RowEditing
        
    ' Add the GridView control to the Controls collection
    ' of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customersGridView)
        
  End Sub

  Sub CustomersGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

    ' User the sender parameter to retrieve the GridView control
    ' that raised the event.
    Dim customersGridView As GridView = CType(sender, GridView)
    
    ' Get the country for the row being edited. For this example, the
    ' country is contained in the seventh column (index 6). 
    Dim country As String = customersGridView.Rows(e.NewEditIndex).Cells(6).Text

    ' For this example, cancel the edit operation if the user attempts
    ' to edit the record of a customer from the USA. 
    If country = "USA" Then
    
      ' Cancel the edit operation.
      e.Cancel = True
      Message.Text = "You cannot edit this record."
    
    Else
    
      Message.Text = ""
      
    End If
    
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewEditEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewEditEventHandler Example</h3>
          
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>
            
      <asp:placeholder id="GridViewPlaceHolder"
        runat="server"/>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update Customers SET CompanyName=@CompanyName, Address=@Address, City=@City, PostalCode=@PostalCode, Country=@Country WHERE (CustomerID = @CustomerID)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->