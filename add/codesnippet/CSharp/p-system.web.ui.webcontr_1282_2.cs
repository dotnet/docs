    //
    // To support basic filtering, the employees cannot
    // be returned as an array of objects, rather as a
    // DataSet of the raw data values.
    public static DataSet GetAllEmployeesAsDataSet () {
      ICollection employees = GetAllEmployees();

      DataSet ds = new DataSet("Table");

      // Create the schema of the DataTable.
      DataTable dt = new DataTable();
      DataColumn dc;
      dc = new DataColumn("FirstName", typeof(string)); dt.Columns.Add(dc);
      dc = new DataColumn("LastName",  typeof(string)); dt.Columns.Add(dc);
      dc = new DataColumn("Title",     typeof(string)); dt.Columns.Add(dc);
      dc = new DataColumn("Courtesy",  typeof(string)); dt.Columns.Add(dc);
      dc = new DataColumn("Supervisor",typeof(Int32));  dt.Columns.Add(dc);

      // Add rows to the DataTable.
      IEnumerator emplEnum = employees.GetEnumerator();
      DataRow row;
      NorthwindEmployee ne;
      while (emplEnum.MoveNext()) {
        ne = emplEnum.Current as NorthwindEmployee;
        row = dt.NewRow();
        row["FirstName"]  = ne.FirstName;
        row["LastName"]   = ne.LastName;
        row["Title"]      = ne.Title;
        row["Courtesy"]   = ne.Courtesy;
        row["Supervisor"] = ne.Supervisor;
        dt.Rows.Add(row);
      }
      // Add the complete DataTable to the DataSet.
      ds.Tables.Add(dt);

      return ds;
    }