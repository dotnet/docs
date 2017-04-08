'This is a list of commonly used namespaces for a pane.

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Threading

Namespace TabControlEx
	''' <summary>
	''' Interaction logic for Pane1.xaml
	''' </summary>

		Partial Public Class Pane1
			Inherits StackPanel


		Private Sub MyMenuHandler2(ByVal sender As Object, ByVal e As RoutedEventArgs)
		'<SnippetFromItemContainer>
		Dim cm As ContextMenu = CType(ContextMenu.ItemsControlFromItemContainer (CType(e.OriginalSource, MenuItem)), ContextMenu)
		Dim placementTarget As UIElement = cm.PlacementTarget
		'</SnippetFromItemContainer>
            If e.Source Is red Then
                backgroundcolor.Background = Brushes.Red
                backgroundcolor.Header = "Background red"
                backgroundcolor.Content = " "
                backgroundcolor.Content = "Some content about background."
            ElseIf e.Source Is blue Then
                backgroundcolor.Background = Brushes.LightBlue
                backgroundcolor.Header = "Background blue"
                backgroundcolor.Content = " "
                backgroundcolor.Content = "Some content about background."
            ElseIf e.Source Is yellow Then
                backgroundcolor.Background = Brushes.Yellow
                backgroundcolor.Header = "Background yellow"
                backgroundcolor.Content = " "
                backgroundcolor.Content = "Some content about background."
            End If

		End Sub


		 Private Sub MyMenuHandler3(ByVal sender As Object, ByVal e As RoutedEventArgs)
			 Dim cm As ContextMenu = CType(ContextMenu.ItemsControlFromItemContainer(CType(e.OriginalSource, MenuItem)), ContextMenu)
			 Dim placementTarget As UIElement = cm.PlacementTarget
            If e.Source Is green Then
                foregroundcolor.Foreground = Brushes.Green
                foregroundcolor.Header = "Foreground green"
            ElseIf e.Source Is purple Then
                foregroundcolor.Foreground = Brushes.Purple
                foregroundcolor.Header = "Foreground purple"
            ElseIf e.Source Is crimson Then
                foregroundcolor.Foreground = Brushes.Crimson
                foregroundcolor.Header = "Foreground crimson"
            End If
			 foregroundcolor.Content = "Some content about foreground."
		 End Sub

		Private Sub MyMenuHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim cm As ContextMenu = CType(ContextMenu.ItemsControlFromItemContainer(CType(e.OriginalSource, MenuItem)), ContextMenu)
			Dim placementTarget As UIElement = cm.PlacementTarget
            If e.Source Is sixteen Then
                fontsize.FontSize = 16
                fontsize.Header = "Font Size 16"
            ElseIf e.Source Is twenty Then
                fontsize.FontSize = 20
                fontsize.Header = "Font Size 20"
            ElseIf e.Source Is twentyfour Then
                fontsize.FontSize = 24
                fontsize.Header = "Font Size 24"
            End If
		   fontsize.Content = "Some content about font size."
		End Sub
		End Class
End Namespace