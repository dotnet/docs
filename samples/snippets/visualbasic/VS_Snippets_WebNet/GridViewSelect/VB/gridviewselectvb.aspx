<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        
    ' Get the currently selected row using the SelectedRow property.
    Dim row As GridViewRow = CustomersGridView.SelectedRow
        
    ' Display the first name from the selected row.
    ' In this example, the third column (index 2) contains
    ' the first name.
    MessageLabel.Text = "You selected " & row.Cells(2).Text & "."
  End Sub

  Sub CustomersGridView_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        
    ' Get the currently selected row. Because the SelectedIndexChanging event
    ' occurs before the select operation in the GridView control, the
    ' SelectedRow property cannot be used. Instead, use the Rows collection
    ' and the NewSelectedIndex property of the e argument passed to this 
    ' event handler.
    Dim row As GridViewRow = CustomersGridView.Rows(e.NewSelectedIndex)

    ' You can cancel the select operation by using the Cancel
    ' property. For this example, if the user selects a customer with 
    ' the ID "ANATR", the select operation is canceled and an error message
    ' is displayed.
    If row.Cells(1).Text = "ANATR" Then
        e.Cancel = True
        MessageLabel.Text = "You cannot select " + row.Cells(2).Text & "."
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView Select Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
     <h3>GridView Select Example</h3>

     <asp:gridview id="CustomersGridView" 
       datasourceid="CustomersSource" 
       autogeneratecolumns="False"
       autogenerateselectbutton="True"
       selectedindex="1"
       onselectedindexchanged="CustomersGridView_SelectedIndexChanged"
       onselectedindexchanging="CustomersGridView_SelectedIndexChanging"   
       runat="server" DataKeyNames="CustomerID">
                
         <Columns>
             <asp:BoundField DataField="CustomerID" 
                 HeaderText="CustomerID" 
                 InsertVisible="False" ReadOnly="True" 
                 SortExpression="CustomerID" />
             <asp:BoundField DataField="FirstName" 
                 HeaderText="FirstName" 
                 SortExpression="FirstName" />
             <asp:BoundField DataField="MiddleName" 
                 HeaderText="MiddleName" 
                 SortExpression="MiddleName" />
             <asp:BoundField DataField="LastName" 
                 HeaderText="LastName" 
                 SortExpression="LastName" />
             <asp:BoundField DataField="Phone" 
                 HeaderText="Phone" 
                 SortExpression="Phone" />
         </Columns>
                
       <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/>  
                
     </asp:gridview>
            
      <br/>
            
      <asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="SELECT CustomerID, FirstName, MiddleName, LastName, Phone FROM SalesLT.Customer"
        connectionstring="<%$ ConnectionStrings:AdventureWorksLTConnectionString %>" 
        runat="server"/>
            
    </form>

  </body>
</html>

<!-- </Snippet1> -->