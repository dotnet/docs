Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Namespace PopupSnips
  ''' <summary>
  ''' Interaction logic for Window1.xaml
  ''' </summary>

  Partial Public Class Window1
	  Inherits Window
	Public Sub New()
	  InitializeComponent()
	End Sub



	Private Sub PopupAdjust(ByVal sender As Object, ByVal e As EventArgs)
	  '<SnippetIsOpen>
		myPopupIsOpen.IsOpen = True
		'</SnippetIsOpen>

		'<SnippetPopupPosition>
            Dim myPopup As New Popup()
            With myPopup
                .PlacementTarget = myEllipse
                .PlacementRectangle = New Rect(0, 0, 30, 50)
                .VerticalOffset = 20
                .HorizontalOffset = 20
                .Placement = PlacementMode.Bottom
                .PopupAnimation = PopupAnimation.Fade
                .AllowsTransparency = True
            End With

            Dim popupText As New TextBlock()
            popupText.Background = Brushes.Beige
            popupText.FontSize = 12
            popupText.Width = 75
            popupText.TextWrapping = TextWrapping.Wrap
            myPopup.Child = popupText
            '</SnippetPopupPosition>

            '<SnippetChild>
            Dim myPopupWithText As New Popup()
            Dim textBlock As New TextBlock()
            textBlock.Text = "Popup Text"
            textBlock.Background = Brushes.Yellow
            myPopupWithText.Child = textBlock
            myStackPanel.Children.Add(myPopup)
            '</SnippetChild>

            Dim myPopupLengthConverter As New LengthConverter()
            '<SnippetAllowsTransparency>
            myPopup.AllowsTransparency = True
            '</SnippetAllowsTransparency>

            '<SnippetHorizontalVerticalOffset>
            myPopup.HorizontalOffset = CType(myPopupLengthConverter.ConvertFromString(".5cm"), Double)
            myPopup.VerticalOffset = CType(myPopupLengthConverter.ConvertFromString(".1cm"), Double)
            '</SnippetHorizontalVerticalOffset>

            '<SnippetHasDropShadow>
            Dim hasDropShadow As Boolean = myPopup.HasDropShadow
            '</SnippetHasDropShadow>

            Dim myTextBlock As New TextBlock()
            myTextBlock.Text = "Special TextBlock"
            myTextBlock.Background = Brushes.Orange
            myTextBlock.Height = 20

            Dim myTextBlockPopup As New Popup()
            Dim popupDescription As New TextBlock()
            popupDescription.Background = Brushes.Coral
            popupDescription.Text = "Special Popup Text"

            '<SnippetPlacement>
            myTextBlockPopup.PlacementTarget = myTextBlock
            myTextBlockPopup.PlacementRectangle = New Rect(0, 0, 30, 40)
            myTextBlockPopup.Placement = PlacementMode.Center
            myTextBlockPopup.Child = popupDescription
            myTextBlockPopup.IsOpen = True
            '</SnippetPlacement>

            '<SnippetAnimation>
            myTextBlockPopup.PopupAnimation = PopupAnimation.Fade
            '</SnippetAnimation>


            '<SnippetStaysOpen>
            myTextBlockPopup.StaysOpen = True
            '</SnippetStaysOpen>
            myStackPanel.Children.Add(myTextBlock)

	End Sub


	  '<SnippetClosed>
	  Private Sub PopupClosing(ByVal sender As Object, ByVal e As EventArgs)
		  'Code to execute when Popup closes
	  End Sub
	  '</SnippetClosed>

	  '<SnippetOpened>
	  Private Sub PopupOpening(ByVal sender As Object, ByVal e As EventArgs)
		  'Code to execute when Popup opens
	  End Sub
	  '</SnippetOpened>
  End Class
End Namespace