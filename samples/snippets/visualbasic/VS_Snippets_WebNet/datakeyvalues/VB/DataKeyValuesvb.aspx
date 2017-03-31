<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomerDetailsView_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles CustomerDetailsView.DataBound
    
    ' Retrieve the IOrderedDictionary object that contains the key field values.
    Dim allKeysDictionary As IOrderedDictionary = CustomerDetailsView.DataKey.Values

    ' Display the the value of the key fields.
    MessageLabel.Text = "The key field values for the displayed record are: <br/><br/>"

    ' In Visual Basic, the DictionaryEntry objects contained in the 
    ' allKeysDictionary object must be copied to an array before
    ' you can iterate through the items.
    Dim allKeysArray(allKeysDictionary.Count - 1) As DictionaryEntry
    allKeysDictionary.CopyTo(allKeysArray, 0)
    
    Dim entry As DictionaryEntry
    For Each entry In allKeysArray
     
      MessageLabel.Text &= "Key=" & entry.Key.ToString() & _
          ", Value=" & entry.Value.ToString() & "<br/>"
    
    Next

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>DataKey Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DataKey Example</h3>
                       
        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          autogeneraterows="true"
          datakeynames="CustomerID, CompanyName, PostalCode"  
          allowpaging="true"
          runat="server">
            
        </asp:detailsview>
        
        <br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the Web.config file.                            -->
        <asp:sqldatasource id="DetailsViewSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->