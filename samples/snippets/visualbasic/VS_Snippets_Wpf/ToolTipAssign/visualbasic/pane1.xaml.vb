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
			'<SnippetSetPlacementTarget>
			'create the button that displays the tooltip
			Dim targetButton As New Button()
			targetButton.Content = "tooltip Placement Target"

			'create a button that owns the tooltip
			Dim tooltipOwner As New Button()
			tooltipOwner.Content = "tooltip owner"
			tooltipOwner.ToolTip = "The ToolTip"
			ToolTipService.SetPlacement(tooltipOwner,PlacementMode.Top)
			ToolTipService.SetPlacementTarget(tooltipOwner,targetButton)
			'</SnippetSetPlacementTarget>

			targetButton.Margin = New Thickness(0, 20, 0, 0)
			targetButton.Width = 150
			tooltipOwner.Margin = New Thickness(0, 20, 0, 0)
			tooltipOwner.Width = 150

			Stack11.Children.Add(targetButton)
			Stack11.Children.Add(tooltipOwner)
		End Sub

		Public Function placeToolTip(ByVal popupSize As Size, ByVal targetSize As Size, ByVal offset As Point) As CustomPopupPlacement()
			 Dim ttplaces() As CustomPopupPlacement = { New CustomPopupPlacement() }
			 ttplaces(0).Point = New Point(0,80)
			 ttplaces(0).PrimaryAxis = PopupPrimaryAxis.Horizontal
			 Return ttplaces
		End Function
	End Class
End Namespace