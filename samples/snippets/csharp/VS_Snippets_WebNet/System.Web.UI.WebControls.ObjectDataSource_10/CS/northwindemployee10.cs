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

      // Use the SqlDataSource class to wrap the
      // ADO.NET code required to query the database.
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
      return new NorthwindEmployee(anID);
    }

    public static void DeleteEmployee(NorthwindEmployee ne) {
      bool retval = ne.Delete();
      if (! retval) { throw new NorthwindDataException("Employee delete failed."); }
      // Delete the object in memory.
      ne = null;
    }

    public static void DeleteEmployeeByID(int anID) {
        NorthwindEmployee tempEmp = new NorthwindEmployee(anID);
        DeleteEmployee(tempEmp);
    }
  }

  public class NorthwindEmployee {

    public NorthwindEmployee () {
      ID = DBNull.Value;
      lastName = "";
      firstName = "";
    }

    public NorthwindEmployee (object anID) {
      this.ID = anID;

      ConnectionStringSettings cts = ConfigurationManager.ConnectionStrings["NorthwindConnection"];

      SqlConnection conn = new SqlConnection (cts.ConnectionString);
      SqlCommand sc =
        new SqlCommand(" SELECT FirstName,LastName " +
                       " FROM Employees " +
                       " WHERE EmployeeID = @empId",
                       conn);
      // Add the employee ID parameter and set its value.
      sc.Parameters.Add(new SqlParameter("@empId",SqlDbType.Int)).Value = Int32.Parse(anID.ToString());
      SqlDataReader sdr = null;

      try {
        conn.Open();
        sdr = sc.ExecuteReader();

        // This is not a while loop. It only loops once.
        if (sdr != null && sdr.Read()) {
          // The IEnumerable contains DataRowView objects.
          this.firstName        = sdr["FirstName"].ToString();
          this.lastName         = sdr["LastName"].ToString();
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
    public object EmpID {
      get { return ID; }
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
// <snippet3>
    public bool Delete () {
      if (ID.Equals(DBNull.Value)) {
        // The Employee object is not persisted.
        return true;
      }
      else {
        // The Employee object is persisted.
        // Use the SqlDataSource control as a convenient wrapper for
        // the ADO.NET code needed to delete a record from the database.
        ConnectionStringSettings cts = ConfigurationManager.ConnectionStrings["NorthwindConnection"];
        SqlDataSource sds = new SqlDataSource();

        try {
          sds.ConnectionString = cts.ConnectionString;
          sds.DeleteParameters.Add(new Parameter("empID", TypeCode.Int32, this.ID.ToString()));
          sds.DeleteCommand = "DELETE FROM [Order Details] " + 
              "WHERE OrderID IN (SELECT OrderID FROM Orders WHERE EmployeeID=@empID)";
          sds.Delete();
          sds.DeleteCommand = "DELETE FROM Orders WHERE EmployeeID=@empID";
          sds.Delete();
          sds.DeleteCommand = "DELETE FROM EmployeeTerritories WHERE EmployeeID=@empID";
          sds.Delete();
          sds.DeleteCommand = "DELETE FROM Employees WHERE EmployeeID=@empID";
          sds.Delete();
          return true;
        }
        finally {
          // Clean up resources.
          sds.Dispose();
        }
      }
    }
// </snippet3>
  }

  public class NorthwindDataException: Exception {
    public NorthwindDataException(string msg) : base (msg) { }
  }
}
// </snippet2>