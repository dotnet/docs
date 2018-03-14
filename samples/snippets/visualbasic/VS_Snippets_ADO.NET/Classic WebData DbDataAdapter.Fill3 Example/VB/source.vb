Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected dataSet As DataSet
    Protected adapter As OleDbDataAdapter
    
' <Snippet1>
 Public Sub GetRecords()
     ' ...
     ' create dataSet and adapter
     ' ...
     adapter.Fill(dataSet, 9, 15, "Categories")
 End Sub
' </Snippet1>
End Class
