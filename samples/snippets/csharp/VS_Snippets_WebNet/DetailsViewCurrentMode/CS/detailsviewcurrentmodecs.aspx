<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">


    void CustomerDetailView_ItemCommand(Object sender, 
      DetailsViewCommandEventArgs e)
    {
        // Clear the error message if the user cancels the edit 
        // operation.
        if (e.CommandName == "Cancel")
        {
            ErrorMessageLabel.Text = "";
        }
    }

    protected void CustomerDetailView_PageIndexChanging(
      object sender, DetailsViewPageEventArgs e)
    {
        // Cancel the paging operation if the user tries to 
        // navigate to another record while in edit mode.
        if (CustomerDetailView.CurrentMode == DetailsViewMode.Edit)
        {
            e.Cancel = true;
            // Display an error message.
            ErrorMessageLabel.Text = 
              "You cannot navigate to another record while in edit mode.";
        }

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>
            DetailsView CurrentMode Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        <h3>
            DetailsView CurrentMode Example</h3>
        <asp:DetailsView ID="CustomerDetailView" 
          DataSourceID="DetailsViewSource" 
          AutoGenerateRows="true"
          AutoGenerateEditButton="true" 
          DataKeyNames="CustomerID" 
          GridLines="Both" 
          AllowPaging="true"
          OnItemCommand="CustomerDetailView_ItemCommand" 
          runat="server" 
          OnPageIndexChanging="CustomerDetailView_PageIndexChanging">
          
          <HeaderStyle BackColor="Navy" ForeColor="White" />
        </asp:DetailsView>
        
        <br />
        
        <asp:Label ID="ErrorMessageLabel" 
          ForeColor="Red" runat="server" />
        
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:SqlDataSource ID="DetailsViewSource" runat="server" 
          ConnectionString=
            "<%$ ConnectionStrings:NorthWindConnectionString%>"
          InsertCommand="INSERT INTO [Customers]([CustomerID],
            [CompanyName], [Address], [City], [PostalCode], [Country]) 
            VALUES (@CustomerID, @CompanyName, @Address, @City, 
            @PostalCode, @Country)"
          SelectCommand="Select [CustomerID], [CompanyName], 
            [Address], [City], [PostalCode], [Country] From 
            [Customers]">
        </asp:SqlDataSource>
    </form>
</body>
</html>
<!-- </Snippet1> -->
