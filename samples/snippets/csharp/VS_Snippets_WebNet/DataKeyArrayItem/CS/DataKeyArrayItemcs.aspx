<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomerGridView_DataBound(Object sender, EventArgs e)
  {           
    // Use the indexer to retrieve the DataKey object for the 
    // first record.
    DataKey key = CustomerGridView.DataKeys[0];

    // Display the the value of the primary key for the first
    // record displayed in the GridView control.
    MessageLabel.Text = "The primary key of the first record displayed is " +
      key.Value.ToString() + ".";
  }

  void CopyArray_Click(Object sender, EventArgs e)
  {
      DataKeyArray theKeys = CustomerGridView.DataKeys;
      DataKey[] myNewArray = new DataKey[theKeys.Count];
      theKeys.CopyTo(myNewArray, 0);
      Label2.Visible = true;

      // Display first page key values from the new array.
      for (int i = 0; i < myNewArray.Length; i++)
      {
          Label2.Text += "<br />" + myNewArray[i].Value;
      }

  }

</script>

<html  >

  <head id="Head1" runat="server">
    <title>DataKeyArray Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>DataKeyArray Example</h3>

        <asp:gridview id="CustomerGridView"
          datasourceid="CustomerDataSource"
          autogeneratecolumns="true"
          datakeynames="CustomerID"  
          allowpaging="true"
          ondatabound="CustomerGridView_DataBound" 
          runat="server">

        </asp:gridview>

        <br/>

        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>

        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the Web.config file.                            -->
        <asp:sqldatasource id="CustomerDataSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthwindConnectionString %>" 
          runat="server"/>

        <asp:Button ID="CopyArray" 
            runat="server" 
            Text="Copy DataKeyArray to Array" 
            OnClick="CopyArray_Click" />

        <br />

        <asp:label id="Label2"
          runat="server"
          Visible="false"  
          Text="First page of Copied Array Key Values" />


      </form>
  </body>
</html>

<!-- </Snippet1> -->