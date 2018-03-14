using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.Controls
{
//<Snippet10>
  [DataObject(true)]
  public class NorthwindEmployee
//</Snippet10>
  {

    private static string _connectionString;
    private static bool _initialized = false;

    public NorthwindEmployee()
    {
      Initialize();
    }


//<Snippet5>
    public static void Initialize()
    {
      // Initialize data source. Use "Northwind" connection string from configuration.

      if (ConfigurationManager.ConnectionStrings["Northwind"] == null ||
          ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString.Trim() == "")
      {
        throw new Exception("A connection string named 'Northwind' with a valid connection string " + 
                            "must exist in the <connectionStrings> configuration section for the application.");
      }

      _connectionString = 
        ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

      _initialized = true;
    }


    // Select all employees.

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static DataTable GetAllEmployees(string sortColumns, int startRecord, int maxRecords)
    {
      VerifySortColumns(sortColumns);

      if (!_initialized) { Initialize(); }

      string sqlCommand = "SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode FROM Employees ";

      if (sortColumns.Trim() == "")
        sqlCommand += "ORDER BY EmployeeID";
      else
        sqlCommand += "ORDER BY " + sortColumns;

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlDataAdapter da  = new SqlDataAdapter(sqlCommand, conn); 

      DataSet ds =  new DataSet(); 

      try
      {
        conn.Open();
        da.Fill(ds, startRecord, maxRecords, "Employees");
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        conn.Close();
      }

      if (ds.Tables["Employees"] != null)
        return ds.Tables["Employees"];

      return null;
    }


    //////////
    // Verify that only valid columns are specified in the sort expression to avoid a SQL Injection attack.

    private static void VerifySortColumns(string sortColumns)
    {
      if (sortColumns.ToLowerInvariant().EndsWith(" desc"))
        sortColumns = sortColumns.Substring(0, sortColumns.Length - 5);

      string[] columnNames = sortColumns.Split(',');

      foreach (string columnName in columnNames)
      {
        switch (columnName.Trim().ToLowerInvariant())
        {
          case "employeeid":
            break;
          case "lastname":
            break;
          case "firstname":
            break;
          case "":
            break;
          default:
            throw new ArgumentException("SortColumns contains an invalid column name.");
            break;
        }
      }
    }
//</Snippet5>


    // Select an employee.
//<Snippet6>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static DataTable GetEmployee(int EmployeeID)
    {
      if (!_initialized) { Initialize(); }

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlDataAdapter da  = 
        new SqlDataAdapter("SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode FROM Employees WHERE EmployeeID = @EmployeeID", conn); 
      da.SelectCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;

      DataSet ds =  new DataSet(); 

      try
      {
        conn.Open();
        da.Fill(ds, "Employees");
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        conn.Close();
      }

      if (ds.Tables["Employees"] != null)
        return ds.Tables["Employees"];

      return null;
    }
//</Snippet6>    


    // Delete the Employee by ID.
//<Snippet7>
    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static bool DeleteEmployee(int EmployeeID)
    {
      if (!_initialized) { Initialize(); }

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlCommand    cmd  = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", conn);  
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;

      try
      {
        conn.Open();

        if (cmd.ExecuteNonQuery() == 0)
          return false;
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        conn.Close();
      }

      return true;
    }
//</Snippet7>


    // Update the Employee by original ID.
//<Snippet8>
    [DataObjectMethod(DataObjectMethodType.Update)]
    public static bool UpdateEmployee(int EmployeeID, string FirstName, string LastName, 
                                      string Address, string City, string Region, string PostalCode)
    {
      if (String.IsNullOrEmpty(FirstName))
        throw new ArgumentException("FirstName cannot be null or an empty string.");
      if (String.IsNullOrEmpty(LastName))
        throw new ArgumentException("LastName cannot be null or an empty string.");

      if (Address    == null) { Address    = String.Empty; }
      if (City       == null) { City       = String.Empty; }
      if (Region     == null) { Region     = String.Empty; }
      if (PostalCode == null) { PostalCode = String.Empty; }

      if (!_initialized) { Initialize(); }

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlCommand    cmd  = new SqlCommand("UPDATE Employees " + 
                                          "  SET FirstName=@FirstName, LastName=@LastName, " + 
                                          "  Address=@Address, City=@City, Region=@Region, " +
                                          "  PostalCode=@PostalCode " +
                                          "  WHERE EmployeeID=@EmployeeID", conn);  

      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = FirstName;
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = LastName;
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = Address;
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = City;
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = Region;
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = PostalCode;
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;

      try
      {
        conn.Open();

        if (cmd.ExecuteNonQuery() == 0)
          return false;
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        conn.Close();
      }

      return true;
    }
//</Snippet8>


    // Insert an Employee.
//<Snippet9>
    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static bool InsertEmployee(out int NewEmployeeID, string FirstName, string LastName, 
                                      string Address, string City, string Region, string PostalCode)
    {
      if (String.IsNullOrEmpty(FirstName))
        throw new ArgumentException("FirstName cannot be null or an empty string.");
      if (String.IsNullOrEmpty(LastName))
        throw new ArgumentException("LastName cannot be null or an empty string.");

      if (Address    == null) { Address    = String.Empty; }
      if (City       == null) { City       = String.Empty; }
      if (Region     == null) { Region     = String.Empty; }
      if (PostalCode == null) { PostalCode = String.Empty; }

      if (!_initialized) { Initialize(); }

      NewEmployeeID = -1;

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlCommand    cmd  = new SqlCommand("INSERT INTO Employees " + 
                                          "  (FirstName, LastName, Address, City, Region, PostalCode) " +
                                          "  Values(@FirstName, @LastName, @Address, @City, @Region, @PostalCode); " +
                                          "SELECT @EmployeeID = SCOPE_IDENTITY()", conn);  

      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = FirstName;
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = LastName;
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = Address;
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = City;
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = Region;
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = PostalCode;
      SqlParameter p = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
      p.Direction = ParameterDirection.Output;

      try
      {
        conn.Open();

        cmd.ExecuteNonQuery();

        NewEmployeeID = (int)p.Value;
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        conn.Close();
      }

      return true;
    }
//</Snippet9>

  }
}
