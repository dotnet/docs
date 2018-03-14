<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Sub CustomerDetailsView_ItemInserting(ByVal sender As Object, ByVal e As DetailsViewInsertEventArgs)
  
        ' Use the Values property to retrieve the key field value.
        Dim keyValue As String = e.Values("CustomerID").ToString()

        If CStr(e.CommandArgument) = "CheckID" Then
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
        End If
    End Sub


</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewInsertEventArgs Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsViewInsertEventArgs Example</h3>
                
        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogeneraterows="true"
          allowpaging="true" AutoGenerateInsertButton="true"
          oniteminserting="CustomerDetailsView_ItemInserting" 
          runat="server">

            <Fields>
                <asp:TemplateField >
                  <InsertItemTemplate>
                    <asp:Button ID="Button1" CommandName="Insert" CommandArgument="CheckID" 
                      runat="server" Text="Insert with ID Check" BackColor="green" />
                  </InsertItemTemplate>
                </asp:TemplateField>
            </Fields>               
        </asp:detailsview>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:sqldatasource id="DetailsViewSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          insertcommand="INSERT INTO [Customers]([CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country]) VALUES (@CustomerID, @CompanyName, @Address, @City, @PostalCode, @Country)"
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>
<!-- </Snippet1> -->
