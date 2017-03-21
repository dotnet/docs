private void Button1_Click(object sender, EventArgs e) {

    // The user has pressed the Submit button, prepare a parameterized
    // SQL query to insert the values from the controls.
    AccessDataSource1.InsertCommand =
    "INSERT INTO Employees (FirstName,LastName,Address,City,PostalCode,Country,ReportsTo) " +
    "  VALUES (?,?,?,?,?,?,? ); ";

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("FirstName", "TextBox1", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("LastName", "TextBox2", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("Address", "TextBox3", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("City", "TextBox4", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("PostalCode", "TextBox5", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("Country", "TextBox6", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("ReportsTo", "DropDownList1", "SelectedValue"));

    try {
        AccessDataSource1.Insert();
    }
    finally {
        Button1.Visible = false;
        Label9.Visible = true;
    }
}