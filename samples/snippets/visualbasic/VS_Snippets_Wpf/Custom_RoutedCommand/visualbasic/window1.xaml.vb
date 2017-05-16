Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Input


Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		' The custom command.
		' Note, the command binding is done in XAML.
		'<SnippetCustom_RoutedCommandDefinition>
		Public Shared ColorCmd As New RoutedCommand()
		'</SnippetCustom_RoutedCommandDefinition>


		Public Sub New()
			InitializeComponent()
		End Sub

		'<SnippetCustom_RoutedCommandHandlers>
		' ExecutedRoutedEventHandler for the custom color command.
		Private Sub ColorCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Dim target As Panel = TryCast(e.Source, Panel)
			If target IsNot Nothing Then
				If target.Background Is Brushes.AliceBlue Then
					target.Background = Brushes.LemonChiffon
				Else
					target.Background = Brushes.AliceBlue
				End If

			End If
		End Sub

		' CanExecuteRoutedEventHandler for the custom color command.
		Private Sub ColorCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			If TypeOf e.Source Is Panel Then
				e.CanExecute = True
			Else
				e.CanExecute = False
			End If
		End Sub
		'</SnippetCustom_RoutedCommandHandlers>



	End Class
End Namespace