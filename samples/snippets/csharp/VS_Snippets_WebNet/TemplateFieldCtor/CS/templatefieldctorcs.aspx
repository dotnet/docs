<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  // Create a template class to represent a dynamic template column.
  public class GridViewTemplate : ITemplate
  {
    private DataControlRowType templateType;
    private string columnName;
   
    public GridViewTemplate(DataControlRowType type, string colname)
    {
      templateType = type;
      columnName = colname;
    }

    public void InstantiateIn(System.Web.UI.Control container)
    {
      // Create the content for the different row types.
      switch(templateType)
      {
        case DataControlRowType.Header:
          // Create the controls to put in the header
          // section and set their properties.
          Literal lc = new Literal();
          lc.Text = "<b>" + columnName + "</b>";
          
          // Add the controls to the Controls collection
          // of the container.
          container.Controls.Add(lc);
          break;
        case DataControlRowType.DataRow:
          // Create the controls to put in a data row
          // section and set their properties.
          Label firstName = new Label();
          Label lastName = new Label();
          
          Literal spacer = new Literal();
          spacer.Text = " ";
          
          // To support data binding, register the event-handling methods
          // to perform the data binding. Each control needs its own event
          // handler.
          firstName.DataBinding += new EventHandler(this.FirstName_DataBinding);
          lastName.DataBinding += new EventHandler(this.LastName_DataBinding);
          
          // Add the controls to the Controls collection
          // of the container.
          container.Controls.Add(firstName);
          container.Controls.Add (spacer);
          container.Controls.Add(lastName);
          break;
          
        // Insert cases to create the content for the other 
        // row types, if desired.
          
        default:
          // Insert code to handle unexpected values.
          break; 
      }
    }
    
    private void FirstName_DataBinding(Object sender, EventArgs e)
    {
      // Get the Label control to bind the value. The Label control
      // is contained in the object that raised the DataBinding 
      // event (the sender parameter).
      Label l = (Label)sender;
      
      // Get the GridViewRow object that contains the Label control. 
      GridViewRow row = (GridViewRow)l.NamingContainer;
      
      // Get the field value from the GridViewRow object and 
      // assign it to the Text property of the Label control.
      l.Text = DataBinder.Eval(row.DataItem, "au_fname").ToString();
    }
    
    private void LastName_DataBinding(Object sender, EventArgs e)
    { 
      // Get the Label control to bind the value. The Label control
      // is contained in the object that raised the DataBinding 
      // event (the sender parameter).
      Label l = (Label)sender;
      
      // Get the GridViewRow object that contains the Label control.
      GridViewRow row = (GridViewRow)l.NamingContainer;
      
      // Get the field value from the GridViewRow object and 
      // assign it to the Text property of the Label control.
      l.Text = DataBinder.Eval(row.DataItem, "au_lname").ToString();
    }
  }

  void Page_Load(Object sender, EventArgs e)
  {
    
    // The field columns need to be created only when the page is
    // first loaded. 
    if (!IsPostBack)
    {
      // Dynamically create field columns to display the desired
      // fields from the data source. Create a TemplateField object 
      // to display an author's first and last name.
      TemplateField customField = new TemplateField();

      // Create the dynamic templates and assign them to 
      // the appropriate template property.
      customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "Author Name");
      customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, "Author Name");

      // Add the field column to the Columns collection of the
      // GridView control.
      AuthorsGridView.Columns.Add(customField);
    }
  
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField Constructor Example</h3>

      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="False"
        runat="server">                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_fname], [au_lname] FROM [authors]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->