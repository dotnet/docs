Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Input

Namespace WindowDragMoveSnippets
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetCallWindowDragMoveCODEBEHIND>
        Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)
            MyBase.OnMouseLeftButtonDown(e)

            ' Begin dragging the window
            Me.DragMove()
        End Sub
        '</SnippetCallWindowDragMoveCODEBEHIND>

    End Class
End Namespace