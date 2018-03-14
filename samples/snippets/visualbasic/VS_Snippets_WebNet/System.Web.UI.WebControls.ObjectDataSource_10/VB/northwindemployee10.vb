' <snippet2>
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB
'
' EmployeeLogic is a stateless business object that encapsulates
' the operations you can perform on a NorthwindEmployee object.
Public Class EmployeeLogic

   ' Return a collection of NorthwindEmployee objects.
   Public Shared Function GetAllEmployees() As ICollection
      Dim al As New ArrayList()

      ' Use the SqlDataSource class to wrap the
      ' ADO.NET code required to query the database.
      Dim cts As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("NorthwindConnection")
      Dim sds As New SqlDataSource(cts.ConnectionString, _
                                  "SELECT EmployeeID FROM Employees")
      Try
         Dim IDs As IEnumerable = sds.Select(DataSourceSelectArguments.Empty)

         ' Iterate through the Enumeration and create a
         ' NorthwindEmployee object for each ID.
         Dim enumerator As IEnumerator = IDs.GetEnumerator()
         While enumerator.MoveNext()
            ' The IEnumerable contains DataRowView objects.
            Dim row As DataRowView = CType(enumerator.Current,DataRowView)
            Dim id As String = row("EmployeeID").ToString()
            Dim nwe As New NorthwindEmployee(id)
            ' Add the NorthwindEmployee object to the collection.
            al.Add(nwe)
         End While
      Finally
         ' If anything strange happens, clean up.
         sds.Dispose()
      End Try

      Return al
   End Function 'GetAllEmployees


   Public Shared Function GetEmployee(anID As Object) As NorthwindEmployee
      Return New NorthwindEmployee(anID)
   End Function 'GetEmployee


   Public Shared Sub DeleteEmployee(ne As NorthwindEmployee)
      Dim retval As Boolean = ne.Delete()
      If Not retval Then
         Throw New NorthwindDataException("Employee delete failed.")
      End If ' Delete the object in memory.
      ne = Nothing
   End Sub 'DeleteEmployee


   Public Shared Sub DeleteEmployeeByID(anID As Integer)
      Dim tempEmp As New NorthwindEmployee(anID)
      DeleteEmployee(tempEmp)
   End Sub 'DeleteEmployeeByID

End Class 'EmployeeLogic

Public Class NorthwindEmployee

   Public Sub New()
      ID = DBNull.Value
      aLastName = ""
      aFirstName = ""
   End Sub 'New


   Public Sub New(anID As Object)
      Me.ID = anID
      Dim cts As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("NorthwindConnection")
      Dim conn As New SqlConnection(cts.ConnectionString)
      Dim sc As New SqlCommand(" SELECT FirstName,LastName " & _
                               " FROM Employees " & _
                               " WHERE EmployeeID = @empId", conn)
      ' Add the employee ID parameter and set its value.
      sc.Parameters.Add(New SqlParameter("@empId", SqlDbType.Int)).Value = Int32.Parse(anID.ToString())
      Dim sdr As SqlDataReader = Nothing

      Try
         conn.Open()
         sdr = sc.ExecuteReader()

         ' This is not a while loop. It only loops once.
         If Not (sdr Is Nothing) AndAlso sdr.Read() Then
            ' The IEnumerable contains DataRowView objects.
            Me.aFirstName = sdr("FirstName").ToString()
            Me.aLastName = sdr("LastName").ToString()
         Else
            Throw New NorthwindDataException("Data not loaded for employee id.")
         End If
      Finally
         Try
            If Not (sdr Is Nothing) Then
               sdr.Close()
            End If
            conn.Close()
         Catch se As SqlException
            ' Log an event in the Application Event Log.
            Throw
         End Try
      End Try
   End Sub 'New

   Private ID As Object
   Public ReadOnly Property EmpID() As Object
      Get
         Return ID
      End Get
   End Property

   Private aLastName As String
   Public Property LastName() As String
      Get
         Return aLastName
      End Get
      Set
         aLastName = value
      End Set
   End Property

   Private aFirstName As String
   Public Property FirstName() As String
      Get
         Return aFirstName
      End Get
      Set
         aFirstName = value
      End Set
   End Property

' <snippet3>
   Public Function Delete() As Boolean
      If ID.Equals(DBNull.Value) Then
         ' The Employee object is not persisted.
         Return True
      Else
         ' The Employee object is persisted.
         ' Use the SqlDataSource control as a convenient wrapper for
         ' the ADO.NET code needed to delete a record from the database.
         Dim cts As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("NorthwindConnection")
         Dim sds As New SqlDataSource()
         Try
            sds.ConnectionString = cts.ConnectionString
            sds.DeleteParameters.Add(New Parameter("empID", TypeCode.Int32, Me.ID.ToString()))
            sds.DeleteCommand = "DELETE FROM [Order Details] " & _
                "WHERE OrderID IN (SELECT OrderID FROM Orders WHERE EmployeeID=@empID)"
            sds.Delete()
            sds.DeleteCommand = "DELETE FROM Orders WHERE EmployeeID=@empID"
            sds.Delete()
            sds.DeleteCommand = "DELETE FROM EmployeeTerritories WHERE EmployeeID=@empID"
            sds.Delete()
            sds.DeleteCommand = "DELETE FROM Employees WHERE EmployeeID=@empID"
            sds.Delete()
            Return True
         Finally
            ' Clean up resources.
            sds.Dispose()
         End Try
      End If
   End Function 'Delete
' </snippet3>
End Class 'NorthwindEmployee

Public Class NorthwindDataException
   Inherits Exception

   Public Sub New(msg As String)
      MyBase.New(msg)
   End Sub 'New

End Class 'NorthwindDataException
End Namespace
' </snippet2>