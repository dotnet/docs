Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace AdornersMiscCode
  ''' <summary>
  ''' Interaction logic for Window1.xaml
  ''' </summary>

  Partial Public Class Window1
	  Inherits Window
	Public Sub New()
	  InitializeComponent()
	End Sub

	Private myAdornerLayer As AdornerLayer

	Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
		myAdornerLayer = AdornerLayer.GetAdornerLayer(myTextBox)

		' <Snippet_RemoveSpecificAdornerLong>
		Dim toRemoveArray() As Adorner = myAdornerLayer.GetAdorners(myTextBox)
		Dim toRemove As Adorner
		If toRemoveArray IsNot Nothing Then
		  toRemove = toRemoveArray(0)
		  myAdornerLayer.Remove(toRemove)
		End If
		' </Snippet_RemoveSpecificAdornerLong>

		' <Snippet_RemoveSpecificAdornerShort>
		Try
			myAdornerLayer.Remove((myAdornerLayer.GetAdorners(myTextBox))(0))
		Catch
		End Try
		' </Snippet_RemoveSpecificAdornerShort>
		For Each toAdorn As UIElement In myStackPanel.Children
		  myAdornerLayer.Add(New SimpleCircleAdorner(toAdorn))
		Next toAdorn

		' <Snippet_RemoveAllAdornersLong>
            toRemoveArray = myAdornerLayer.GetAdorners(myTextBox)
		If toRemoveArray IsNot Nothing Then
		  For x As Integer = 0 To toRemoveArray.Length - 1
			myAdornerLayer.Remove(toRemoveArray(x))
		  Next x
		End If
		' </Snippet_RemoveAllAdornersLong>

		' <Snippet_RemoveAllAdornersShort>
		Try
                For Each toRemove In myAdornerLayer.GetAdorners(myTextBox)
                    myAdornerLayer.Remove(toRemove)
                Next toRemove
		Catch
		End Try
		' </Snippet_RemoveAllAdornersShort>
	End Sub

	' Sample event handler:  
	' private void ButtonClick(object sender, RoutedEventArgs e) {}

	' Adorners must subclass the abstract base class Adorner.
	Public Class SimpleCircleAdorner
		Inherits Adorner
	  ' Be sure to call the base class constructor.
	  Public Sub New(ByVal adornedElement As UIElement)
		  MyBase.New(adornedElement)
		' Any constructor implementation...
	  End Sub

	  ' A common way to implement an adorner's rendering behavior is to override the OnRender
	  ' method, which is called by the layout subsystem as part of a rendering pass.
'<SnippetUIElementDesiredSize>
	  Protected Overrides Sub OnRender(ByVal drawingContext As DrawingContext)
		' Get a rectangle that represents the desired size of the rendered element
		' after the rendering pass.  This will be used to draw at the corners of the 
		' adorned element.
		Dim adornedElementRect As New Rect(Me.AdornedElement.RenderSize)

		' Some arbitrary drawing implements.
		Dim renderBrush As New SolidColorBrush(Colors.Green)
		renderBrush.Opacity = 0.2
		Dim renderPen As New Pen(New SolidColorBrush(Colors.Navy), 1.5)
		Dim renderRadius As Double = 5.0

		' Just draw a circle at each corner.
		drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius)
		drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius)
		drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius)
		drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius)
	  End Sub
'</SnippetUIElementDesiredSize>
	End Class
  End Class
End Namespace