<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub TaskGridView_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
    
    'Retrieve the table from the session object.
    Dim dt = TryCast(Session("TaskTable"), DataTable)
    
    If dt IsNot Nothing Then
        
      'Sort the data.
      dt.DefaultView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)
      TaskGridView.DataSource = Session("TaskTable")
      TaskGridView.DataBind()
      
    End If

  End Sub
 

  Private Function GetSortDirection(ByVal column As String) As String
    
    ' By default, set the sort direction to ascending.
    Dim sortDirection = "ASC"
    
    ' Retrieve the last column that was sorted.
    Dim sortExpression = TryCast(ViewState("SortExpression"), String)
    
    If sortExpression IsNot Nothing Then
      ' Check if the same column is being sorted.
      ' Otherwise, the default value can be returned.
      If sortExpression = column Then
        Dim lastDirection = TryCast(ViewState("SortDirection"), String)
        If lastDirection IsNot Nothing _
          AndAlso lastDirection = "ASC" Then
          
          sortDirection = "DESC"
          
        End If
      End If
    End If
    
    ' Save new values in ViewState.
    ViewState("SortDirection") = sortDirection
    ViewState("SortExpression") = column
    
    Return sortDirection

  End Function

  Protected Sub Page_Load()
    
    If Not Page.IsPostBack Then
        
      ' Create a new table.
      Dim taskTable As New DataTable("TaskList")
        
      ' Create the columns.
      taskTable.Columns.Add("Id", GetType(Integer))
      taskTable.Columns.Add("Description", GetType(String))
        
      'Add data to the new table.
      For i = 0 To 9
        Dim tableRow As DataRow = taskTable.NewRow()
        tableRow("Id") = i
        tableRow("Description") = "Task " & (10 - i)
        taskTable.Rows.Add(tableRow)
      Next i
        
      'Persist the table in the Session object.
      Session("TaskTable") = taskTable
        
      'Bind the GridView control to the data source.
      TaskGridView.DataSource = Session("TaskTable")
      TaskGridView.DataBind()
    End If
 
  End Sub

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