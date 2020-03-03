<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load()

    If Not Page.IsPostBack Then
      ' Create a new table.
      Dim taskTable As New DataTable("TaskList")

      ' Create the columns.
      taskTable.Columns.Add("Id", GetType(Integer))
      taskTable.Columns.Add("Description", GetType(String))
      taskTable.Columns.Add("IsComplete", GetType(Boolean))

      'Add data to the new table.
      For i = 0 To 19
        Dim tableRow = taskTable.NewRow()
        tableRow("Id") = i
        tableRow("Description") = "Task " + i.ToString()
        tableRow("IsComplete") = False
        taskTable.Rows.Add(tableRow)
      Next

      'Persist the table in the Session object.
      Session("TaskTable") = taskTable

      'Bind data to the GridView control.
      BindData()
    End If

  End Sub
  
  Protected Sub TaskGridView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    TaskGridView.PageIndex = e.NewPageIndex
    'Bind data to the GridView control.
    BindData()
  End Sub

  Protected Sub TaskGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
    'Set the edit index.
    TaskGridView.EditIndex = e.NewEditIndex
    'Bind data to the GridView control.
    BindData()
  End Sub

  Protected Sub TaskGridView_RowCancelingEdit()
    'Reset the edit index.
    TaskGridView.EditIndex = -1
    'Bind data to the GridView control.
    BindData()
  End Sub

  Protected Sub TaskGridView_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
    'Retrieve the table from the session object.
    Dim dt = CType(Session("TaskTable"), DataTable)

    'Update the values.
    Dim row = TaskGridView.Rows(e.RowIndex)
    dt.Rows(row.DataItemIndex)("Id") = (CType((row.Cells(1).Controls(0)), TextBox)).Text
    dt.Rows(row.DataItemIndex)("Description") = (CType((row.Cells(2).Controls(0)), TextBox)).Text
    dt.Rows(row.DataItemIndex)("IsComplete") = (CType((row.Cells(3).Controls(0)), CheckBox)).Checked

    'Reset the edit index.
    TaskGridView.EditIndex = -1

    'Bind data to the GridView control.
    BindData()
  End Sub

  Private Sub BindData()
    TaskGridView.DataSource = Session("TaskTable")
    TaskGridView.DataBind()
  End Sub

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