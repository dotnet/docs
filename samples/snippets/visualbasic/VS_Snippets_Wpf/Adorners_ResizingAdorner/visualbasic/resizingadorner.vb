Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media

Namespace SDKSample

  Public Class ResizingAdorner
	  Inherits Adorner
	' Resizing adorner uses Thumbs for visual elements.  
	' The Thumbs have built-in mouse input handling.
	Private topLeft, topRight, bottomLeft, bottomRight As Thumb

'<SnippetFEVisualOverridesPre>
	' To store and manage the adorner's visual children.
	Private visualChildren As VisualCollection
'</SnippetFEVisualOverridesPre>

	' Initialize the ResizingAdorner.
	Public Sub New(ByVal adornedElement As UIElement)
		MyBase.New(adornedElement)
	  visualChildren = New VisualCollection(Me)

	  ' Call a helper method to initialize the Thumbs
	  ' with a customized cursors.
	  BuildAdornerCorner(topLeft, Cursors.SizeNWSE)
	  BuildAdornerCorner(topRight, Cursors.SizeNESW)
	  BuildAdornerCorner(bottomLeft, Cursors.SizeNESW)
	  BuildAdornerCorner(bottomRight, Cursors.SizeNWSE)

	  ' Add handlers for resizing.
	  AddHandler bottomLeft.DragDelta, AddressOf HandleBottomLeft
	  AddHandler bottomRight.DragDelta, AddressOf HandleBottomRight
	  AddHandler topLeft.DragDelta, AddressOf HandleTopLeft
	  AddHandler topRight.DragDelta, AddressOf HandleTopRight
	End Sub

	' Handler for resizing from the bottom-right.
	Private Sub HandleBottomRight(ByVal sender As Object, ByVal args As DragDeltaEventArgs)
	  Dim adornedElement As FrameworkElement = TryCast(Me.AdornedElement, FrameworkElement)
	  Dim hitThumb As Thumb = TryCast(sender, Thumb)

	  If adornedElement Is Nothing OrElse hitThumb Is Nothing Then
		  Return
	  End If
	  Dim parentElement As FrameworkElement = TryCast(adornedElement.Parent, FrameworkElement)

	  ' Ensure that the Width and Height are properly initialized after the resize.
	  EnforceSize(adornedElement)

	  ' Change the size by the amount the user drags the mouse, as long as it's larger 
	  ' than the width or height of an adorner, respectively.
	  adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width)
	  adornedElement.Height = Math.Max(args.VerticalChange + adornedElement.Height, hitThumb.DesiredSize.Height)
	End Sub

	' Handler for resizing from the bottom-left.
	Private Sub HandleBottomLeft(ByVal sender As Object, ByVal args As DragDeltaEventArgs)
	  Dim adornedElement As FrameworkElement = TryCast(Me.AdornedElement, FrameworkElement)
	  Dim hitThumb As Thumb = TryCast(sender, Thumb)

	  If adornedElement Is Nothing OrElse hitThumb Is Nothing Then
		  Return
	  End If

	  ' Ensure that the Width and Height are properly initialized after the resize.
	  EnforceSize(adornedElement)

	  ' Change the size by the amount the user drags the mouse, as long as it's larger 
	  ' than the width or height of an adorner, respectively.
	  adornedElement.Width = Math.Max(adornedElement.Width - args.HorizontalChange, hitThumb.DesiredSize.Width)
	  adornedElement.Height = Math.Max(args.VerticalChange + adornedElement.Height, hitThumb.DesiredSize.Height)
	End Sub

	' Handler for resizing from the top-right.
	Private Sub HandleTopRight(ByVal sender As Object, ByVal args As DragDeltaEventArgs)
	  Dim adornedElement As FrameworkElement = TryCast(Me.AdornedElement, FrameworkElement)
	  Dim hitThumb As Thumb = TryCast(sender, Thumb)

	  If adornedElement Is Nothing OrElse hitThumb Is Nothing Then
		  Return
	  End If
	  Dim parentElement As FrameworkElement = TryCast(adornedElement.Parent, FrameworkElement)

	  ' Ensure that the Width and Height are properly initialized after the resize.
	  EnforceSize(adornedElement)

	  ' Change the size by the amount the user drags the mouse, as long as it's larger 
	  ' than the width or height of an adorner, respectively.
	  adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width)
	  adornedElement.Height = Math.Max(adornedElement.Height - args.VerticalChange, hitThumb.DesiredSize.Height)
	End Sub

	' Handler for resizing from the top-left.
	Private Sub HandleTopLeft(ByVal sender As Object, ByVal args As DragDeltaEventArgs)
	  Dim adornedElement As FrameworkElement = TryCast(Me.AdornedElement, FrameworkElement)
	  Dim hitThumb As Thumb = TryCast(sender, Thumb)

	  If adornedElement Is Nothing OrElse hitThumb Is Nothing Then
		  Return
	  End If

	  ' Ensure that the Width and Height are properly initialized after the resize.
	  EnforceSize(adornedElement)

	  ' Change the size by the amount the user drags the mouse, as long as it's larger 
	  ' than the width or height of an adorner, respectively.
	  adornedElement.Width = Math.Max(adornedElement.Width - args.HorizontalChange, hitThumb.DesiredSize.Width)
	  adornedElement.Height = Math.Max(adornedElement.Height - args.VerticalChange, hitThumb.DesiredSize.Height)
	End Sub

	' Arrange the Adorners.
	Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
	  ' desiredWidth and desiredHeight are the width and height of the element that's being adorned.  
	  ' These will be used to place the ResizingAdorner at the corners of the adorned element.  
	  Dim desiredWidth As Double = AdornedElement.DesiredSize.Width
	  Dim desiredHeight As Double = AdornedElement.DesiredSize.Height
	  ' adornerWidth & adornerHeight are used for placement as well.
	  Dim adornerWidth As Double = Me.DesiredSize.Width
	  Dim adornerHeight As Double = Me.DesiredSize.Height

	  topLeft.Arrange(New Rect(-adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight))
	  topRight.Arrange(New Rect(desiredWidth - adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight))
	  bottomLeft.Arrange(New Rect(-adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight))
	  bottomRight.Arrange(New Rect(desiredWidth - adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight))

	  ' Return the final size.
	  Return finalSize
	End Function

	' Helper method to instantiate the corner Thumbs, set the Cursor property, 
	' set some appearance properties, and add the elements to the visual tree.
	Private Sub BuildAdornerCorner(ByRef cornerThumb As Thumb, ByVal customizedCursor As Cursor)
	  If cornerThumb IsNot Nothing Then
		  Return
	  End If

	  cornerThumb = New Thumb()

	  ' Set some arbitrary visual characteristics.
	  cornerThumb.Cursor = customizedCursor
	  cornerThumb.Width = 10
	  cornerThumb.Height = cornerThumb.Width
	  cornerThumb.Opacity = 0.40
	  cornerThumb.Background = New SolidColorBrush(Colors.MediumBlue)

	  visualChildren.Add(cornerThumb)
	End Sub

	' This method ensures that the Widths and Heights are initialized.  Sizing to content produces
	' Width and Height values of Double.NaN.  Because this Adorner explicitly resizes, the Width and Height
	' need to be set first.  It also sets the maximum size of the adorned element.
	Private Sub EnforceSize(ByVal adornedElement As FrameworkElement)
	  If adornedElement.Width.Equals(Double.NaN) Then
		adornedElement.Width = adornedElement.DesiredSize.Width
	  End If
	  If adornedElement.Height.Equals(Double.NaN) Then
		adornedElement.Height = adornedElement.DesiredSize.Height
	  End If

	  Dim parent As FrameworkElement = TryCast(adornedElement.Parent, FrameworkElement)
	  If parent IsNot Nothing Then
		adornedElement.MaxHeight = parent.ActualHeight
		adornedElement.MaxWidth = parent.ActualWidth
	  End If
	End Sub
'<SnippetFEVisualOverrides>
	' Override the VisualChildrenCount and GetVisualChild properties to interface with 
	' the adorner's visual collection.
	Protected Overrides ReadOnly Property VisualChildrenCount() As Integer
		Get
			Return visualChildren.Count
		End Get
	End Property
	Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual
		Return visualChildren(index)
	End Function
'</SnippetFEVisualOverrides>
  End Class
End Namespace
