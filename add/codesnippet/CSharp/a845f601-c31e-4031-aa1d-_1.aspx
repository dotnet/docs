
  ControlParameter country =
    new ControlParameter("country",TypeCode.String,"ListBox1","SelectedValue");
  sqlSource.SelectParameters.Add(country);

  ControlParameter report  =
    new ControlParameter("report",TypeCode.Int16,"ListBox2","SelectedValue");
  sqlSource.SelectParameters.Add(report);
