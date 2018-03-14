//<Snippet13>
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.ObjectDataSource
{
  public class NorthwindEmployee
  {
    private int _employeeID;
    private string _lastName;
    private string _firstName;
    private string _address;
    private string _city;
    private string _region;
    private string _postalCode;

    public NorthwindEmployee()
    {
    }

    public int EmployeeID
    {
      get { return _employeeID; }
      set { _employeeID = value; }
    }

    public string LastName
    {
      get { return _lastName; }
      set { _lastName = value; }
    }

    public string FirstName
    {
      get { return _firstName; }
      set { _firstName = value; }
    }

    public string Address
    {
      get { return _address; }
      set { _address = value; }
    }

    public string City
    {
      get { return _city; }
      set { _city = value; }
    }

    public string Region
    {
      get { return _region; }
      set { _region = value; }
    }

    public string PostalCode
    {
      get { return _postalCode; }
      set { _postalCode = value; }
    }
  }
 
  //
  //  Northwind Employee Data Factory
  //

  public class NorthwindEmployeeData
  {

    private string _connectionString;


    public NorthwindEmployeeData()
    {
      Initialize();
    }


    public void Initialize()
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
    }


    // Select all employees.

    public List<NorthwindEmployee> GetAllEmployees(string sortColumns, int startRecord, int maxRecords)
    {
      VerifySortColumns(sortColumns);

      string sqlCmd = "SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode FROM Employees ";

      if (sortColumns.Trim() == "")
        sqlCmd += "ORDER BY EmployeeID";
      else
        sqlCmd += "ORDER BY " + sortColumns;

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlCommand    cmd  = new SqlCommand(sqlCmd, conn);

      SqlDataReader reader = null; 
      List<NorthwindEmployee> employees = new List<NorthwindEmployee>();
      int count = 0;

      try
      {
        conn.Open();

        reader = cmd.ExecuteReader();

        while (reader.Read())
        {
          if (count >= startRecord)
          {
            if (employees.Count < maxRecords)
              employees.Add(GetNorthwindEmployeeFromReader(reader));
            else
              cmd.Cancel();
          }          

          count++;
        }
        
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        if (reader != null) { reader.Close(); }
        conn.Close();
      }

      return employees;
    }


    //////////
    // Verify that only valid columns are specified in the sort expression to avoid a SQL Injection attack.

    private void VerifySortColumns(string sortColumns)
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


    private NorthwindEmployee GetNorthwindEmployeeFromReader(SqlDataReader reader)
    {
      NorthwindEmployee employee = new NorthwindEmployee();

      employee.EmployeeID = reader.GetInt32(0);
      employee.LastName   = reader.GetString(1);
      employee.FirstName  = reader.GetString(2);

      if (reader.GetValue(3) != DBNull.Value)
        employee.Address = reader.GetString(3);

      if (reader.GetValue(4) != DBNull.Value)
        employee.City = reader.GetString(4);

      if (reader.GetValue(5) != DBNull.Value)
        employee.Region = reader.GetString(5);

      if (reader.GetValue(6) != DBNull.Value)
        employee.PostalCode = reader.GetString(6);

      return employee;
    }



    // Select an employee.

    public List<NorthwindEmployee> GetEmployee(int EmployeeID)
    {
      SqlConnection conn = new SqlConnection(_connectionString);
      SqlCommand    cmd  = 
        new SqlCommand("SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode " +
                       "  FROM Employees WHERE EmployeeID = @EmployeeID", conn); 
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;

      SqlDataReader reader = null;
      List<NorthwindEmployee> employees = new List<NorthwindEmployee>();

      try
      {
        conn.Open();
        
        reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

        while (reader.Read())
          employees.Add(GetNorthwindEmployeeFromReader(reader));
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        if (reader != null) { reader.Close(); }

        conn.Close();
      }

      return employees;
    }
  

    //
    // Update the Employee by ID.
    //   This method assumes that ConflictDetection is set to OverwriteValues.

    public int UpdateEmployee(NorthwindEmployee employee)
    {
      if (String.IsNullOrEmpty(employee.FirstName))
        throw new ArgumentException("FirstName cannot be null or an empty string.");
      if (String.IsNullOrEmpty(employee.LastName))
        throw new ArgumentException("LastName cannot be null or an empty string.");

      if (employee.Address    == null) { employee.Address    = String.Empty; }
      if (employee.City       == null) { employee.City       = String.Empty; }
      if (employee.Region     == null) { employee.Region     = String.Empty; }
      if (employee.PostalCode == null) { employee.PostalCode = String.Empty; }

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlCommand    cmd  = new SqlCommand("UPDATE Employees " + 
                                          "  SET FirstName=@FirstName, LastName=@LastName, " + 
                                          "  Address=@Address, City=@City, Region=@Region, " +
                                          "  PostalCode=@PostalCode " +
                                          "  WHERE EmployeeID=@EmployeeID", conn);  

      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = employee.FirstName;
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = employee.LastName;
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = employee.Address;
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = employee.City;
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = employee.Region;
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = employee.PostalCode;
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employee.EmployeeID;

      int result = 0;

      try
      {
        conn.Open();

        result = cmd.ExecuteNonQuery();
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        conn.Close();
      }

      return result;
    }


    // Insert an Employee.

    public int InsertEmployee(NorthwindEmployee employee)
    {
      if (String.IsNullOrEmpty(employee.FirstName))
        throw new ArgumentException("FirstName cannot be null or an empty string.");
      if (String.IsNullOrEmpty(employee.LastName))
        throw new ArgumentException("LastName cannot be null or an empty string.");

      if (employee.Address    == null) { employee.Address    = String.Empty; }
      if (employee.City       == null) { employee.City       = String.Empty; }
      if (employee.Region     == null) { employee.Region     = String.Empty; }
      if (employee.PostalCode == null) { employee.PostalCode = String.Empty; }

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlCommand    cmd  = new SqlCommand("INSERT INTO Employees " + 
                                          "  (FirstName, LastName, Address, City, Region, PostalCode) " +
                                          "  Values(@FirstName, @LastName, @Address, @City, @Region, @PostalCode); " +
                                          "SELECT @EmployeeID = SCOPE_IDENTITY()", conn);  

      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = employee.FirstName;
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = employee.LastName;
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = employee.Address;
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = employee.City;
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = employee.Region;
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = employee.PostalCode;
      SqlParameter p = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
      p.Direction = ParameterDirection.Output;

      int newEmployeeID = 0;

      try
      {
        conn.Open();

        cmd.ExecuteNonQuery();

        newEmployeeID = (int)p.Value;
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        conn.Close();
      }

      return newEmployeeID;
    }


    //
    // Delete the Employee by ID.
    //   This method assumes that ConflictDetection is set to OverwriteValues.

    public int DeleteEmployee(NorthwindEmployee employee)
    {
      string sqlCmd = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

      SqlConnection conn = new SqlConnection(_connectionString);
      SqlCommand cmd = new SqlCommand(sqlCmd, conn);  
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employee.EmployeeID;

      int result = 0;

      try
      {
        conn.Open();

        result = cmd.ExecuteNonQuery();
      }
      catch (SqlException e)
      {
        // Handle exception.
      }
      finally
      {
        conn.Close();
      }

      return result;
    }

  }
}
//</Snippet13>