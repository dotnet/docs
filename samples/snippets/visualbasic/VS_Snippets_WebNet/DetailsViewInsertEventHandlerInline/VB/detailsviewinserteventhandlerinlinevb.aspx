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
    customerDetailsView.AutoGenerateInsertButton = True
    customerDetailsView.AllowPaging = True
    
    Dim keyArray() As String = {"CustomerID"}
    customerDetailsView.DataKeyNames = keyArray
    
    ' Programmatically register the event-handling method
    ' for the ItemInserted event of a DetailsView control.
    AddHandler customerDetailsView.ItemInserting, AddressOf CustomerDetailsView_ItemInserting

    ' Add the DetailsView object to the Controls collection
    ' of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView)

  End Sub

  Sub CustomerDetailsView_ItemInserting(ByVal sender As Object, ByVal e As DetailsViewInsertEventArgs)
    
    ' Use the Values property to retrieve the key field value.
    Dim keyValue As String = e.Values("CustomerID").ToString()

    ' Insert the record only if the key field is four characters
    ' long; otherwise, cancel the insert operation.
    If keyValue.Length = 4 Then
    
      ' Change the key field value to upper case before inserting 
      ' the record in the data source.
      e.Values("CustomerID") = keyValue.ToUpper()
      
      MessageLabel.Text = ""
    
    Else
    
      MessageLabel.Text = "The key field must have four digits."
      e.Cancel = True
    
    End If

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewInsertEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewInsertEventHandler Example</h3>
        
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated DetailsView control.         -->       
      <asp:PlaceHolder id="DetailsViewPlaceHolder"
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
        insertcommand="INSERT INTO [Customers]([CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country]) VALUES (@CustomerID, @CompanyName, @Address, @City, @PostalCode, @Country)"
        connectionstring=
          "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->