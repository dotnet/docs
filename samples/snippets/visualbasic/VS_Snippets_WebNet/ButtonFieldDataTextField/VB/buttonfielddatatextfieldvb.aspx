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
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ButtonField DataTextField Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>ButtonField DataTextField Example</h3>
      
      <asp:label id="Message"
        forecolor="Red"
        runat="server"
        AssociatedControlID="AuthorsGridView"/>
                    
      <!-- Set the DataTextField property of the ButtonField -->
      <!-- declaratively. Set the DataTextFormatString       -->
      <!-- property to apply special formatting to the text. -->
      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="false"
        onrowcommand="AuthorsGridView_RowCommand"
        runat="server">
                
        <columns>
                
          <asp:buttonfield buttontype="Link" 
            commandname="Select"
            headertext="Select Author"
            datatextfield="au_lname"
            datatextformatstring="[{0}]"    
            text="Select"/>
          <asp:boundfield datafield="au_fname" 
            headertext="First Name"/>
                
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