Imports System.Windows.Shapes
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Media.Imaging
Imports System.Windows.Media
Imports System.Windows.Data
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
'<Snippet1cb>
Partial Public Class TransformExample
    Inherits Page
    Private Sub Enter(ByVal sender As Object, ByVal args As System.Windows.Input.MouseEventArgs)
        myScaleTransform.ScaleX = 2
        myScaleTransform.ScaleY = 2
    End Sub

    Private Sub Leave(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        myScaleTransform.ScaleX = 1
        myScaleTransform.ScaleY = 1
    End Sub
End Class
'</Snippet1cb>
