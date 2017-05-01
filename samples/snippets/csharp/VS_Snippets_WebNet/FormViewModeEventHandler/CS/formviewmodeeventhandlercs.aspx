<!-- <Snippet1> -->

<%@ Page language="C#" %>
<%@ import namespace="System.Data"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  // To dynamically create a template for a FormView control,
  // you must create a custom template class to represent 
  // the template. This template class represents the item
  // template for a FormView control.
  private sealed class EmployeeItemTemplate : ITemplate
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

      Button editButton = new Button();
      editButton.ID = "EditButton";
      editButton.CommandName = "Edit";
      editButton.Text = "Edit";

      // Add the controls to the Controls collection of the 
      // container control.
      container.Controls.Add(firstNameLabel);
      container.Controls.Add(nameLineBreak);
      container.Controls.Add(lastNameLabel);
      container.Controls.Add(buttonLineBreak);
      container.Controls.Add(editButton);

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
  
  // This template class represents the edit item
  // template for a FormView control.
  private sealed class EmployeeEditItemTemplate : ITemplate
  {

    void ITemplate.InstantiateIn(Control container)
    {
      // Create the child controls contained in the template.
      // The edit item template should contain the input 
      // controls for the user to edit a record.
      TextBox firstNameTextBox = new TextBox();
      firstNameTextBox.ID = "FirstNameTextBox";

      LiteralControl nameLineBreak = new LiteralControl("<br/>");
      LiteralControl buttonLineBreak = new LiteralControl("<br/>");

      TextBox lastNameTextBox = new TextBox();
      lastNameTextBox.ID = "LastNameTextBox";

      Button updateButton = new Button();
      updateButton.ID = "UpdateButton";
      updateButton.CommandName = "Update";
      updateButton.Text = "Update";

      Button cancelButton = new Button();
      cancelButton.ID = "CancelButton";
      cancelButton.CommandName = "Cancel";
      cancelButton.Text = "Cancel";

      // Add the controls to the Controls collection of the 
      // container control.
      container.Controls.Add(firstNameTextBox);
      container.Controls.Add(nameLineBreak);
      container.Controls.Add(lastNameTextBox);
      container.Controls.Add(buttonLineBreak);
      container.Controls.Add(updateButton);
      container.Controls.Add(cancelButton);

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
    employeesFormView.DataKeyNames = new String[1] { "EmployeeID" };

    // Programmatically register the event handlers for the 
    // the FormView control.
    employeesFormView.ModeChanging += new FormViewModeEventHandler(EmployeeFormView_ModeChanging);
    employeesFormView.ItemUpdating += new FormViewUpdateEventHandler(EmployeeFormView_ItemUpdating);

    // Create the dynamic templates using the custom template classes.
    employeesFormView.ItemTemplate = new EmployeeItemTemplate();
    employeesFormView.EditItemTemplate = new EmployeeEditItemTemplate();
    
    // Add the FormView object to the Controls collection
    // of the PlaceHolder control.
    FormViewPlaceHolder.Controls.Add(employeesFormView);

  }

  void EmployeeFormView_ItemUpdating(Object sender, FormViewUpdateEventArgs e)
  {
    
    // Because the FormView control is dynamically generated, 
    // the NewValues collection must be programmatically populated
    // with the values for the record to update.

    // Use the sender argument to retrieve the FormView
    // control that raised the event.
    FormView employeeFormView = (FormView)sender;
    
    // Retrieve the data row from the FormView control.
    FormViewRow row = employeeFormView.Row;

    // Retrieve the TextBox controls that contain the updated values 
    // entered by the user. 
    TextBox firstNameTextBox = (TextBox)row.FindControl("FirstNameTextBox");
    TextBox lastNameTextBox = (TextBox)row.FindControl("LastNameTextBox");

    if (firstNameTextBox != null && lastNameTextBox != null)
    {
      // Add the new values to the NewValues collections.
      e.NewValues.Add("FirstName", firstNameTextBox.Text);
      e.NewValues.Add("LastName", lastNameTextBox.Text);
    }

  }

  void EmployeeFormView_ModeChanging(Object sender, FormViewModeEventArgs e)
  {

    // Use the sender argument to retrieve the FormView
    // control that raised the event.
    FormView employeeFormView = (FormView)sender;

    // Use the NewMode property to determine the mode to which the 
    // FormView control is transitioning.
    switch (e.NewMode)
    {
      case FormViewMode.Edit:
        // Hide the pager row and clear the Label control
        // when transitioning to edit mode.
        employeeFormView.AllowPaging = false;
        MessageLabel.Text = "";
        break;
      case FormViewMode.ReadOnly:
        // Display the pager row and confirmation message
        // when transitioning to edit mode.
        employeeFormView.AllowPaging = true;
        if (e.CancelingEdit)
        {
          MessageLabel.Text = "Update canceled.";
        }
        else
        {
          MessageLabel.Text = "Update completed.";
        }
        break;
      case FormViewMode.Insert:
        // Cancel the mode change if the FormView
        // control attempts to transition to insert 
        // mode.
        e.Cancel = true;
        break;
      default:
        MessageLabel.Text = "Unsupported mode.";
        break;
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView Example</h3>
      
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
        updatecommand="Update [Employees] Set [LastName]=@LastName, [FirstName]=@FirstName Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->