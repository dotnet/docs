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
    customerDetailsView.AllowPaging = true
    customerDetailsView.PagerSettings.Position = PagerPosition.Bottom

    Dim keyArray() As String = {"CustomerID"}
    customerDetailsView.DataKeyNames = keyArray
       
    ' Programmatically register the event-handling methods
    ' for the DetailsView control.
    AddHandler customerDetailsView.PageIndexChanging, AddressOf CustomerDetailsView_PageIndexChanging
    AddHandler customerDetailsView.ModeChanging, AddressOf CustomerDetailsView_ModeChanging
    
    ' Add the DetailsView object to the Controls collection
    ' of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView)

  End Sub
  
  Sub CustomerDetailsView_PageIndexChanging(ByVal sender As Object, ByVal e As DetailsViewPageEventArgs)
  
    ' Use the sender parameter to access the DetailsView control
    ' that raised the event.
    Dim customerDetailsView As DetailsView = CType(sender, DetailsView)

    ' Cancel the paging operation if the DetailsView control 
    ' in edit mode.
    If customerDetailsView.CurrentMode = DetailsViewMode.Edit Then
    
      e.Cancel = True
      
      ' Display an error message.
      Dim newPage As Integer = e.NewPageIndex + 1
      MessageLabel.Text = "Please update the current record before to moving to page " & _
        newPage.ToString() & "."
    
    End If
      
  End Sub

  Sub CustomerDetailsView_ModeChanging(ByVal sender As Object, ByVal e As DetailsViewModeEventArgs)
  
    ' Clear the message label when the user changes mode.
    MessageLabel.Text = ""
  
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewPageEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewPageEventHandler Example</h3>
                               
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
          [Country]=@Country 
          Where [CustomerID]=@CustomerID"
          connectionstring=
          "<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->