Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    
    
    ' <Snippet1>
    Public Sub CreateOracleParamColl(command As OracleCommand)
        Dim paramCollection As OracleParameterCollection = command.Parameters
        paramCollection.Add("pDName", OracleType.Varchar)
        paramCollection.Add("pLoc", OracleType.Varchar)
        Dim parameterNames As String = ""
        Dim i As Integer
        For i = 0 To paramCollection.Count - 1
            parameterNames &= paramCollection(i).ToString() & ControlChars.Cr
        Next i
        Console.WriteLine(parameterNames)
        paramCollection.Clear()
    End Sub 
    ' </Snippet1>
End Class 'Form1
