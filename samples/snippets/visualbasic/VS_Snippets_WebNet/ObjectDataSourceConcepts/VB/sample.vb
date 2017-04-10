Imports System
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.Controls

'<Snippet10>
  <DataObject(True)> _
  Public Class NorthwindEmployee 
'</Snippet10>

    Private Shared _connectionString As String
    Private Shared _initialized As Boolean = False

    Public Sub New()
      Initialize()
    End Sub


'<Snippet5>
    Public Shared Sub Initialize()    
      ' Initialize data source. Use "Northwind" connection string from configuration.

      If ConfigurationManager.ConnectionStrings("Northwind") Is Nothing OrElse _
         ConfigurationManager.ConnectionStrings("Northwind").ConnectionString.Trim() = "" Then      
        Throw New Exception("A connection string named 'Northwind' with a valid connection string " & _
                            "must exist in the <connectionStrings> configuration section for the application.")
      End If

      _connectionString = _
        ConfigurationManager.ConnectionStrings("Northwind").ConnectionString

      _initialized = True
    End Sub



    ' Select all employees.

    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    Public Shared Function GetAllEmployees(sortColumns As String, startRecord As Integer, maxRecords As Integer) As DataTable
    
      VerifySortColumns(sortColumns)

      If Not _initialized Then Initialize()

      Dim sqlCommand As String = "SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode FROM Employees "

      If sortColumns.Trim() = "" Then
        sqlCommand &= "ORDER BY EmployeeID"
      Else
        sqlCommand &= "ORDER BY " & sortColumns
      End If

      Dim conn As SqlConnection  = New SqlConnection(_connectionString)
      Dim da   As SqlDataAdapter = New SqlDataAdapter(sqlCommand, conn) 

      Dim ds As DataSet =  New DataSet() 

      Try
        conn.Open()
        da.Fill(ds, startRecord, maxRecords, "Employees")
      Catch e As SqlException
        ' Handle exception.
      Finally      
        conn.Close()
      End Try

      If ds.Tables("Employees") IsNot Nothing Then _
        Return ds.Tables("Employees")

      Return Nothing
    End Function


    '''''
    ' Verify that only valid columns are specified in the sort expression to aSub a SQL Injection attack.

    Private Shared Sub VerifySortColumns(sortColumns As String)
    
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
'</Snippet5>


    ' Select an employee.
'<Snippet6>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetEmployee(EmployeeID As Integer) As DataTable
    
      If Not _initialized Then Initialize()

      Dim conn As SqlConnection  = New SqlConnection(_connectionString)
      Dim da  As SqlDataAdapter  = _
        New SqlDataAdapter("SELECT EmployeeID, LastName, FirstName, Address, City, Region, PostalCode FROM Employees WHERE EmployeeID = @EmployeeID", conn) 
      da.SelectCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID

      Dim ds As DataSet =  New DataSet() 

      Try      
        conn.Open()
        da.Fill(ds, "Employees")
      Catch e As SqlException
        ' Handle exception.
      Finally
        conn.Close()
      End Try

      If ds.Tables("Employees") IsNot Nothing Then _
        Return ds.Tables("Employees")

      Return Nothing
    End Function
'</Snippet6>    


    ' Delete the Employee by ID.
'<Snippet7>
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function DeleteEmployee(EmployeeID As Integer) As Boolean
    
      If Not _initialized Then Initialize()

      Dim conn As SqlConnection  = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand     = New SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", conn)  
      cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID

      Try
        conn.Open()

        If cmd.ExecuteNonQuery() <> 0 Then _
          Return False
      Catch e As SqlException
        ' Handle exception.
      Finally
        conn.Close()
      End Try

      Return True
    End Function
'</Snippet7>


    ' Update the Employee by original ID.
'<Snippet8>
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function UpdateEmployee(EmployeeID As Integer, _
                                          FirstName As String, _
                                          LastName As String, _
                                          Address As String, _
                                          City As String, _
                                          Region As String, _
                                          PostalCode As String) As Boolean
    
      If String.IsNullOrEmpty(FirstName) Then _
        Throw New ArgumentException("FirstName cannot be null or an empty string.")
      If String.IsNullOrEmpty(LastName) Then _
        Throw New ArgumentException("LastName cannot be null or an empty string.")

      If Address    Is Nothing Then Address    = String.Empty 
      If City       Is Nothing Then City       = String.Empty 
      If Region     Is Nothing Then Region     = String.Empty 
      If PostalCode Is Nothing Then PostalCode = String.Empty 

      If Not _initialized Then Initialize()

      Dim conn As SqlConnection  = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand     = New SqlCommand("UPDATE Employees " & _
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

      Try      
        conn.Open()

        If cmd.ExecuteNonQuery() <> 0 Then _
          Return False
      Catch e As SqlException
        ' Handle exception.
      Finally
        conn.Close()
      End Try

      Return True
    End Function
'</Snippet8>


    ' Insert an Employee.
'<Snippet9>
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function InsertEmployee(ByRef NewEmployeeID As Integer, _
                                          FirstName As String, _
                                          LastName As String, _
                                          Address As String, _
                                          City As String, _
                                          Region As String, _
                                          PostalCode As String) As Boolean
    
      If String.IsNullOrEmpty(FirstName) Then _
        Throw New ArgumentException("FirstName cannot be null or an empty string.")
      If String.IsNullOrEmpty(LastName) Then _
        Throw New ArgumentException("LastName cannot be null or an empty string.")

      If Address    Is Nothing Then Address    = String.Empty 
      If City       Is Nothing Then City       = String.Empty 
      If Region     Is Nothing Then Region     = String.Empty 
      If PostalCode Is Nothing Then PostalCode = String.Empty 

      If Not _initialized Then Initialize()

      NewEmployeeID = -1

      Dim conn As SqlConnection  = New SqlConnection(_connectionString)
      Dim cmd  As SqlCommand     = New SqlCommand("INSERT INTO Employees " & _ 
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

      Try
        conn.Open()

        cmd.ExecuteNonQuery()

        NewEmployeeID = CInt(p.Value)
      Catch e As SqlException
        ' Handle exception.
      Finally
        conn.Close()
      End Try

      Return True
    End Function
'</Snippet9>

  End Class
End Namespace
