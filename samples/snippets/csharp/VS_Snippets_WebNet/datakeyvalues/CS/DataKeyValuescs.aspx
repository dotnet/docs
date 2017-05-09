<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomerDetailsView_DataBound(Object sender, EventArgs e)
  {

    // Retrieve the IOrderedDictionary object that contains the key field values.
    IOrderedDictionary allKeysDictionary = CustomerDetailsView.DataKey.Values;

    // Display the the value of the key fields.
    MessageLabel.Text = "The key field values for the displayed record are: <br/><br/>";

    foreach (DictionaryEntry entry in allKeysDictionary)
    {
      MessageLabel.Text += "Key=" + entry.Key.ToString() + 
        ", Value=" + entry.Value.ToString() + "<br/>";
    }

  }
  
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
          ondatabound="CustomerDetailsView_DataBound" 
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