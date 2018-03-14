<!-- <Snippet1> -->

<%@ Page language="VB" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Sub CustomersGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
  
        ' If multiple ButtonField column fields are used, use the
        ' CommandName property to determine which button was clicked.
        If e.CommandName = "Select" Then
    
            ' Convert the row index stored in the CommandArgument
            ' property to an Integer.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    
            ' Get the last name of the selected author from the appropriate
            ' cell in the GridView control.
            Dim selectedRow As GridViewRow = CustomersGridView.Rows(index)
            Dim contactCell As TableCell = selectedRow.Cells(1)
            Dim contact As String = contactCell.Text
    
            ' Display the selected author.
            Message.Text = "You selected " & contact & "."
      
        End If
    
    End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ButtonField Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>ButtonField Example</h3>
      
      <asp:label id="Message"
        forecolor="Red"
        runat="server"
        AssociatedControlID="CustomersGridView"/>
                    
      <!-- Populate the Columns collection declaratively. -->
      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="false"
        onrowcommand="CustomersGridView_RowCommand"
        runat="server">
                
        <columns>
                
          <asp:buttonfield buttontype="Button" 
            commandname="Select"
            headertext="Select Customer" 
            text="Select"/>
          <asp:boundfield datafield="CompanyName" 
            headertext="Company Name"/>
          <asp:boundfield datafield="ContactName" 
            headertext="Contact Name"/>
                
        </columns>
                
      </asp:gridview>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Northwind sample database.                   -->
        <asp:sqldatasource id="CustomersSqlDataSource"  
          selectcommand="Select [CustomerID], [CompanyName], [ContactName], [ContactTitle] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnection%>"
          runat="server">
        </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->