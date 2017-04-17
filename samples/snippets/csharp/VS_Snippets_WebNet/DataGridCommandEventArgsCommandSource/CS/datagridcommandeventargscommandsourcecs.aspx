<!--<Snippet1>-->

<%@ page language="C#" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {
    // Call the BindGrid helper method to bind the
    // DataGrid control to the data source the first
    // time the page is loaded.
    if(!IsPostBack)
    {
      BindGrid();
    }
  }
  
  void BindGrid()
  {
    // Declare the connection string and query string.
    // This example uses Microsoft SQL Server and connects
    // to the Northwind sample database.
    String connectionString = "server=localhost;database=NorthWind;Integrated Security=SSPI";
    String queryString = "Select [FirstName],[LastName],[Title] From [Employees]";
    
    // Run the query and display the results.
    DataSet ds = RunQuery(connectionString, queryString);
    if(ds != null)
    {
      ItemsGrid.DataSource = ds;
      ItemsGrid.DataBind();
      Message.Text = "";
    }
    else
    {
      Message.Text = "No records found.";
    }
  }

  DataSet RunQuery(String connectionString, String queryString)
  {
    SqlConnection connection = new SqlConnection(connectionString);
    SqlDataAdapter adapter;
    DataSet ds;

    try
    {
      // Run the query and create the DataSet object.
      ds = new DataSet();
      adapter = new SqlDataAdapter(queryString, connection);
      adapter.Fill(ds);
    }
    catch(Exception ex)
    {
      // Display an error message.
      Message.Text = "Unable to query data source.";
      ds = null;
    }
    finally
    {
      connection.Close();
    }

    return ds;
  }

  void ItemsGrid_ItemCommand(Object sender, DataGridCommandEventArgs e)
  {
    // Use the CommandSource property to retrieve the LinkButton
    // control that raised the event.
    LinkButton selectButton = (LinkButton)e.CommandSource;

    // Display the desciption for the job title.
    Message.Text = selectButton.Text + " - ";

    switch (selectButton.Text)
    {
      case "Sales Representative":
        Message.Text += "Sells products to customers.";
        break;
      case "Vice President, Sales":
        Message.Text += "Manages the sales division.";
        break;
      case "Sales Manager":
        Message.Text += "Manages a sales team.";
        break;
      case "Inside Sales Coordinator":
        Message.Text += "Coordinates cross team communications.";
        break;
      default:
        Message.Text += "To be determined.";
        break;
    }
  }
  
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