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
      // for the DataBinding event of each child control.
      // The event handlers must bind the appropriate value 
      // to each control.
      Label firstNameLabel = new Label();
      firstNameLabel.ID = "FirstNameLabel";
      firstNameLabel.DataBinding += new EventHandler(FirstNameLabel_DataBinding);
      
      LiteralControl nameLineBreak = new LiteralControl("<br/>");
      LiteralControl buttonLineBreak = new LiteralControl("<br/>");

      Label lastNameLabel = new Label();
      lastNameLabel.ID = "LastNameLabel";
      lastNameLabel.DataBinding += new EventHandler(LastNameLabel_DataBinding);

      // Create a custom button control to display in the item
      // template. When a button within a FormView control is 
      // clicked, the ItemCommand event is raised. The ItemCommand
      // event is used to handle the clicking of this button.
      Button displayButton = new Button();
      displayButton.ID = "AddButton";
      displayButton.CommandName = "Display";
      displayButton.Text = "Display Employee";

      // Add the controls to the Controls collection of the 
      // container control.
      container.Controls.Add(firstNameLabel);
      container.Controls.Add(nameLineBreak);
      container.Controls.Add(lastNameLabel);
      container.Controls.Add(buttonLineBreak);
      container.Controls.Add(displayButton);

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

      // Use the data item to retrieve the value of the FirstName field.
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
    employeesFormView.HeaderText = "Employee Name";
    
    // Programmatically register the event handlers for the 
    // FormView control.
    employeesFormView.ItemCommand += new FormViewCommandEventHandler(EmployeesFormView_ItemCommand);
    employeesFormView.PageIndexChanged += new EventHandler(EmployeesFormView_PageIndexChanged);

    // Create the dynamic template using the custom template class.
    employeesFormView.ItemTemplate = new EmployeeTemplate();

    // Add the FormView object to the Controls collection
    // of the PlaceHolder control.
    FormViewPlaceHolder.Controls.Add(employeesFormView);

  }

  void EmployeesFormView_ItemCommand(Object sender, FormViewCommandEventArgs e)
  {

    // The ItemCommand event is raised when any button within
    // the FormView control is clicked. Use the CommandName property 
    // to determine which button was clicked. 
    if (e.CommandName == "Display")
    {
      
      // Use the sender parameter to get the FormView control
      // that contains the button clicked.
      FormView employeesFormView = (FormView)sender;

      // Use the Row property to retrieve the data row.
      FormViewRow row = employeesFormView.Row;

      // Retrieve the FirstNameLabel and LastNameLabel Label controls 
      // from the data row.
      Label firstNameLabel = (Label)row.FindControl("FirstNameLabel");
      Label lastNameLabel = (Label)row.FindControl("LastNameLabel");

      if (firstNameLabel != null && lastNameLabel != null)
      {
        // Display the employee's name.
        MessageLabel.Text = firstNameLabel.Text + " " + 
          lastNameLabel.Text;
      }
      
    }
    
  }

  void EmployeesFormView_PageIndexChanged(Object sender, EventArgs e)
  {
    
    // Clear the message label when the user navigates to 
    // a different record.
    MessageLabel.Text = "";

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" > 
  <head runat="server">
    <title>FormViewCommandEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewCommandEventHandler Example</h3>
        
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated FormView control.            -->       
      <asp:placeholder id="FormViewPlaceHolder"
        runat="server"/>
            
      <br/><br/>
      
      <asp:label id="MessageLabel"
        forecolor="Red"
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
