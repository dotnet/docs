Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataSet As DataSet
    Protected adapter As OracleDataAdapter
    
    
    
    ' <Snippet1>
Public Sub AddOracleParameters()
    ' ...
    ' create dataSet and adapter
    ' ...
adapter.SelectCommand.Parameters.Add("pEName", OracleType.VarChar, 80).Value = "Smith"
adapter.SelectCommand.Parameters.Add("pEmpNo", OracleType.Int32).Value = 7369
adapter.Fill(dataSet)
End Sub 
    ' </Snippet1>
End Class 'Form1 
