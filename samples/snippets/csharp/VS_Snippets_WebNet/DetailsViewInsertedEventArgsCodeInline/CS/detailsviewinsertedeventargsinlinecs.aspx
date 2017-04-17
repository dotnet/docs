<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomerDetailsView_ItemInserted(Object sender, 
    DetailsViewInsertedEventArgs e)
  {
    // Use the Exception property to determine whether an exception
    // occurred during the insert operation.
    if (e.Exception == null && e.AffectedRows == 1)
    {
      // Use the Values property to get the value entered by 
      // the user for the CompanyName field.
      String name = e.Values["CompanyName"].ToString();

      // Display a confirmation message.
      MessageLabel.Text = name + " added successfully. ";

    }
    else
    {
      // Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message;
      
      // Use the ExceptionHandled property to indicate that the 
      // exception is already handled.
      e.ExceptionHandled = true;
      
      // When an exception occurs, keep the DetailsView
      // control in insert mode.
      e.KeepInInsertMode = true;
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewInsertedEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewInsertedEventArgs Example</h3>
                
        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogenerateinsertbutton="true"  
          autogeneraterows="true"
          allowpaging="true"
          oniteminserted="CustomerDetailsView_ItemInserted" 
          runat="server">
               
          <fieldheaderstyle backcolor="Navy"
            forecolor="White"/>
                    
        </asp:detailsview>
        
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
          insertcommand="INSERT INTO [Customers]([CustomerID], 
            [CompanyName], [Address], [City], [PostalCode], 
            [Country]) VALUES (@CustomerID, @CompanyName, @Address, 
            @City, @PostalCode, @Country)"
          connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->