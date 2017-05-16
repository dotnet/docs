<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomerGridView_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles CustomerGridView.DataBound
          
    ' Use the indexer to retrieve the DataKey object for the 
    ' first record.
    Dim key As DataKey = CustomerGridView.DataKeys(0)

    ' Display the the value of the primary key for the first
    ' record displayed in the GridView control.
    MessageLabel.Text = "The primary key of the first record displayed is " & _
      key.Value.ToString() & "."
  
    End Sub
    
    Sub CopyArray_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim theKeys As DataKeyArray = CustomerGridView.DataKeys
        Dim myNewArray(theKeys.Count - 1) As DataKey
        theKeys.CopyTo(myNewArray, 0)
        Label2.Visible = True

        ' Display first page key values from the new array.  
        For i As Integer = 0 To myNewArray.Length - 1
            Label2.Text &= "<br />" & myNewArray(i).Value
        Next i

    End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

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
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
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