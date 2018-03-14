<!-- <Snippet1> -->
<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub AuthorsGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
  
    ' Get the selected row.
    Dim row As GridViewRow = AuthorsGridView.SelectedRow
    
    ' Check the row state. If the row is not in edit mode and is selected,
    ' exit edit mode. This ensures that the GridView control exits edit mode
    ' when a user selects a different row while the GridView control is in 
    ' edit mode. Notice that the DataControlRowState enumeration is a flag
    ' enumeration, which means that you can combine values using bitwise
    ' operations.
    If row.RowState <> (DataControlRowState.Edit Or DataControlRowState.Selected) Then

      AuthorsGridView.EditIndex = -1
    
    End If
          
  End Sub
  
  Sub AuthorsGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
    
    ' Get the row being edited.
    Dim row As GridViewRow = AuthorsGridView.Rows(e.NewEditIndex)
    
    ' Check the row state. If the row is not in edit mode and is selected,
    ' select the current row. This ensures that the GridView control selects
    ' the current row when the user clicks the Edit button.
    If row.RowState <> (DataControlRowState.Edit Or DataControlRowState.Selected) Then
    
      AuthorsGridView.SelectedIndex = e.NewEditIndex
    
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewRow RowState Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewRow RowState Example</h3>

      <!-- The GridView control automatically sets the columns     -->
      <!-- specified in the datakeynames attribute as read-only    -->
      <!-- No input controls are rendered for these columns in     -->
      <!-- edit mode.                                              -->
      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="false"
        autogenerateeditbutton="true"
        autogenerateselectbutton="true" 
        datakeynames="au_id"
        cellpadding="10"
        onselectedindexchanged="AuthorsGridView_SelectedIndexChanged"
        onrowediting="AuthorsGridView_RowEditing"       
        runat="server">
        
        <selectedrowstyle backcolor="Yellow"/>
               
        <columns>
        
          <asp:boundfield datafield="au_lname"
            headertext="Last Name"/>
          <asp:boundfield datafield="au_fname"
            headertext="First Name"/> 
        
        </columns>
             
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_id], [au_lname], [au_fname] FROM [authors]"             
        updatecommand="UPDATE authors SET au_lname=@au_lname, au_fname=@au_fname WHERE (authors.au_id = @au_id)" 
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->