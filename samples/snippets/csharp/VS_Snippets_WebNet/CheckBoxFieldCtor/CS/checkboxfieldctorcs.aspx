<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // The columns need to be created only the first time
    // the page is loaded.
    if(!IsPostBack)
    {
  
      // Dynamically create columns to display the desired
      // fields from the data source. Columns that are 
      // dynamically added to the GridView control are not persisted 
      // across posts and must be recreated each time the page is 
      // loaded.
  
      // Create a BoundField object to display an author's last name.
      BoundField lastNameBoundField = new BoundField();
      lastNameBoundField.DataField = "au_lname";
      lastNameBoundField.HeaderText = "Last Name";
    
      // Create a CheckBoxField object to indicate whether the author
      // is on contract.
      CheckBoxField contractCheckBoxField = new CheckBoxField();
      contractCheckBoxField.DataField = "contract";
      contractCheckBoxField.HeaderText = "Contract";
    
      // Add the columns to the Columns collection of the
      // GridView control.
      AuthorsGridView.Columns.Add(lastNameBoundField);
      AuthorsGridView.Columns.Add(contractCheckBoxField);

    }
  
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>CheckBoxField Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>CheckBoxField Constructor Example</h3>

      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="False"
        runat="server">                
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