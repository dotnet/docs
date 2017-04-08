'This is a list of commonly used namespaces for a pane.

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Shapes
Imports System.Windows.Media

Namespace SDKSample
	''' <summary>
	''' Interaction logic for Pane1.xaml
	''' </summary>

	Partial Public Class Pane1
		Inherits Window

		Private Sub OnLoad(ByVal sender As Object, ByVal e As RoutedEventArgs)
		   'Create polygon with tooltip to add to shapes collection
			Dim myPolygon As New Polygon()
			myPolygon.Fill = Brushes.Gray
			Dim Point1 As New Point(0, 30)
			Dim Point2 As New Point(40, 50)
			Dim Point3 As New Point(50, 70)
			Dim myPointCollection As New PointCollection()
			myPointCollection.Add(Point1)
			myPointCollection.Add(Point2)
			myPointCollection.Add(Point3)
			myPolygon.Points = myPointCollection
			myPolygon.Margin = New Thickness(10, 0, 0, 0)

			'create ToolTip for myPolygon
			Dim aToolTip As New ToolTip()
			Dim newtb As New TextBlock()
			newtb.Text = "Polygon"
			aToolTip.Content = newtb
			'<SnippetCustomPopupPlacementCallback>
			aToolTip.Placement = PlacementMode.Custom
			aToolTip.CustomPopupPlacementCallback = New CustomPopupPlacementCallback(AddressOf placeToolTip)
			'</SnippetCustomPopupPlacementCallback>
			myPolygon.ToolTip = aToolTip
			'Add myPolygon to row of other shapes
			myStackPanel.Children.Add(myPolygon)

		End Sub

		'<SnippetDelegateInstance>
		Public Function placeToolTip(ByVal popupSize As Size, ByVal targetSize As Size, ByVal offset As Point) As CustomPopupPlacement()
			Dim placement1 As New CustomPopupPlacement(New Point(-50, 100), PopupPrimaryAxis.Vertical)

			Dim placement2 As New CustomPopupPlacement(New Point(10, 20), PopupPrimaryAxis.Horizontal)

			Dim ttplaces() As CustomPopupPlacement = { placement1, placement2 }
			Return ttplaces
		End Function
		'</SnippetDelegateInstance>
	End Class
End Namespace