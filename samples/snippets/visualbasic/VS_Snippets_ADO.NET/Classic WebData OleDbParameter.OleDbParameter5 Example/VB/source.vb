Imports System.Data
Imports System.Data.OleDb

Public Class Sample

  Public Shared Sub Main()
    CreateOleDbParameter()
  End Sub

' <Snippet1>

 Public Shared Sub CreateOleDbParameter() 
    Dim myParameter As New OleDbParameter("Description", "Beverages")
 End Sub
' </Snippet1>
End Class

