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
      // FirstName, LastName, and Title fields from the data 
      // source. To support data-binding, create event handlers 
      // for the DataBinding event of each child control.
      // The event handlers must bind the appropriate value 
      // to each control.
      Label firstNameLabel = new Label();
      firstNameLabel.ID = "FirstNameLabel";
      firstNameLabel.DataBinding += new EventHandler(FirstNameLabel_DataBinding);

      Label lastNameLabel = new Label();
      lastNameLabel.ID = "LastNameLabel";
      lastNameLabel.DataBinding += new EventHandler(LastNameLabel_DataBinding);

      Label titleNameLabel = new Label();
      titleNameLabel.ID = "TitleLabel";
      titleNameLabel.DataBinding += new EventHandler(TitleLabel_DataBinding);

      LiteralControl space = new LiteralControl("&nbsp;");
      LiteralControl titleLineBreak = new LiteralControl("<br/>");
      LiteralControl buttonLineBreak = new LiteralControl("<br/>");

      Button deleteButton = new Button();
      deleteButton.ID = "DeleteButton";
      deleteButton.CommandName = "Delete";
      deleteButton.Text = "Delete";

      // Add the controls to the Controls collection of the 
      // container control.
      container.Controls.Add(firstNameLabel);
      container.Controls.Add(space);
      container.Controls.Add(lastNameLabel);
      container.Controls.Add(titleLineBreak);
      container.Controls.Add(titleNameLabel);
      container.Controls.Add(buttonLineBreak);
      container.Controls.Add(deleteButton);

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

    // This event handler binds the value of the Title field
    // to the TitleLabel Label control displayed in the template.
    private void TitleLabel_DataBinding(Object sender, EventArgs e)
    {
      // Use the sender parameter to retrieve the Label control
      // being bound to data.
      Label titleLabelControl = (Label)sender;

      // Retrieve the value to bind to the Label control. First,
      // use the NamingContainer property to retrieve the parent 
      // control of the Label control. In this example, the parent 
      // control is the FormView control.
      FormView formViewContainer = (FormView)titleLabelControl.NamingContainer;

      // Get the data item bound to the FormView control.
      DataRowView rowView = (DataRowView)formViewContainer.DataItem;

      // Use the data item to retrieve the value of the LastName field
      // Set the Text property of the Label control to this value.         
      titleLabelControl.Text = rowView["Title"].ToString();
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

    // Programmatically register the event handler for the 
    // ItemDeleting event of the FormView control.
    employeesFormView.ItemDeleting += new FormViewDeleteEventHandler(EmployeeFormView_ItemDeleting);

    // Create the dynamic template using the custom template class.
    employeesFormView.ItemTemplate = new EmployeeTemplate();

    // Add the FormView object to the Controls collection
    // of the PlaceHolder control.
    FormViewPlaceHolder.Controls.Add(employeesFormView);

  }

  void EmployeeFormView_ItemDeleting(Object sender, FormViewDeleteEventArgs e)
  {

    // Use the sender parameter to retrieve the FormView
    // control that raised the event.
    FormView employeeFormView = (FormView)sender;

    // Retrieve the TitleLabel Label control from the
    // data row.
    FormViewRow row = employeeFormView.Row;
    Label titleLabel = (Label)row.FindControl("TitleLabel");

    // Cancel the delete operation if the user attempts to 
    // delete a protected record. In this example, records for
    // employees with a "Sales Manager" job title are protected.
    if (titleLabel.Text.Equals("Sales Manager"))
    {
      e.Cancel = true;
      MessageLabel.Text = "You cannot delete this record.";
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewDeleteEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewDeleteEventHandler Example</h3>
      
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
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        deletecommand="Delete [Employees] Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->