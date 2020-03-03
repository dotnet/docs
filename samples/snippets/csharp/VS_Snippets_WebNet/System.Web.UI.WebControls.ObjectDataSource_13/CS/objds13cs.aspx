<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS" Assembly="Samples.AspNet.CS" %>
<%@ Page language="c#" %>
<%@ Import namespace="Samples.AspNet.CS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

// Add parameters and initialize the user interface
// only if an employee is selected.
private void Page_Load(object sender, EventArgs e)
{
  // Be sure the text boxes are initialized with
  // data from the currently selected employee.
  NorthwindEmployee selectedEmployee = EmployeeLogic.GetEmployee(DropDownList1.SelectedValue);
  if (selectedEmployee != null) {
    AddressBox.Text    = selectedEmployee.Address;
    CityBox.Text       = selectedEmployee.City;
    PostalCodeBox.Text = selectedEmployee.PostalCode;

    Button1.Enabled = true;
  }
  else {
    Button1.Enabled = false;
  }
}

// Press the button to update.
private void Btn_UpdateEmployee (object sender, CommandEventArgs e) {
    ObjectDataSource2.Update();
}

// Dynamically add parameters to the InputParameters collection.
private void NorthwindEmployeeUpdating(object source, ObjectDataSourceMethodEventArgs e) {

  // The names of the parameters are the same as
  // the variable names for the method that is invoked to
  // perform the Update. The InputParameters collection is
  // an IDictionary collection of name/value pairs,
  // not a ParameterCollection.
  e.InputParameters.Add("anID",       DropDownList1.SelectedValue);
  e.InputParameters.Add("anAddress"  ,AddressBox.Text);
  e.InputParameters.Add("aCity"      ,CityBox.Text);
  e.InputParameters.Add("aPostalCode",PostalCodeBox.Text);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <!-- The DropDownList is bound to the first ObjectDataSource. -->
        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          selectmethod="GetAllEmployees"
          typename="Samples.AspNet.CS.EmployeeLogic" />

        <p><asp:dropdownlist
          id="DropDownList1"
          runat="server"
          datasourceid="ObjectDataSource1"
          datatextfield="FullName"
          datavaluefield="EmpID"
          autopostback="True" /></p>

        <!-- The second ObjectDataSource performs the Update. This
             preserves the state of the DropDownList, which otherwise
             would rebind when the DataSourceChanged event is
             raised as a result of an Update operation. -->

        <asp:objectdatasource
          id="ObjectDataSource2"
          runat="server"
          updatemethod="UpdateEmployeeWrapper"
          onupdating="NorthwindEmployeeUpdating"
          typename="Samples.AspNet.CS.EmployeeLogic" />

        <p><asp:textbox
          id="AddressBox"
          runat="server" /></p>

        <p><asp:textbox
          id="CityBox"
          runat="server" /></p>

        <p><asp:textbox
          id="PostalCodeBox"
          runat="server" /></p>

        <asp:button
          id="Button1"
          runat="server"
          text="Update Employee"
          oncommand="Btn_UpdateEmployee" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->