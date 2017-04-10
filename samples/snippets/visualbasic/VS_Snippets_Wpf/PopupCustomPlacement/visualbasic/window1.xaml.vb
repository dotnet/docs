Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Namespace SDKSample
  ''' <summary>
  ''' Interaction logic for Window1.xaml
  ''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()

			'<SnippetDelegateDefinition>
			popup1.CustomPopupPlacementCallback = New CustomPopupPlacementCallback(AddressOf placePopup)
			'</SnippetDelegateDefinition> 
		End Sub


		Private Sub onClick(ByVal sender As Object, ByVal args As RoutedEventArgs)
			popup1.IsOpen = Not popup1.IsOpen

		End Sub

		'<SnippetDelegateInstance>
		Public Function placePopup(ByVal popupSize As Size, ByVal targetSize As Size, ByVal offset As Point) As CustomPopupPlacement()
			Dim placement1 As New CustomPopupPlacement(New Point(-50, 100), PopupPrimaryAxis.Vertical)

			Dim placement2 As New CustomPopupPlacement(New Point(10, 20), PopupPrimaryAxis.Horizontal)

			Dim ttplaces() As CustomPopupPlacement = { placement1, placement2 }
			Return ttplaces
		End Function
		'</SnippetDelegateInstance>


	End Class

End Namespace