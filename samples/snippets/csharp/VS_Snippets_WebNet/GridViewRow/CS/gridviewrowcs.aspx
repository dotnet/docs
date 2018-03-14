<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void AuthorsGridView_SelectedIndexChanged(Object sender, EventArgs e)
  {
  
    // Get the selected row from the GridView control.
    GridViewRow selectRow = AuthorsGridView.SelectedRow;
    
    // Get the author's first and last name from the appropriate
    // cells in the selected row. For BoundField field columns
    // and automatically generated field columns, the Text property
    // of a cell is used to access a field value.
    String lastName = selectRow.Cells[1].Text;
    
    // In a TemplateField column where a data-binding expression
    // is used directly in the ItemTemplate, the field value
    // is automatically placed in DataBoundLiteral control.
    
    // Retrieve the DataBoundLiteral control from the cell. The
    // DataBoundLiteral control is the first control in the 
    // Controls collection.
    DataBoundLiteralControl firstNameLiteral = (DataBoundLiteralControl)selectRow.Cells[2].Controls[0];
    String firstName = firstNameLiteral.Text;
    
    // Display the name of the selected author.
    Message.Text = "You selected " + firstName + " " + lastName + ".";
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewRow Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewRow Example</h3>

      <asp:label id="Message" 
        forecolor="Red"
        runat="server"/>
              
      <br/> 

      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="false"
        autogenerateselectbutton="true"
        onselectedindexchanged="AuthorsGridView_SelectedIndexChanged"  
        runat="server"> 
               
        <columns>
          <asp:boundfield datafield="au_lname"
            headertext="Last Name"/>
          <asp:templatefield headertext="FirstName">
            <itemtemplate>
              <%#Eval("au_fname")%>
            </itemtemplate>
          </asp:templatefield>
        </columns>
                              
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_lname], [au_fname], [address], [city], [state], [zip], [contract] FROM [authors]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->