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