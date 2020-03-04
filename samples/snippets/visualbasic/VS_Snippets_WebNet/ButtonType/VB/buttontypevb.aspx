<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub AuthorsGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
  
    ' If multiple ButtonField column fields are used, use the
    ' CommandName property to determine which button was clicked.
    If e.CommandName = "Select" Then
    
      ' Convert the row index stored in the CommandArgument
      ' property to an Integer.
      Dim index As Integer = Convert.ToInt32(e.CommandArgument)    
    
      ' Get the last name of the selected author from the appropriate
      ' cell in the GridView control.
      Dim selectedRow As GridViewRow = AuthorsGridView.Rows(index)
      Dim lastNameCell As TableCell = selectedRow.Cells(1)
      Dim lastName As String = lastNameCell.Text  
    
      ' Display the selected author.
      Message.Text = "You selected " & lastName & "."
      
    End If
    
  End Sub
  
  Sub AuthorsGridView_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    
    ' The GridViewCommandEventArgs class does not contain a 
    ' property that indicates which row's command button was
    ' clicked. To identify which row contains the button 
    ' clicked, use the button's CommandArgument property by 
    ' setting it to the row's index.
    If e.Row.RowType = DataControlRowType.DataRow Then
    
      ' Retrieve the button control from the first column.
      ' Because the ButtonType property of the column field
      ' is set to ButtonType.Link, the button control must be
      ' cast to a LinkButton. If you specify a different button
      ' type, you must cast the button control to the appropriate
      ' button type.
      Dim selectButton As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
            
      ' Set the LinkButton's CommandArgument property with the
      ' row's index.
      selectButton.CommandArgument = e.Row.RowIndex.ToString()
      
    End If

  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ButtonType Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>ButtonType Example</h3>
      
      <asp:label id="Message"
        forecolor="Red"
        runat="server"
        AssociatedControlID="AuthorsGridView"/>
                    
      <!-- Populate the Columns collection declaratively. -->
      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="false"
        onrowcommand="AuthorsGridView_RowCommand" 
        runat="server">
                
        <columns>
                
          <asp:buttonfield buttontype="Link" commandname="Select" text="Select"/>
          <asp:boundfield datafield="au_lname" headertext="au_lname"/>
          <asp:boundfield datafield="au_fname" headertext="au_fname"/>
                
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_lname], [au_fname] FROM [authors]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->