imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub PrintName(relation As DataRelation)
    ' Print the name of the DataRelation.
      Console.WriteLine(relation.ToString())
End Sub
' </Snippet1>

End Class
