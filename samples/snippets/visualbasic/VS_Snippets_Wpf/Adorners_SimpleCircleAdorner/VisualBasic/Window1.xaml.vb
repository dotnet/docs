Imports System     
Imports System.Windows     
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Media

Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1.xaml
    '@ </summary>

    Partial Public Class Window1
        Inherits Window

        Dim myAdornerLayer As System.Windows.Documents.AdornerLayer

        Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<Snippet_AdornSingleElement>
            myAdornerLayer = AdornerLayer.GetAdornerLayer(myTextBox)
            myAdornerLayer.Add(New SimpleCircleAdorner(myTextBox))
            '</Snippet_AdornSingleElement>

            '<Snippet_AdornChildren>
            For Each toAdorn As UIElement In myStackPanel.Children
                myAdornerLayer.Add(New SimpleCircleAdorner(toAdorn))
            Next

            '</Snippet_AdornChildren>
        End Sub



    End Class
    '<Snippet_SimpleCircleAdornerBody>
    Public Class SimpleCircleAdorner
        Inherits Adorner
        Sub New(ByVal adornedElement As UIElement)
            MyBase.New(adornedElement)
        End Sub

        Protected Overrides Sub OnRender(ByVal drawingContext As System.Windows.Media.DrawingContext)
            MyBase.OnRender(drawingContext)
            Dim adornedElementRect As New Rect(AdornedElement.DesiredSize)
            Dim renderBrush As New SolidColorBrush(Colors.Green)
            renderBrush.Opacity = 0.2
            Dim renderPen As New Pen(New SolidColorBrush(Colors.Navy), 1.5)
            Dim renderRadius As Double
            renderRadius = 5.0

            'Draw a circle at each corner.
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius)
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius)
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius)
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius)
        End Sub
    End Class
    '</Snippet_SimpleCircleAdornerBody>
End Namespace
