<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void TaskGridView_Sorting(object sender, GridViewSortEventArgs e)
  {

    //Retrieve the table from the session object.
    DataTable dt = Session["TaskTable"] as DataTable;

    if (dt != null)
    {

      //Sort the data.
      dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
      TaskGridView.DataSource = Session["TaskTable"];
      TaskGridView.DataBind();
    }

  }

  private string GetSortDirection(string column)
  {

    // By default, set the sort direction to ascending.
    string sortDirection = "ASC";

    // Retrieve the last column that was sorted.
    string sortExpression = ViewState["SortExpression"] as string;

    if (sortExpression != null)
    {
      // Check if the same column is being sorted.
      // Otherwise, the default value can be returned.
      if (sortExpression == column)
      {
        string lastDirection = ViewState["SortDirection"] as string;
        if ((lastDirection != null) && (lastDirection == "ASC"))
        {
          sortDirection = "DESC";
        }
      }
    }

    // Save new values in ViewState.
    ViewState["SortDirection"] = sortDirection;
    ViewState["SortExpression"] = column;

    return sortDirection;
  }
    
  protected void Page_Load(object sender, EventArgs e)
  {
          
    if (!Page.IsPostBack)
    {

      // Create a new table.
      DataTable taskTable = new DataTable("TaskList");

      // Create the columns.
      taskTable.Columns.Add("Id", typeof(int));
      taskTable.Columns.Add("Description", typeof(string));

      //Add data to the new table.
      for (int i = 0; i < 10; i++)
      {
        DataRow tableRow = taskTable.NewRow();
        tableRow["Id"] = i;
        tableRow["Description"] = "Task " + (10 - i).ToString();
        taskTable.Rows.Add(tableRow);
      }

      //Persist the table in the Session object.
      Session["TaskTable"] = taskTable;

      //Bind the GridView control to the data source.
      TaskGridView.DataSource = Session["TaskTable"];
      TaskGridView.DataBind();
      
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sorting example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:GridView ID="TaskGridView" runat="server" 
        AllowSorting="true" 
        OnSorting="TaskGridView_Sorting" >
      </asp:GridView>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->