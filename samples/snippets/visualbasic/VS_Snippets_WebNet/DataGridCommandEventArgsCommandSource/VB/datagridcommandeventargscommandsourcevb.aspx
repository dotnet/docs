<!--<Snippet1>-->
<%@ page language="VB" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
  
    ' Call the BindGrid helper method to bind the
    ' DataGrid control to the data source the first
    ' time the page is loaded.
    If Not IsPostBack Then
    
      BindGrid()
    
    End If
    
  End Sub
  
  Sub BindGrid()
  
    ' Declare the connection string and query string.
    ' This example uses Microsoft SQL Server and connects
    ' to the Northwind sample database.
    Dim connectionString As String = "server=localhost;database=NorthWind;Integrated Security=SSPI"
    Dim queryString As String = "Select [FirstName],[LastName],[Title] From [Employees]"
    
    ' Run the query and display the results.
    Dim ds As DataSet = RunQuery(connectionString, queryString)
    If ds IsNot Nothing Then
 
      ItemsGrid.DataSource = ds
      ItemsGrid.DataBind()
      Message.Text = ""
    
    Else
    
      Message.Text = "No records found."
    
    End If
      
  End Sub

  Function RunQuery(ByVal connectionString As String, ByVal queryString As String) As DataSet
  
    Dim connection As New SqlConnection(connectionString)
    Dim adapter As SqlDataAdapter
    Dim ds As DataSet
    
    Try

      ' Run the query and create the DataSet object.
      ds = New DataSet()
      adapter = New SqlDataAdapter(queryString, connection)
      adapter.Fill(ds)
    
    Catch ex As Exception
   
      ' Display an error message.
      Message.Text = "Unable to query data source."
      ds = Nothing
    
    Finally
    
      Connection.Close()
    
    End Try
    
    Return ds
  
  End Function

  Sub ItemsGrid_ItemCommand(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
  
    ' Use the CommandSource property to retrieve the LinkButton
    ' control that raised the event.
    Dim selectButton As LinkButton = CType(e.CommandSource, LinkButton)

    ' Display the desciption for the job title.
    Message.Text = selectButton.Text & " - "
    
    Select Case (selectButton.Text)
    
      Case "Sales Representative"
        Message.Text &= "Sells products to customers."

      Case "Vice President, Sales"
        Message.Text &= "Manages the sales division."

      Case "Sales Manager"
        Message.Text &= "Manages a sales team."

      Case "Inside Sales Coordinator"
        Message.Text &= "Coordinates cross team communications."

      Case Else
        Message.Text &= "To be determined."
    
    End Select
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DataGridCommandEventArgs CommandSource Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>DataGridCommandEventArgs CommandSource Example</h3>

      <asp:datagrid
        id="ItemsGrid"
        autogeneratecolumns="false"
        onitemcommand="ItemsGrid_ItemCommand"  
        runat="server">

          <columns>
          
            <asp:BoundColumn DataField="FirstName"
              headertext="First Name"/>
            <asp:BoundColumn DataField="LastName"
              headertext="Last Name"/>
            <asp:buttoncolumn buttontype="LinkButton"
              datatextfield="Title"
              headertext="Title"/> 
          
          </columns>
        
      </asp:datagrid>
      
      <br/><br/>
      
      <asp:label id="Message" 
        runat="server"/>

    </form>
  </body>
</html>
<!--</Snippet1>-->