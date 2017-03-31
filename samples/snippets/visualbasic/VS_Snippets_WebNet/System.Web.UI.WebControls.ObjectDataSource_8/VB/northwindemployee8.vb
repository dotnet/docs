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
'
Public Class EmployeeLogic

   ' Returns a collection of NorthwindEmployee objects.
   Public Shared Function GetAllEmployees() As ICollection
      Dim al As New ArrayList()

      Dim cts As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("NorthwindConnection")

      Dim sds As New SqlDataSource(cts.ConnectionString, "SELECT EmployeeID FROM Employees")

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
      If anID.Equals("-1") OrElse anID.Equals(DBNull.Value) Then
         Return New NorthwindEmployee()
      Else
         Return New NorthwindEmployee(anID)
      End If
   End Function 'GetEmployee

' <snippet3>
   ' This InsertNewEmployeeWrapper method is a wrapper method that enables
   ' the use of ObjectDataSource and InsertParameters, without
   ' substantially rewriting the true implementation for the NorthwindEmployee
   ' or the EmployeeLogic objects.
   '
   ' The parameters to the method must be named the same as the
   ' DataControlFields used by the GridView or DetailsView controls.
   Public Shared Sub InsertNewEmployeeWrapper(FirstName As String, LastName As String, Title As String, Courtesy As String, Supervisor As Integer)
      ' Build the NorthwindEmployee object and
      ' call the true  implementation.
      Dim tempEmployee As New NorthwindEmployee()

      tempEmployee.FirstName = FirstName
      tempEmployee.LastName = LastName
      tempEmployee.Title = Title
      tempEmployee.Courtesy = Courtesy
      tempEmployee.Supervisor = Supervisor

      ' Call the true implementation.
      InsertNewEmployee(tempEmployee)
   End Sub 'InsertNewEmployeeWrapper


   Public Shared Sub InsertNewEmployee(ne As NorthwindEmployee)
      Dim retval As Boolean = ne.Save()
      If Not retval Then
         Throw New NorthwindDataException("InsertNewEmployee failed.")
      End If
   End Sub 'InsertNewEmployee
' </snippet3>

   ' And so on...
End Class 'EmployeeLogic


Public Class NorthwindEmployee

   Public Sub New()
      ID = DBNull.Value
      aLastName = ""
      aFirstName = ""
      aTitle = ""
      titleOfCourtesy = ""
      reportsTo = - 1
   End Sub 'New


   Public Sub New(anID As Object)
      Me.ID = anID

      Dim cts As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("NorthwindConnection")

      Dim conn As New SqlConnection(cts.ConnectionString)

      Dim sc As New SqlCommand(" SELECT FirstName,LastName,Title,TitleOfCourtesy,ReportsTo " & _
                               " FROM Employees " & _
                               " WHERE EmployeeID = @empId", conn)

      ' Add the employee ID parameter and set its value.
      sc.Parameters.Add(New SqlParameter("@empId", SqlDbType.Int)).Value = Int32.Parse(anID.ToString())
      Dim sdr As SqlDataReader = Nothing

      Try
         conn.Open()
         sdr = sc.ExecuteReader()

         ' Only loop once.
         If Not (sdr Is Nothing) AndAlso sdr.Read() Then
            ' The IEnumerable contains DataRowView objects.
            Me.aFirstName = sdr("FirstName").ToString()
            Me.aLastName = sdr("LastName").ToString()
            Me.aTitle = sdr("Title").ToString()
            Me.titleOfCourtesy = sdr("TitleOfCourtesy").ToString()
            If Not sdr.IsDBNull(4) Then
               Me.reportsTo = sdr.GetInt32(4)
            End If
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
   Public ReadOnly Property EmpID() As String
      Get
         Return ID.ToString()
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

   Private aTitle As String
   Public Property Title() As String
      Get
         Return aTitle
      End Get
      Set
         aTitle = value
      End Set
   End Property

   Private titleOfCourtesy As String
   Public Property Courtesy() As String
      Get
         Return titleOfCourtesy
      End Get
      Set
         titleOfCourtesy = value
      End Set
   End Property

   Private reportsTo As Integer
   Public Property Supervisor() As Integer
      Get
         Return reportsTo
      End Get
      Set
         reportsTo = value
      End Set
   End Property

   Public Function Save() As Boolean
      ' Implement persistence logic.
      Return True
   End Function 'Save
End Class 'NorthwindEmployee

Friend Class NorthwindDataException
   Inherits Exception

   Public Sub New(msg As String)
      MyBase.New(msg)
   End Sub 'New
End Class 'NorthwindDataException
End Namespace
' </snippet2>