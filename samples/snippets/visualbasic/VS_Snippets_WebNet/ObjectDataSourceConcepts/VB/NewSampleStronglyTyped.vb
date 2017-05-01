'<Snippet13>
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.ObjectDataSource

  Public Class NorthwindEmployee  
    Private _employeeID As Integer
    Private _lastName As String
    Private _firstName As String
    Private _address As String
    Private _city As String
    Private _region As String
    Private _postalCode As String

    Public Sub New()    
    End Sub

    Public Property EmployeeID As Integer    
      Get
        Return _employeeID
      End Get
      Set
        _employeeID = value
      End Set
    End Property

    Public Property LastName As String    
      Get
        Return _lastName
      End Get
      Set
        _lastName = value
      End Set
    End Property

    Public Property FirstName As String    
      Get
        Return _firstName
      End Get
      Set
        _firstName = value
      End Set
    End Property

    Public Property Address As String    
      Get
        Return _address
      End Get
      Set
        _address = value
      End Set
    End Property

    Public Property City As String    
      Get
        Return _city
      End Get
      Set
        _city = value
      End Set
    End Property

    Public Property Region As String    
      Get
        Return _region
      End Get
      Set
        _region = value
      End Set
    End Property

    Public Property PostalCode As String    
      Get
        Return _postalCode
      End Get
      Set
        _postalCode = value
      End Set
    End Property
  End Class
 
  '
  '  Northwind Employee Data Factory
  '

  Public Class NorthwindEmployeeData  

    Private _connectionString As String

    Public Sub New()    
      Initialize()
    End Sub

    Public Sub Initialize()    
      ' Initialize data source. Use "Northwind" connection string from configuration.

      If ConfigurationManager.ConnectionStrings("Northwind") Is Nothing OrElse _
          ConfigurationManager.ConnectionStrings("Northwind").ConnectionString.Trim() = "" Then     
        Throw New Exception("A connection string named 'Northwind' with a valid connection string " & _
                            "must exist in the <connectionStrings> configuration section for the application.")
      End If

      _connectionString = _
        ConfigurationManager.ConnectionStrings("Northwind").ConnectionString
    End Sub


    ' Select all employees.

    Public Function GetAllEmployees(sortColumns As String, startRecord As Integer, _
                                    maxRecords As Integer) As List(of NorthwindEmployee)
    
      VerifySortColumns(sortColumns)

      Dim sqlCmd As String = "SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode FROM Employees "

      If sortColumns.Trim() = "" Then
        sqlCmd &= "ORDER BY EmployeeID"
      Else
        sqlCmd &= "ORDER BY " & sortColumns
      End If

      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand(sqlCmd, conn)

      Dim reader As SqlDataReader = Nothing
      Dim employees As List(of NorthwindEmployee) = New List(of NorthwindEmployee)()
      Dim count As Integer = 0

      Try      
        conn.Open()

        reader = cmd.ExecuteReader()

        Do While reader.Read()        
          If count >= startRecord Then          
            If employees.Count < maxRecords Then
              employees.Add(GetNorthwindEmployeeFromReader(reader))
            Else
              cmd.Cancel()
            End If
          End If         

          count += 1
        Loop
      Catch e As SqlException      
        ' Handle exception.
      Finally      
        If reader IsNot Nothing Then reader.Close() 
        conn.Close()
      End Try

      Return employees
    End Function


    '''''
    ' Verify that only valid columns are specified in the sort expression to aSub a SQL Injection attack.

    Private Sub VerifySortColumns(sortColumns As String)    
      If sortColumns.ToLowerInvariant().EndsWith(" desc") Then _
        sortColumns = sortColumns.Substring(0, sortColumns.Length - 5)

      Dim columnNames() As String = sortColumns.Split(",")

      For Each columnName As String In columnNames      
        Select Case columnName.Trim().ToLowerInvariant()        
          Case "employeeid"
          Case "lastname"
          Case "firstname"
          Case ""
          Case Else
            Throw New ArgumentException("SortColumns contains an invalid column name.")
        End Select
      Next
    End Sub


    Private Function GetNorthwindEmployeeFromReader(reader As SqlDataReader) As NorthwindEmployee     
      Dim employee As NorthwindEmployee = New NorthwindEmployee()

      employee.EmployeeID = reader.GetInt32(0)
      employee.LastName   = reader.GetString(1)
      employee.FirstName  = reader.GetString(2)

      If reader.GetValue(3) IsNot DBNull.Value Then _
        employee.Address = reader.GetString(3)

      If reader.GetValue(4) IsNot DBNull.Value Then _
        employee.City = reader.GetString(4)

      If reader.GetValue(5) IsNot DBNull.Value Then _
        employee.Region = reader.GetString(5)

      If reader.GetValue(6) IsNot DBNull.Value Then _
        employee.PostalCode = reader.GetString(6)

      Return employee
    End Function



    ' Select an employee.

    Public Function GetEmployee(EmployeeID As Integer) As List(of NorthwindEmployee)    
      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = _
        New SqlCommand("SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode " & _
                       "  FROM Employees WHERE EmployeeID = @EmployeeID", conn) 
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID

      Dim reader As SqlDataReader = Nothing
      Dim employees As List(of NorthwindEmployee) = New List(of NorthwindEmployee)()

      Try      
        conn.Open()
        
        reader = cmd.ExecuteReader(CommandBehavior.SingleRow)

        Do While reader.Read()
          employees.Add(GetNorthwindEmployeeFromReader(reader))
        Loop
      Catch e As SqlException      
        ' Handle exception.
      Finally      
        If reader IsNot Nothing Then reader.Close() 
        conn.Close()
      End Try

      Return employees
    End Function
  

    '
    ' Update the Employee by ID.
    '   This method assumes that ConflictDetection is Set to OverwriteValues.

    Public Function UpdateEmployee(employee As NorthwindEmployee) As Integer
    
      If String.IsNullOrEmpty(employee.FirstName) Then _
        Throw New ArgumentException("FirstName cannot be null or an empty string.")
      If String.IsNullOrEmpty(employee.LastName) Then _
        Throw New ArgumentException("LastName cannot be null or an empty string.")

      If employee.Address    Is Nothing Then employee.Address    = String.Empty 
      If employee.City       Is Nothing Then employee.City       = String.Empty 
      If employee.Region     Is Nothing Then employee.Region     = String.Empty 
      If employee.PostalCode Is Nothing Then employee.PostalCode = String.Empty 

      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand("UPDATE Employees " & _
                                          "  SET FirstName=@FirstName, LastName=@LastName, " & _
                                          "  Address=@Address, City=@City, Region=@Region, " & _
                                          "  PostalCode=@PostalCode " & _
                                          "  WHERE EmployeeID=@EmployeeID", conn)  

      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = employee.FirstName
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = employee.LastName
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = employee.Address
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = employee.City
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = employee.Region
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = employee.PostalCode
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employee.EmployeeID

      Dim result As Integer = 0

      Try      
        conn.Open()

        result = cmd.ExecuteNonQuery()
      Catch e As SqlException      
        ' Handle exception.
      Finally      
        conn.Close()
      End Try

      Return result
    End Function


    ' Insert an Employee.

    Public Function InsertEmployee(employee As NorthwindEmployee) As Integer
      If String.IsNullOrEmpty(employee.FirstName) Then _
        Throw New ArgumentException("FirstName cannot be null or an empty string.")
      If String.IsNullOrEmpty(employee.LastName) Then _
        Throw New ArgumentException("LastName cannot be null or an empty string.")

      If employee.Address    Is Nothing Then employee.Address    = String.Empty 
      If employee.City       Is Nothing Then employee.City       = String.Empty 
      If employee.Region     Is Nothing Then employee.Region     = String.Empty 
      If employee.PostalCode Is Nothing Then employee.PostalCode = String.Empty 

      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand("INSERT INTO Employees " & _
                                          "  (FirstName, LastName, Address, City, Region, PostalCode) " & _
                                          "  Values(@FirstName, @LastName, @Address, @City, @Region, @PostalCode) " & _
                                          "SELECT @EmployeeID = SCOPE_IDENTITY()", conn)  

      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = employee.FirstName
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = employee.LastName
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = employee.Address
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = employee.City
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = employee.Region
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = employee.PostalCode
      Dim p As SqlParameter = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int)
      p.Direction = ParameterDirection.Output

      Dim newEmployeeID As Integer= 0

      Try      
        conn.Open()

        cmd.ExecuteNonQuery()

        newEmployeeID = CInt(p.Value)
      Catch e As SqlException      
        ' Handle exception.
      Finally      
        conn.Close()
      End Try

      Return newEmployeeID
    End Function


    '
    ' Delete the Employee by ID.
    '   This method assumes that ConflictDetection is Set to OverwriteValues.

    Public Function DeleteEmployee(employee As NorthwindEmployee) As Integer    
      Dim sqlCmd As String = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID"

      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand(sqlCmd, conn)  
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employee.EmployeeID

      Dim result As Integer = 0

      Try      
        conn.Open()

        result = cmd.ExecuteNonQuery()
      Catch e As SqlException      
        ' Handle exception.
      Finally      
        conn.Close()
      End Try

      Return result
    End Function

  End Class
End Namespace
'</Snippet13>