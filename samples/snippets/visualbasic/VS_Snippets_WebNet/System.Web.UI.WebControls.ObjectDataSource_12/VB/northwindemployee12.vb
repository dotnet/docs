'<snippet2>
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
' the operations one can perform on a NorthwindEmployee object.
'
Public Class EmployeeLogic

   ' Returns a collection of NorthwindEmployee objects.
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
      Dim al As ArrayList = CType(GetAllEmployees(), ArrayList)
      Dim enumerator As IEnumerator = al.GetEnumerator()
      While enumerator.MoveNext()
         ' The IEnumerable contains initialized NorthwindEmployee objects.
         Dim ne As NorthwindEmployee = CType(enumerator.Current,NorthwindEmployee)
         If ne.EmpID.Equals(anID.ToString()) Then
            Return ne
         End If
      End While
      Return Nothing
   End Function 'GetEmployee
'<Snippet3>

   Public Shared Sub UpdateEmployee(ne As NorthwindEmployee)
      Dim retval As Boolean = ne.Update()
      If Not retval Then
         Throw New NorthwindDataException("Employee update failed.")
      End If
   End Sub 'UpdateEmployee

   ' This method is added as a conveniece wrapper on the original
   ' implementation.
   Public Shared Sub UpdateEmployeeWrapper(anID As String, _
                                           anAddress As String, _
                                           aCity As String, _
                                           aPostalCode As String)
      Dim ne As New NorthwindEmployee(anID)
      ne.Address = anAddress
      ne.City = aCity
      ne.PostalCode = aPostalCode
      UpdateEmployee(ne)
   End Sub 'UpdateEmployeeWrapper
'</Snippet3>
   ' And so on...

End Class 'EmployeeLogic

Public Class NorthwindEmployee

   Public Sub New(anID As Object)
      Me.ID = anID
      Dim cts As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("NorthwindConnection")
      Dim conn As New SqlConnection(cts.ConnectionString)
      Dim sc As New SqlCommand(" SELECT FirstName,LastName,Address,City,PostalCode " & _
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
            Me.aAddress = sdr("Address").ToString()
            Me.aCity = sdr("City").ToString()
            Me.aPostalCode = sdr("PostalCode").ToString()
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
   Public WriteOnly Property LastName() As String
      Set
         aLastName = value
      End Set
   End Property

   Private aFirstName As String
   Public WriteOnly Property FirstName() As String
      Set
         aFirstName = value
      End Set
   End Property

   Public ReadOnly Property FullName() As String
      Get
         Return aFirstName & " " & aLastName
      End Get
   End Property

   Private aAddress As String
   Public Property Address() As String
      Get
         Return aAddress
      End Get
      Set
         aAddress = value
      End Set
   End Property

   Private aCity As String
   Public Property City() As String
      Get
         Return aCity
      End Get
      Set
         aCity = value
      End Set
   End Property

   Private aPostalCode As String
   Public Property PostalCode() As String
      Get
         Return aPostalCode
      End Get
      Set
         aPostalCode = value
      End Set
   End Property

   Public Function Update() As Boolean

      ' Implement Update logic.
      Return True

   End Function 'Update

End Class 'NorthwindEmployee

Friend Class NorthwindDataException
   Inherits Exception

   Public Sub New(msg As String)
      MyBase.New(msg)
   End Sub 'New

End Class 'NorthwindDataException
End Namespace
' </snippet2>