' <snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls

' <snippet2>
  Public Class NorthwindEmployee

    Public Sub New()
    End Sub 'New 

    Private _employeeID As Integer
    <DataObjectFieldAttribute(True, True, False)> _
    Public Property EmployeeID() As Integer
      Get
        Return _employeeID
      End Get
      Set(ByVal value As Integer)
        _employeeID = value
      End Set
    End Property

    Private _firstName As String = String.Empty
    <DataObjectFieldAttribute(False, False, False)> _
    Public Property FirstName() As String
      Get
        Return _firstName
      End Get
      Set(ByVal value As String)
        _firstName = value
      End Set
    End Property

    Private _lastName As String = String.Empty
    <DataObjectFieldAttribute(False, False, False)> _
    Public Property LastName() As String
      Get
        Return _lastName
      End Get
      Set(ByVal value As String)
        _lastName = value
      End Set
    End Property

  End Class 'NorthwindEmployee
' </snippet2>

' <snippet3>
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
' </snippet3>

End Namespace ' Samples.AspNet.VB.Controls 
' </snippet1>