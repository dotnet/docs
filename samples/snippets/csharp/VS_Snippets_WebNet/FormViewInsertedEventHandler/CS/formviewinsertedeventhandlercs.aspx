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

      Button newButton = new Button();
      newButton.ID = "NewButton";
      newButton.CommandName = "New";
      newButton.Text = "New";

      // Add the controls to the Controls collection of the 
      // container control.
      container.Controls.Add(firstNameLabel);
      container.Controls.Add(nameLineBreak);
      container.Controls.Add(lastNameLabel);
      container.Controls.Add(buttonLineBreak);
      container.Controls.Add(newButton);

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
  
  // This template class represents the insert item
  // template for a FormView control.
  private sealed class EmployeeInsertItemTemplate : ITemplate
  {

    void ITemplate.InstantiateIn(Control container)
    {
      // Create the child controls contained in the template.
      // The insert item template should contain the input 
      // controls for the user to enter a record.
      TextBox firstNameTextBox = new TextBox();
      firstNameTextBox.ID = "FirstNameTextBox";

      LiteralControl nameLineBreak = new LiteralControl("<br/>");
      LiteralControl buttonLineBreak = new LiteralControl("<br/>");

      TextBox lastNameTextBox = new TextBox();
      lastNameTextBox.ID = "LastNameTextBox";

      Button insertButton = new Button();
      insertButton.ID = "InsertButton";
      insertButton.CommandName = "Insert";
      insertButton.Text = "Insert";

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
      container.Controls.Add(insertButton);
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
    employeesFormView.ItemInserted += new FormViewInsertedEventHandler(EmployeeFormView_ItemInserted);
    employeesFormView.ItemInserting += new FormViewInsertEventHandler(EmployeeFormView_ItemInserting);

    // Create the dynamic templates using the custom template classes.
    employeesFormView.ItemTemplate = new EmployeeItemTemplate();
    employeesFormView.InsertItemTemplate = new EmployeeInsertItemTemplate();
    
    // Add the FormView object to the Controls collection
    // of the PlaceHolder control.
    FormViewPlaceHolder.Controls.Add(employeesFormView);

  }

  void EmployeeFormView_ItemInserting(Object sender, FormViewInsertEventArgs e)
  {
    
    // Because the FormView control is dynamically generated, 
    // the Values collection must be programmatically populated
    // with the values for the record to insert.

    // Use the sender argument to retrieve the FormView
    // control that raised the event.
    FormView employeeFormView = (FormView)sender;
    
    // Retrieve the data row from the FormView control.
    FormViewRow row = employeeFormView.Row;

    // Retrieve the TextBox controls that contain the values 
    // entered by the user for the new record. 
    TextBox firstNameTextBox = (TextBox)row.FindControl("FirstNameTextBox");
    TextBox lastNameTextBox = (TextBox)row.FindControl("LastNameTextBox");

    if (firstNameTextBox != null && lastNameTextBox != null)
    {
      // Add the new values to the Values collections.
      e.Values.Add("FirstName", firstNameTextBox.Text);
      e.Values.Add("LastName", lastNameTextBox.Text);
    }

  }

  void EmployeeFormView_ItemInserted(Object sender, FormViewInsertedEventArgs e)
  {
    // Use the Exception property to determine whether an exception
    // occurred during the insert operation.
    if (e.Exception == null)
    {
      // Use the AffectedRows property to determine whether the
      // record was inserted. Sometimes an error might occur that 
      // does not raise an exception, but prevents the insert
      // operation from completing.
      if (e.AffectedRows == 1)
      {
        MessageLabel.Text = "Record inserted successfully.";
      }
      else
      {
        MessageLabel.Text = "An error occurred during the insert operation.";
        
        // Use the KeepInInsertMode property to keep the control in 
        // insert mode when an error occurs during the insert operation.
        e.KeepInInsertMode = true;
      }
    }
    else
    {
      // Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message;
      
      // Use the ExceptionHandled property to indicate that the 
      // exception has already been handled.
      e.ExceptionHandled = true;
      e.KeepInInsertMode = true;
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
        insertcommand="Insert Into [Employees] ([LastName], [FirstName]) VALUES (@LastName, @FirstName)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->