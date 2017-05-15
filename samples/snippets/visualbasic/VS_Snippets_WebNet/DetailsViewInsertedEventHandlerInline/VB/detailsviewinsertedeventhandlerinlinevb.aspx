<!-- <Snippet1> -->

<%@ page language="VB"%>
  
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
    customerDetailsView.AllowPaging = true
    
    Dim keyArray() As String = {"CustomerID"}
    customerDetailsView.DataKeyNames = keyArray
    
    ' Programmatically register the event-handling method
    ' for the ItemInserted event of a DetailsView control.
    AddHandler customerDetailsView.ItemInserted, _
      AddressOf CustomerDetailsView_ItemInserted

    ' Add the DetailsView object to the Controls collection
    ' of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView)

  End Sub

  Sub CustomerDetailsView_ItemInserted(ByVal sender As Object, _
    ByVal e As DetailsViewInsertedEventArgs)
 
    ' Use the Exception property to determine whether an exception
    ' occurred during the insert operation.
    If e.Exception Is Nothing Then
    
      ' Use the Values property to get the value entered by 
      ' the user for the CompanyName field.
      Dim name As String = e.Values("CompanyName").ToString()

      ' Display a confirmation message.
      MessageLabel.Text = name & " added successfully. "

    Else
    
      ' Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message

      ' Use the ExceptionHandled property to indicate that the 
      ' exception is already handled.
      e.ExceptionHandled = True

      ' When an exception occurs, keep the DetailsView
      ' control in insert mode.
      e.KeepInInsertMode = True
    
    End If
      
  End Sub

</script>
 
 <html xmlns="http://www.w3.org/1999/xhtml" >   
  <head runat="server">
    <title>DetailsViewInsertedEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewInsertedEventHandler Example</h3>
        
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
          insertcommand="INSERT INTO [Customers]([CustomerID], [CompanyName], 
            [Address], [City], [PostalCode], [Country]) 
            VALUES (@CustomerID, @CompanyName, @Address, @City, 
            @PostalCode, @Country)"
          connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->
