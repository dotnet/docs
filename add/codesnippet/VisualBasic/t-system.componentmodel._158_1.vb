  <DataObjectAttribute()> _
  Public Class NorthwindData

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Shared Function GetAllEmployees() As IEnumerable
      Dim ads As New AccessDataSource()
      ads.DataSourceMode = SqlDataSourceMode.DataReader
      ads.DataFile = "~/App_Data/Northwind.mdb"
      ads.SelectCommand = "SELECT EmployeeID,FirstName,LastName FROM Employees"
      Return ads.Select(DataSourceSelectArguments.Empty)
    End Function 'GetAllEmployees

    ' Delete the Employee by ID.
    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)> _
    Public Sub DeleteEmployeeByID(ByVal employeeID As Integer)
      Throw New Exception("The value passed to the delete method is " + employeeID.ToString())
    End Sub 'DeleteEmployeeByID

  End Class 'NorthwindData