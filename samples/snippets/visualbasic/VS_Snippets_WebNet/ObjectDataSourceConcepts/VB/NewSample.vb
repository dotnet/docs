'<Snippet1>
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.ObjectDataSource
  '
  '  Northwind Employee Data Factory
  '

  Public Class NorthwindData
  

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

    Public Function GetAllEmployees(sortColumns As String, startRecord As Integer, maxRecords As Integer) As DataTable 
    
      VerifySortColumns(sortColumns)

      Dim sqlCmd As String = "SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode FROM Employees "

      If sortColumns.Trim() = "" Then
        sqlCmd &= "ORDER BY EmployeeID"
      Else
        sqlCmd &= "ORDER BY " & sortColumns
      End If

      Dim conn As SqlConnection  = New SqlConnection(_connectionString)
      Dim da   As SqlDataAdapter = New SqlDataAdapter(sqlCmd, conn)

      Dim ds As DataSet = New DataSet()

      Try      
        conn.Open()

        da.Fill(ds, startRecord, maxRecords, "Employees")        
      Catch e As SqlException      
        ' Handle exception.
      Finally      
        conn.Close()
      End Try

      Return ds.Tables("Employees")
    End Function


    Public Function SelectCount() As Integer
    
      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand("SELECT COUNT(*) FROM Employees", conn) 

      Dim result As Integer = 0

      Try      
        conn.Open()

        result = CInt(cmd.ExecuteScalar())
      Catch e As SqlException      
        ' Handle exception.
      Finally
      
        conn.Close()
      End Try

      Return result
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



    ' Select an employee.

    Public Function GetEmployee(EmployeeID As Integer) As DataTable    
      Dim conn As SqlConnection  = New SqlConnection(_connectionString)
      Dim da   As SqlDataAdapter = _
        New SqlDataAdapter("SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode " & _
                           "  FROM Employees WHERE EmployeeID = @EmployeeID", conn) 
      da.SelectCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID

      Dim ds As DataSet = New DataSet()

      Try      
        conn.Open()

        da.Fill(ds, "Employees")
      Catch e As SqlException      
        ' Handle exception.
      Finally      
        conn.Close()
      End Try

      Return ds.Tables("Employees")
    End Function
  


    ' Delete the Employee by ID.

    Public Function DeleteEmployee(EmployeeID As Integer) As Integer    
      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", conn)  
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID

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


    ' Update the Employee by original ID.

    Public Function UpdateEmployee(EmployeeID As Integer, LastName As String, FirstName As String, _
                                   Address As String, City As String, Region As String, _
                                   PostalCode As String) As Integer
    
      If String.IsNullOrEmpty(FirstName) Then _
        Throw New ArgumentException("FirstName cannot be null or an empty string.")
      If String.IsNullOrEmpty(LastName) Then _
        Throw New ArgumentException("LastName cannot be null or an empty string.")

      If Address    Is Nothing Then Address    = String.Empty 
      If City       Is Nothing Then City       = String.Empty 
      If Region     Is Nothing Then Region     = String.Empty 
      If PostalCode Is Nothing Then PostalCode = String.Empty 

      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand("UPDATE Employees " & _
                                          "  SET FirstName=@FirstName, LastName=@LastName, " & _ 
                                          "  Address=@Address, City=@City, Region=@Region, " & _
                                          "  PostalCode=@PostalCode " & _
                                          "  WHERE EmployeeID=@EmployeeID", conn)  

      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = FirstName
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = LastName
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = Address
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = City
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = Region
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = PostalCode
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID

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

    Public Function InsertEmployee(LastName As String, FirstName As String, Address As String, _
                                   City As String, Region As String, PostalCode As String) As Integer
    
      If String.IsNullOrEmpty(FirstName) Then _
        Throw New ArgumentException("FirstName cannot be null or an empty string.")
      If String.IsNullOrEmpty(LastName) Then _
        Throw New ArgumentException("LastName cannot be null or an empty string.")

      If Address    Is Nothing Then Address    = String.Empty 
      If City       Is Nothing Then City       = String.Empty 
      If Region     Is Nothing Then Region     = String.Empty 
      If PostalCode Is Nothing Then PostalCode = String.Empty 

      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand("INSERT INTO Employees " & _ 
                                          "  (FirstName, LastName, Address, City, Region, PostalCode) " & _
                                          "  Values(@FirstName, @LastName, @Address, @City, @Region, @PostalCode) " & _
                                          "SELECT @EmployeeID = SCOPE_IDENTITY()", conn)  

      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = FirstName
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = LastName
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = Address
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = City
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = Region
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = PostalCode
      Dim p As SqlParameter = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int)
      p.Direction = ParameterDirection.Output

      Dim newEmployeeID As Integer = 0

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
    ' Methods that support Optimistic Concurrency checks.
    '

    ' Delete the Employee by ID.

    Public Function DeleteEmployee(original_EmployeeID As Integer, original_LastName As String, _
                                   original_FirstName As String, original_Address As String, _
                                   original_City As String, original_Region As String, _
                                   original_PostalCode As String) As Integer
    
      If String.IsNullOrEmpty(original_FirstName) Then _
        Throw New ArgumentException("FirstName cannot be null or an empty string.")
      If String.IsNullOrEmpty(original_LastName) Then _
        Throw New ArgumentException("LastName cannot be null or an empty string.")

      If original_Address    Is Nothing Then original_Address    = String.Empty 
      If original_City       Is Nothing Then original_City       = String.Empty 
      If original_Region     Is Nothing Then original_Region     = String.Empty 
      If original_PostalCode Is Nothing Then original_PostalCode = String.Empty 

      Dim sqlCmd As String = "DELETE FROM Employees WHERE EmployeeID = @original_EmployeeID " & _ 
                      " AND LastName = @original_LastName AND FirstName = @original_FirstName " & _
                      " AND Address = @original_Address AND City = @original_City " & _
                      " AND Region = @original_Region AND PostalCode = @original_PostalCode"

      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand(sqlCmd, conn) 
 
      cmd.Parameters.Add("@original_EmployeeID", SqlDbType.Int).Value = original_EmployeeID
      cmd.Parameters.Add("@original_FirstName",  SqlDbType.VarChar, 10).Value = original_FirstName
      cmd.Parameters.Add("@original_LastName",   SqlDbType.VarChar, 20).Value = original_LastName
      cmd.Parameters.Add("@original_Address",    SqlDbType.VarChar, 60).Value = original_Address
      cmd.Parameters.Add("@original_City",       SqlDbType.VarChar, 15).Value = original_City
      cmd.Parameters.Add("@original_Region",     SqlDbType.VarChar, 15).Value = original_Region
      cmd.Parameters.Add("@original_PostalCode", SqlDbType.VarChar, 10).Value = original_PostalCode

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


    ' Update the Employee by original ID.

    Public Function UpdateEmployee(EmployeeID As Integer, LastName As String, FirstName As String, _
                                   Address As String, City As String, Region As String, _
                                   PostalCode As String, _
                                   original_EmployeeID As Integer, original_LastName As String, _
                                   original_FirstName As String, original_Address As String, _
                                   original_City As String, original_Region As String, _
                                   original_PostalCode As String) As Integer
    
      If String.IsNullOrEmpty(FirstName) Then _
        Throw New ArgumentException("FirstName cannot be null or an empty string.")
      If String.IsNullOrEmpty(LastName) Then _
        Throw New ArgumentException("LastName cannot be null or an empty string.")

      If Address    Is Nothing Then Address    = String.Empty 
      If City       Is Nothing Then City       = String.Empty 
      If Region     Is Nothing Then Region     = String.Empty 
      If PostalCode Is Nothing Then PostalCode = String.Empty 

      If original_Address    Is Nothing Then original_Address    = String.Empty 
      If original_City       Is Nothing Then original_City       = String.Empty 
      If original_Region     Is Nothing Then original_Region     = String.Empty 
      If original_PostalCode Is Nothing Then original_PostalCode = String.Empty 

      Dim sqlCmd As String = "UPDATE Employees " & _ 
                      "  SET FirstName = @FirstName, LastName = @LastName, " & _
                      "  Address = @Address, City = @City, Region = @Region, " & _
                      "  PostalCode = @PostalCode " * _
                      "  WHERE EmployeeID = @original_EmployeeID " & _
                      " AND LastName = @original_LastName AND FirstName = @original_FirstName " & _
                      " AND Address = @original_Address AND City = @original_City " & _
                      " AND Region = @original_Region AND PostalCode = @original_PostalCode"

      Dim conn As SqlConnection = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand    = New SqlCommand(sqlCmd, conn) 
 
      cmd.Parameters.Add("@FirstName",  SqlDbType.VarChar, 10).Value = FirstName
      cmd.Parameters.Add("@LastName",   SqlDbType.VarChar, 20).Value = LastName
      cmd.Parameters.Add("@Address",    SqlDbType.VarChar, 60).Value = Address
      cmd.Parameters.Add("@City",       SqlDbType.VarChar, 15).Value = City
      cmd.Parameters.Add("@Region",     SqlDbType.VarChar, 15).Value = Region
      cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = PostalCode
      cmd.Parameters.Add("@original_EmployeeID", SqlDbType.Int).Value = original_EmployeeID
      cmd.Parameters.Add("@original_FirstName",  SqlDbType.VarChar, 10).Value = original_FirstName
      cmd.Parameters.Add("@original_LastName",   SqlDbType.VarChar, 20).Value = original_LastName
      cmd.Parameters.Add("@original_Address",    SqlDbType.VarChar, 60).Value = original_Address
      cmd.Parameters.Add("@original_City",       SqlDbType.VarChar, 15).Value = original_City
      cmd.Parameters.Add("@original_Region",     SqlDbType.VarChar, 15).Value = original_Region
      cmd.Parameters.Add("@original_PostalCode", SqlDbType.VarChar, 10).Value = original_PostalCode

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
'</Snippet1>