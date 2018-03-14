Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet

' <Snippet1>
 Public Sub CreateDataColumnMapping()
     Dim mapping As New DataColumnMapping()
     mapping.SourceColumn = "Description"
     mapping.DataSetColumn = "DataDescription"
 End Sub
' </Snippet1>
End Class
