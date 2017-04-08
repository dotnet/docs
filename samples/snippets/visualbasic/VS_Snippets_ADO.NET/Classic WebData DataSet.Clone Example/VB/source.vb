imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub GetClone(ByVal dataSet As DataSet)
    ' Get a clone of the original DataSet.
    Dim cloneSet As DataSet = dataSet.Clone()

    ' Insert code to work with clone of the DataSet.
 End Sub
' </Snippet1>

End Class
