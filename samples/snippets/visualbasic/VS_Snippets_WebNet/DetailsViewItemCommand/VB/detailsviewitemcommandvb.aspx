<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomerDetailView_ItemCommand(ByVal sender As Object, ByVal e As DetailsViewCommandEventArgs)
    
        ' Use the CommandName property to determine which button
        ' was clicked. 
        If e.CommandName = "Add" Then

            ' Add the current store to the contact list. 
     
            ' Get the row that contains the store name. In this
            ' example, the store name is in the second row (index 1)  
            ' of the DetailsView control.
            Dim row As DetailsViewRow = CustomerDetailView.Rows(1)
      
            ' Get the store's name from the appropriate cell.
            ' In this example, the store name is in the second cell  
            ' (index 1) of the row.
            Dim name As String = row.Cells(1).Text

            ' Create a ListItem object with the store's name.
            Dim item As New ListItem(name)

            ' Add the ListItem object to the ListBox, if the 
            ' item doesn't already exist.
            If Not ContactListBox.Items.Contains(item) Then
      
                ContactListBox.Items.Add(item)
      
            End If
        
        End If
    
    End Sub

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
