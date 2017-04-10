Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
 Private Sub ClearTable(table As DataTable)
     Try
         table.Clear()
     Catch e As DataException
	 ' Process exception and return.
          Console.WriteLine("Exception of type {0} occurred.", _
            e.GetType().ToString())
     End Try
 End Sub
' </Snippet1>
End Class
