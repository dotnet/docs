<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomerDetailsView_ItemInserting(Object sender, 
    DetailsViewInsertEventArgs e)
  {
    // Use the Values property to retrieve the key field value.
    String keyValue = e.Values["CustomerID"].ToString();

    // Insert the record only if the key field is four characters
    // long; otherwise, cancel the insert operation.
    if (keyValue.Length == 4)
    {
      // Change the key field value to upper case before inserting 
      // the record in the data source.
      e.Values["CustomerID"] = keyValue.ToUpper();

      MessageLabel.Text = "";
    }
    else
    {
      MessageLabel.Text = "The key field must have four digits.";
      e.Cancel = true;
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewInsertEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewInsertEventArgs Example</h3>
                
        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogenerateinsertbutton="true"  
          autogeneraterows="true"
          allowpaging="true"
          oniteminserting="CustomerDetailsView_ItemInserting" 
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