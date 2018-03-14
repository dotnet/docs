// <snippet1>
namespace Samples.AspNet.CS.Controls
{
  using System;
  using System.Collections;
  using System.ComponentModel;
  using System.Web.UI;
  using System.Web.UI.WebControls;

// <snippet2>
  public class NorthwindEmployee
  {
    public NorthwindEmployee() { }

    private int _employeeID;
    [DataObjectFieldAttribute(true, true, false)]
    public int EmployeeID
    {
      get { return _employeeID; }
      set { _employeeID = value; }
    }

    private string _firstName = String.Empty;
    [DataObjectFieldAttribute(false, false, true)]
    public string FirstName
    {
      get { return _firstName; }
      set { _firstName = value; }
    }

    private string _lastName = String.Empty;
    [DataObjectFieldAttribute(false, false, true)]
    public string LastName
    {
      get { return _lastName; }
      set { _lastName = value; }
    }
  }
// </snippet2>

// <snippet3>
  [DataObjectAttribute]
  public class NorthwindData
  {  
    public NorthwindData() {}

    [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
    public static IEnumerable GetAllEmployees()
    {
      AccessDataSource ads = new AccessDataSource();
      ads.DataSourceMode = SqlDataSourceMode.DataReader;
      ads.DataFile = "~//App_Data//Northwind.mdb";
      ads.SelectCommand = "SELECT EmployeeID,FirstName,LastName FROM Employees";
      return ads.Select(DataSourceSelectArguments.Empty);
    }

    // Delete the Employee by ID.
    [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
    public void DeleteEmployeeByID(int employeeID)
    {
      throw new Exception("The value passed to the delete method is "
                           + employeeID.ToString());
    }
  }
// </snippet3>
}
// </snippet1>