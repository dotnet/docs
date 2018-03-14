Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected dataGrid1 As DataGrid    
   Shared Sub Main
End Sub    

' <Snippet1>
Private Sub ClearAndAdd()
   Dim gts As GridTableStylesCollection = dataGrid1.TableStyles
   gts.Clear()
End Sub
' </Snippet1>
End Class
