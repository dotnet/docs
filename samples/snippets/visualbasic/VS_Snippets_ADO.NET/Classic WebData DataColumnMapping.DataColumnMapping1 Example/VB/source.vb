Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form   
        
' <Snippet1>
 Public Sub CreateDataColumnMapping()
     Dim mapping As New DataColumnMapping( _
        "Description", "DataDescription")
 End Sub
' </Snippet1>
End Class

