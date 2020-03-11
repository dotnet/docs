Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media

Namespace SDKSample
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>

    Partial Public Class TransparentObject
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnLoaded(ByVal sender As Object, ByVal e As EventArgs)
            Dim b As Border = myBorder
            Dim s As String = ""
        End Sub

        '<SnippetTransparentVisualSnippet3>
        Private Overloads Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            ' Retrieve the coordinate of the mouse position.
            Dim pt As Point = e.GetPosition(CType(sender, UIElement))

            ' Get the parent of the Border object, since it is also the parent of the other objects.
            Dim parent As DependencyObject = VisualTreeHelper.GetParent(CType(sender, DependencyObject))

            ' Set up a callback to receive the hit test result enumeration.
            VisualTreeHelper.HitTest((CType(parent, Visual)), Nothing, New HitTestResultCallback(AddressOf MyHitTestResult), New PointHitTestParameters(pt))
        End Sub

        ' Return the result of the hit test to the callback.
        Public Function MyHitTestResult(ByVal result As HitTestResult) As HitTestResultBehavior
            Dim visual As Visual = CType(result.VisualHit, Visual)

            ' Ignore the transparent Border object.
            If visual.GetType() Is GetType(Border) Then
                ' Set the behavior to return visuals at all z-order levels.
                Return HitTestResultBehavior.Continue
            End If

            ' Display the type value of the object hit.
            myTextBlock.Text = visual.GetType().ToString() & " clicked"

            ' Stop the hit test enumeration of the visual tree.
            Return HitTestResultBehavior.Stop
        End Function
        '</SnippetTransparentVisualSnippet3>
    End Class
End Namespace