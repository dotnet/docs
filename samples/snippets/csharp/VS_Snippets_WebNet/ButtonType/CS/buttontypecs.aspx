<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
  
  void AuthorsGridView_RowCreated(Object sender, GridViewRowEventArgs e)
  {
    
    // The GridViewCommandEventArgs class does not contain a 
    // property that indicates which row's command button was
    // clicked. To identify which row contains the button 
    // clicked, use the button's CommandArgument property by 
    // setting it to the row's index.
    if(e.Row.RowType == DataControlRowType.DataRow)
    {
    
      // Retrieve the button control from the first column.
      // Because the ButtonType property of the column field
      // is set to ButtonType.Link, the button control must be
      // cast to a LinkButton. If you specify a different button
      // type, you must cast the button control to the appropriate
      // button type.
      LinkButton selectButton = (LinkButton)e.Row.Cells[0].Controls[0];
            
      // Set the LinkButton's CommandArgument property with the
      // row's index.
      selectButton.CommandArgument = e.Row.RowIndex.ToString();
      
    }

  }
    
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
                    
      <!-- Populate the Fields collection declaratively. -->
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