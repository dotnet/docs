Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Shapes

Namespace WCSamples
    ' Interaction logic for Window1.xaml
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
        '<SnippetMouseMovePointerGetPosition>
        ' raised when the mouse pointer moves.
        ' Expands the dimensions of an Ellipse when the mouse moves.
        Private Sub OnMouseMoveHandler(ByVal sender As Object, ByVal e As MouseEventArgs)

            'Get the x and y coordinates of the mouse pointer.
            Dim position As System.Windows.Point
            position = e.GetPosition(Me)
            Dim pX As Double
            pX = position.X
            Dim pY As Double
            pY = position.Y

            'Set the Height and Width of the Ellipse to the mouse coordinates.
            ellipse1.Height = pY
            ellipse1.Width = pX
        End Sub
        '</SnippetMouseMovePointerGetPosition>
    End Class
End Namespace

