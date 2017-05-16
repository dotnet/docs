<!-- <Snippet1> -->

<%@ Page language="C#" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {
    
    // This example uses Microsoft SQL Server and connects
    // to the Northwind sample database. The data source needs
    // to be bound to the GridView control only when the 
    // page is first loaded. Thereafter, the values are
    // stored in view state.                      
    if(!IsPostBack)
    {
        
      // Declare the query string.
      String queryString = 
        "Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]";
        
      // Run the query and bind the resulting DataSet
      // to the GridView control.
      DataSet ds = GetData(queryString);
      if (ds.Tables.Count > 0)
      {
        AuthorsGridView.DataSource = ds;
        AuthorsGridView.DataBind();
      }
      else
      {
        Message.Text = "Unable to connect to the database.";
      }
            
    }     
    
  }
    
  DataSet GetData(String queryString)
  {

    // Retrieve the connection string stored in the Web.config file.
    String connectionString = ConfigurationManager.ConnectionStrings["NorthWindConnectionString"].ConnectionString;      
 
    DataSet ds = new DataSet();
        
    try
    {
      // Connect to the database and run the query.
      SqlConnection connection = new SqlConnection(connectionString);        
      SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
        
      // Fill the DataSet.
      adapter.Fill(ds);
            
    }
    catch(Exception ex)
    {
        
      // The connection failed. Display an error message.
      Message.Text = "Unable to connect to the database.";
        
    }
        
    return ds;
        
  }
    
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