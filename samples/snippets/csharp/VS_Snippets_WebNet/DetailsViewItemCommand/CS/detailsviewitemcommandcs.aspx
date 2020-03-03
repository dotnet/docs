<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void CustomerDetailView_ItemCommand(Object sender, DetailsViewCommandEventArgs e)
    {

        // Use the CommandName property to determine which button
        // was clicked. 
        if (e.CommandName == "Add")
        {

            // Add the current store to the contact list. 

            // Get the row that contains the store name. In this
            // example, the store name is in the second row (index 1)  
            // of the DetailsView control.
            DetailsViewRow row = CustomerDetailView.Rows[1];

            // Get the store's name from the appropriate cell.
            // In this example, the store name is in the second cell  
            // (index 1) of the row.
            String name = row.Cells[1].Text;

            // Create a ListItem object with the store's name.
            ListItem item = new ListItem(name);

            // Add the ListItem object to the ListBox, if the 
            // item doesn't already exist.
            if (!ContactListBox.Items.Contains(item))
            {
                ContactListBox.Items.Add(item);
            }

        }

    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>
            DetailsView ItemCommand Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        <h3>
            DetailsView ItemCommand Example</h3>
        <asp:DetailsView ID="CustomerDetailView" 
            DataSourceID="DetailsViewSource"
            AutoGenerateRows="false" 
            DataKeyNames="CustomerID" 
            AllowPaging="true" 
            OnItemCommand="CustomerDetailView_ItemCommand"
            runat="server">
            
            <FieldHeaderStyle BackColor="Navy" ForeColor="White" />
            
            <Fields>
                <asp:BoundField DataField="CustomerID" HeaderText="Store ID" />
                <asp:BoundField DataField="CompanyName" HeaderText="Store Name" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:ButtonField CommandName="Add" Text="Add Contact" />
            </Fields>
        </asp:DetailsView>
        
        <hr />
        
        Contacts:<br />
        <asp:ListBox ID="ContactListBox" runat="server" />
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:SqlDataSource ID="DetailsViewSource" runat="server" 
          ConnectionString=
            "<%$ ConnectionStrings:NorthWindConnectionString%>"
            InsertCommand="INSERT INTO [Customers]([CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country]) VALUES (@CustomerID, @CompanyName, @Address, @City, @PostalCode, @Country)"
          SelectCommand="Select [CustomerID], [CompanyName], 
            [Address], [City], [PostalCode], [Country] From 
            [Customers]">
        </asp:SqlDataSource>
    </form>
</body>
</html>
<!-- </Snippet1> -->
