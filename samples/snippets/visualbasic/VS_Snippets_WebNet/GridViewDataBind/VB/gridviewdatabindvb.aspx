<!-- <Snippet1> -->

<%@ Page language="VB" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    
    ' This example uses Microsoft SQL Server and connects
    ' to the Northwind sample database. The data source needs
    ' to be bound to the GridView control only when the 
    ' page is first loaded. Thereafter, the values are
    ' stored in view state.                      
    If Not IsPostBack Then
        
      ' Declare the query string.
      Dim queryString As String = _
        "Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        
      ' Run the query and bind the resulting DataSet
      ' to the GridView control.
      Dim ds As DataSet = GetData(queryString)
      If (ds.Tables.Count > 0) Then
      
        AuthorsGridView.DataSource = ds
        AuthorsGridView.DataBind()
      
      Else
      
        Message.Text = "Unable to connect to the database."
        
      End If
            
    End If
    
  End Sub
    
  Function GetData(ByVal queryString As String) As DataSet
    
    ' Retrieve the connection string stored in the Web.config file.
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("NorthWindConnectionString").ConnectionString
 
    Dim ds As New DataSet()
        
    Try

      ' Connect to the database and run the query.
      Dim connection As New SqlConnection(connectionString)
      Dim adapter As New SqlDataAdapter(queryString, Connection)
        
      ' Fill the DataSet.
      Adapter.Fill(ds)
            
    
    Catch ex As Exception
        
      ' The connection failed. Display an error message.
      Message.Text = "Unable to connect to the database."
        
    End Try
        
    Return ds
        
  End Function
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView DataBind Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView DataBind Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
               
      <br/>    

      <asp:gridview id="AuthorsGridView" 
        autogeneratecolumns="true" 
        runat="server">
      </asp:gridview>
                        
    </form>
  </body>
</html>

<!-- </Snippet1> -->