// <snippet2>
namespace Samples.AspNet.CS {

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
  //
  // EmployeeLogic is a stateless business object that encapsulates
  // the operations you can perform on a NorthwindEmployee object.
  //
  public class EmployeeLogic {

    // Returns a collection of NorthwindEmployee objects.
    public static ICollection GetAllEmployees () {
      ArrayList al = new ArrayList();

      ConnectionStringSettings cts = ConfigurationManager.ConnectionStrings["NorthwindConnection"];

      SqlDataSource sds
        = new SqlDataSource(cts.ConnectionString,
                            "SELECT EmployeeID FROM Employees");
      try {
        IEnumerable IDs = sds.Select(DataSourceSelectArguments.Empty);

        // Iterate through the Enumeration and create a
        // NorthwindEmployee object for each ID.
        IEnumerator enumerator = IDs.GetEnumerator();
        while (enumerator.MoveNext()) {
          // The IEnumerable contains DataRowView objects.
          DataRowView row = enumerator.Current as DataRowView;
          string id = row["EmployeeID"].ToString();
          NorthwindEmployee nwe = new NorthwindEmployee(id);
          // Add the NorthwindEmployee object to the collection.
          al.Add(nwe);
        }
      }
      finally {
        // If anything strange happens, clean up.
        sds.Dispose();
      }

      return al;
    }

    public static NorthwindEmployee GetEmployee(object anID) {
      if (anID.Equals("-1") ||
          anID.Equals(DBNull.Value) ) {
        return new NorthwindEmployee();
      }
      else {
        return new NorthwindEmployee(anID);
      }
    }

    public static void UpdateEmployeeInfo(NorthwindEmployee ne) {
      bool retval = ne.Save();
      if (! retval) { throw new NorthwindDataException("UpdateEmployee failed."); }
    }

    public static void DeleteEmployee(NorthwindEmployee ne) {
      bool retval = ne.Delete();
      if (! retval) { throw new NorthwindDataException("DeleteEmployee failed."); }
    }

    // And so on...
  }

  public class NorthwindEmployee {

    public NorthwindEmployee () {
      ID = DBNull.Value;
      lastName = "";
      firstName = "";
      title="";
      titleOfCourtesy = "";
      reportsTo = -1;
    }

    public NorthwindEmployee (object anID) {
      this.ID = anID;

      SqlConnection conn
        = new SqlConnection (ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString);
      SqlCommand sc =
        new SqlCommand(" SELECT FirstName,LastName,Title,TitleOfCourtesy,ReportsTo " +
                       " FROM Employees " +
                       " WHERE EmployeeID = @empId",
                       conn);
      // Add the employee ID parameter and set its value.
      sc.Parameters.Add(new SqlParameter("@empId",SqlDbType.Int)).Value = Int32.Parse(anID.ToString());
      SqlDataReader sdr = null;

      try {
        conn.Open();
        sdr = sc.ExecuteReader();

        // Only loop once.
        if (sdr != null && sdr.Read()) {
          // The IEnumerable contains DataRowView objects.
          this.firstName        = sdr["FirstName"].ToString();
          this.lastName         = sdr["LastName"].ToString();
          this.title            = sdr["Title"].ToString();
          this.titleOfCourtesy  = sdr["TitleOfCourtesy"].ToString();
          if (! sdr.IsDBNull(4)) {
            this.reportsTo        = sdr.GetInt32(4);
          }
        }
        else {
          throw new NorthwindDataException("Data not loaded for employee id.");
        }
      }
      finally {
        try {
          if (sdr != null) sdr.Close();
          conn.Close();
        }
        catch (SqlException) {
          // Log an event in the Application Event Log.
          throw;
        }
      }
    }

    private object ID;
    public string EmpID {
      get { return ID.ToString();  }
    }

    private string lastName;
    public string LastName {
      get { return lastName; }
      set { lastName = value; }
    }

    private string firstName;
    public string FirstName {
      get { return firstName; }
      set { firstName = value;  }
    }

    public string FullName {
      get { return FirstName + " " + LastName; }
    }

    private string title;
    public String Title {
      get { return title; }
      set { title = value; }
    }

    private string titleOfCourtesy;
    public string Courtesy {
      get { return titleOfCourtesy; }
      set { titleOfCourtesy = value; }
    }

    private int    reportsTo;
    public int Supervisor {
      get { return reportsTo; }
      set { reportsTo = value; }
    }

    public bool Save () {
      // Implement persistence logic.
      return true;
    }

    public bool Delete () {
      // Implement delete logic.
      return true;
    }
  }

  internal class NorthwindDataException: Exception {
    public NorthwindDataException(string msg) : base (msg) { }
  }
}
// </snippet2>