<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">


    Sub CustomerDetailView_ItemCommand(ByVal sender As Object, _
      ByVal e As DetailsViewCommandEventArgs)
        ' Clear the error message if the user cancels the edit 
        ' operation.
        If e.CommandName = "Cancel" Then
            ErrorMessageLabel.Text = ""
        End If
    End Sub

    Protected Sub CustomerDetailView_PageIndexChanging( _
    ByVal sender As Object, ByVal e As DetailsViewPageEventArgs)
        ' Cancel the paging operation if the user tries to navigate 
        ' to another record while in edit mode.
        If CustomerDetailView.CurrentMode = DetailsViewMode.Edit Then
            e.Cancel = True
            ' Display an error message.
            ErrorMessageLabel.Text = _
                "You cannot navigate to another record while in edit mode."
        End If
    End Sub
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
