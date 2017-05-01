Imports System
Imports System.Data

Public Class Sample

' <Snippet1>
 Public Shared Sub ClearConstraints(dataSet As DataSet) 
    Dim table As DataTable
    For Each table In dataSet.Tables
      table.Constraints.Clear()
    Next
 End Sub
' </Snippet1>
End Class

