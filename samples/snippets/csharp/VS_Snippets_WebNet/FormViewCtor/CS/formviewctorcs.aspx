<!-- <Snippet1> -->
<%@ page language="C#" %>
<%@ import namespace="System.Data"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  // To dynamically create a template for a FormView control,
  // you must create a custom template class to represent 
  // the template. This template class represents the item
  // template for a FormView control.
  private sealed class EmployeeTemplate : ITemplate
  {
    
    // When implementing the ITemplate interface, you must
    // implement the InstantiateIn method. The FormView
    // control calls this method to create the template's 
    // content. 
    void ITemplate.InstantiateIn(Control container)
    {
      // Create the child controls contained in the template.
      // For this example, the item template displays the
      // FirstName and LastName fields from the data source.
      // To support data binding, create event handlers 
      // for the DataBinding event of each child child control.
      // The event handler must bind the appropriate value 
      // to the control.
      Label firstNameLabel = new Label();
      firstNameLabel.ID = "FirstNameLabel";
      firstNameLabel.DataBinding += new EventHandler(FirstNameLabel_DataBinding);
      
      LiteralControl lineBreak = new LiteralControl("<br/>");
      
      Label lastNameLabel = new Label();
      lastNameLabel.ID = "LastNameLabel";
      lastNameLabel.DataBinding += new EventHandler(LastNameLabel_DataBinding);

      // Add the controls to the Controls collection of the 
      // container control.
      container.Controls.Add(firstNameLabel);
      container.Controls.Add(lineBreak);
      container.Controls.Add(lastNameLabel);
    }
    
    // This event handler binds the value of the FirstName field
    // to the FirstNameLabel Label control displayed in the template.
    private void FirstNameLabel_DataBinding(Object sender, EventArgs e)
    {
      // Use the sender parameter to retrieve the Label control
      // being bound to data.
      Label firstNameLabelControl = (Label)sender;

      // Retrieve the value to bind to the Label control. First,
      // use the NamingContainer property to retrieve the parent 
      // control of the Label control. In this example, the parent 
      // control is the FormView control.
      FormView formViewContainer = (FormView)firstNameLabelControl.NamingContainer;
      
      // Get the data item bound to the FormView control.
      DataRowView rowView = (DataRowView)formViewContainer.DataItem;

      // Use the data item to retrieve the value of the FirstName field
      // Set the Text property of the Label control to this value.        
      firstNameLabelControl.Text = rowView["FirstName"].ToString();
    }

    // This event handler binds the value of the LastName field
    // to the LastNameLabel Label control displayed in the template.
    private void LastNameLabel_DataBinding(Object sender, EventArgs e)
    {
      // Use the sender parameter to retrieve the Label control
      // being bound to data.
      Label lastNameLabelControl = (Label)sender;

      // Retrieve the value to bind to the Label control. First,
      // use the NamingContainer property to retrieve the parent 
      // control of the Label control. In this example, the parent 
      // control is the FormView control.
      FormView formViewContainer = (FormView)lastNameLabelControl.NamingContainer;

      // Get the data item bound to the FormView control.
      DataRowView rowView = (DataRowView)formViewContainer.DataItem;

      // Use the data item to retrieve the value of the LastName field.
      // Set the Text property of the Label control to this value.         
      lastNameLabelControl.Text = rowView["LastName"].ToString();
    }
    
  }

  void Page_Load(Object sender, EventArgs e)
  {
    
    // Create a new FormView object.
    FormView employeesFormView = new FormView();
    
    // Set the FormView object's properties.
    employeesFormView.ID = "EmployeesFormView";
    employeesFormView.DataSourceID = "EmployeeSource";
    employeesFormView.AllowPaging = true;
    employeesFormView.PagerSettings.Mode = PagerButtons.NextPrevious;
    employeesFormView.HeaderText = "Employee Name";
    employeesFormView.RowStyle.BackColor = System.Drawing.Color.LightBlue;
    employeesFormView.HeaderStyle.BackColor = System.Drawing.Color.Silver;
    employeesFormView.PagerStyle.BackColor = System.Drawing.Color.Silver;

    // Create the dynamic template using the custom template class.
    employeesFormView.ItemTemplate = new EmployeeTemplate();

    // Add the FormView object to the Controls collection
    // of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(employeesFormView);

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" > 
  <head runat="server">
    <title>FormView Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView Constructor Example</h3>
        
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated FormView control.            -->       
      <asp:PlaceHolder id="DetailsViewPlaceHolder"
        runat="server"/>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName] From [Employees]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
          
    </form>
  </body>
</html>

<!-- </Snippet1> -->
