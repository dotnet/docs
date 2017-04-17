<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
  
    ' If multiple ButtonField columns are used, use the
    ' CommandName property to determine which button was clicked.
    If e.CommandName = "Add" Then
    
      ' Convert the row index stored in the CommandArgument
      ' property to an Integer.
      Dim index As Integer = Convert.ToInt32(e.CommandArgument)

      ' Retrieve the row that contains the button clicked
      ' by the user from the Rows collection. Use the
      ' CommandSource property to access the GridView control.
      Dim customersGridView As GridView = CType(e.CommandSource, GridView)
      Dim row As GridViewRow = customersGridView.Rows(index)

      ' Create a new ListItem object for the customer in the row.
      Dim item As New ListItem()
      item.Text = Server.HtmlDecode(row.Cells(1).Text) + " " + Server.HtmlDecode(row.Cells(2).Text)

      ' If the author is not already in the ListBox, add the ListItem
      ' object to the Items collection of a ListBox control.
      If Not CustomersListBox.Items.Contains(item) Then
      
        CustomersListBox.Items.Add(item)
        
      End If
    End If
        
  End Sub

  Sub CustomersGridView_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

    ' The GridViewCommandEventArgs class does not contain a
    ' property that indicates which row's command button was
    ' clicked. To identify which row was clicked, use the button's
    ' CommandArgument property by setting it to the row's index.
    If e.Row.RowType = DataControlRowType.DataRow Then

      ' Retrieve the LinkButton control from the first column.
      Dim addButton As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)

      ' Set the LinkButton's CommandArgument property with the
      ' row's index.
      addButton.CommandArgument = e.Row.RowIndex.ToString()
      
    End If

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewCommandEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>GridViewCommandEventArgs Example</h3>

      <table width="100%">
        <tr>
          <td style="width:50%">
            <asp:gridview id="CustomersGridView" 
              datasourceid="CustomersSource" 
              autogeneratecolumns="false"
              onrowcommand="CustomersGridView_RowCommand"
              onrowcreated="CustomersGridView_RowCreated"  
              runat="server">
                
              <columns>
                
                <asp:buttonfield buttontype="Link" commandname="Add" text="Add"/>
                <asp:boundfield datafield="CompanyName" 
                  headertext="Company Name"/>
                <asp:boundfield datafield="City" 
                  headertext="City"/>
                
              </columns>
                
            </asp:gridview>
          </td>

          <td style="vertical-align:top; width:50%">
             Customers: <br/>
             <asp:listbox id="CustomersListBox"
               runat="server"/>
          </td>
        </tr>
      </table>

      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [City] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->