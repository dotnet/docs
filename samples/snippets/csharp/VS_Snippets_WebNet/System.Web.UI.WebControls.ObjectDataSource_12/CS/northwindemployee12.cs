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
  // the operations one can perform on a NorthwindEmployee object.
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
      ArrayList al = GetAllEmployees() as ArrayList;
      IEnumerator enumerator = al.GetEnumerator();
      while (enumerator.MoveNext()) {
        // The IEnumerable contains initialized NorthwindEmployee objects.
        NorthwindEmployee ne = enumerator.Current as NorthwindEmployee;
        if (ne.EmpID.Equals(anID.ToString())) {
          return ne;
        }
      }
      return null;
    }
// <snippet3>
    public static void UpdateEmployee(NorthwindEmployee ne) {
      bool retval = ne.Update();
      if (! retval) { throw new NorthwindDataException("Employee update failed."); }
    }

    // This method is added as a conveniece wrapper on the original
    // implementation.
    public static void UpdateEmployeeWrapper(string anID,
                                             string anAddress,
                                             string aCity,
                                             string aPostalCode) {
      NorthwindEmployee ne = new NorthwindEmployee(anID);
      ne.Address = anAddress;
      ne.City = aCity;
      ne.PostalCode = aPostalCode;
      UpdateEmployee(ne);
    }
// </snippet3>

    // And so on...
  }

  public class NorthwindEmployee {

    public NorthwindEmployee (object anID) {
      this.ID = anID;

      ConnectionStringSettings cts = ConfigurationManager.ConnectionStrings["NorthwindConnection"];
      SqlConnection conn = new SqlConnection (cts.ConnectionString);
      SqlCommand sc =
        new SqlCommand(" SELECT FirstName,LastName,Address,City,PostalCode " +
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
          this.firstName       = sdr["FirstName"].ToString();
          this.lastName        = sdr["LastName"].ToString();
          this.address         = sdr["Address"].ToString();
          this.city            = sdr["City"].ToString();
          this.postalCode      = sdr["PostalCode"].ToString();
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
      set { lastName = value; }
    }

    private string firstName;
    public string FirstName {
      set { firstName = value;  }
    }

    public string FullName {
      get { return firstName + " " + lastName; }
    }

    private string address;
    public string Address {
      get { return address; }
      set { address = value;  }
    }

    private string city;
    public string City {
      get { return city; }
      set { city = value;  }
    }

    private string postalCode;
    public string PostalCode {
      get { return postalCode; }
      set { postalCode = value;  }
    }

    public bool Update () {

      // Implement Update logic.

      return true;
    }
  }

  internal class NorthwindDataException: Exception {
    public NorthwindDataException(string msg) : base (msg) { }
  }
}
// </snippet2>