<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
          
    if (!Page.IsPostBack)
    {
      // Create a new table.
      DataTable taskTable = new DataTable("TaskList");
      
      // Create the columns.
      taskTable.Columns.Add("Id", typeof(int));
      taskTable.Columns.Add("Description", typeof(string));
      taskTable.Columns.Add("IsComplete", typeof(bool) );

      //Add data to the new table.
      for (int i = 0; i < 20; i++)
      {
        DataRow tableRow = taskTable.NewRow();
        tableRow["Id"] = i;
        tableRow["Description"] = "Task " + i.ToString();
        tableRow["IsComplete"] = false;            
        taskTable.Rows.Add(tableRow);
      }

      //Persist the table in the Session object.
      Session["TaskTable"] = taskTable;

      //Bind data to the GridView control.
      BindData();
    }

  }

  protected void TaskGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
  {
    TaskGridView.PageIndex = e.NewPageIndex;
    //Bind data to the GridView control.
    BindData();
  }

  protected void TaskGridView_RowEditing(object sender, GridViewEditEventArgs e)
  {
    //Set the edit index.
    TaskGridView.EditIndex = e.NewEditIndex;
    //Bind data to the GridView control.
    BindData();
  }

  protected void TaskGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
  {
    //Reset the edit index.
    TaskGridView.EditIndex = -1;
    //Bind data to the GridView control.
    BindData();
  }

  protected void TaskGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
  {    
    //Retrieve the table from the session object.
    DataTable dt = (DataTable)Session["TaskTable"];

    //Update the values.
    GridViewRow row = TaskGridView.Rows[e.RowIndex];
    dt.Rows[row.DataItemIndex]["Id"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
    dt.Rows[row.DataItemIndex]["Description"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
    dt.Rows[row.DataItemIndex]["IsComplete"] = ((CheckBox)(row.Cells[3].Controls[0])).Checked;

    //Reset the edit index.
    TaskGridView.EditIndex = -1;

    //Bind data to the GridView control.
    BindData();
  }

  private void BindData()
  {
    TaskGridView.DataSource = Session["TaskTable"];
    TaskGridView.DataBind();
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridView example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:GridView ID="TaskGridView" runat="server" 
        AutoGenerateEditButton="True" 
        AllowPaging="true"
        OnRowEditing="TaskGridView_RowEditing"         
        OnRowCancelingEdit="TaskGridView_RowCancelingEdit" 
        OnRowUpdating="TaskGridView_RowUpdating"
        OnPageIndexChanging="TaskGridView_PageIndexChanging">
      </asp:GridView>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->