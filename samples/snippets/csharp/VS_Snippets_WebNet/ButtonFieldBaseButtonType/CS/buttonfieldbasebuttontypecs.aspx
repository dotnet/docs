<!-- <Snippet1> -->
<%@ Page language="C#" %>

<script runat="server">

  void AuthorsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
  {
  
    // If multiple ButtonField column fields are used, use the
    // CommandName property to determine which button was clicked.
    if(e.CommandName=="Select")
    {
    
      // Convert the row index stored in the CommandArgument
      // property to an Integer.
      int index = Convert.ToInt32(e.CommandArgument);    
    
      // Get the last name of the selected author from the appropriate
      // cell in the GridView control.
      GridViewRow selectedRow = AuthorsGridView.Rows[index];
      TableCell lastNameCell = selectedRow.Cells[1];
      string lastName = lastNameCell.Text;  
    
      // Display the selected author.
      Message.Text = "You selected " + lastName + ".";
      
    }
    
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ButtonFieldBase ButtonType Example</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>

    <h3>ButtonFieldBase ButtonType Example</h3>

    <asp:label id="Message"
      forecolor="Red"
      runat="server"
      AssociatedControlID="AuthorsGridView" />
                    
    <!-- Populate the Columns collection declaratively. -->
    <asp:gridview id="AuthorsGridView" 
      datasourceid="AuthorsSqlDataSource" 
      autogeneratecolumns="false"
      onrowcommand="AuthorsGridView_RowCommand" 
      runat="server">
                
      <columns>
        <asp:buttonfield buttontype="Button" 
          commandname="Select"
          headertext="Select Author" 
          text="Select"/>
        <asp:boundfield datafield="au_lname" 
          headertext="Last Name"/>
        <asp:boundfield datafield="au_fname" 
          headertext="First Name"/>
      </columns>
                
    </asp:gridview>
            
    <!-- This example uses Microsoft SQL Server and connects -->
    <!-- to the Pubs sample database. -->
    <asp:sqldatasource id="AuthorsSqlDataSource"  
      selectcommand="SELECT [au_lname], [au_fname] FROM [authors]"
      connectionstring="server=localhost;database=pubs;integrated security=SSPI"
      runat="server">
    </asp:sqldatasource>

  </div>
  </form>
</body>
</html>

<!-- </Snippet1> -->