Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    
    
    ' <Snippet1>
    Public Sub CreateOracleParamColl(connection As OracleConnection)
      Dim command As OracleCommand = New OracleCommand( _
        "SELECT Ename, DeptNo FROM Emp WHERE EmpNo = :pEmpNo", connection)
      Dim paramCollection As OracleParameterCollection = command.Parameters
      Dim parameter As Object = New OracleParameter("pEmpNo", OracleType.Number)
      Dim pIndex As Integer = paramCollection.Add(parameter)
    End Sub 
    ' </Snippet1>
End Class 'Form1 
