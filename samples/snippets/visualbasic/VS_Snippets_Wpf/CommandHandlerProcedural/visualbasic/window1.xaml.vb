Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media


Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

			' Creating the main panel
			Dim MainStackPanel As New StackPanel()
			Me.AddChild(MainStackPanel)

			'<SnippetCommandHandlerButtonCommandSource>
			' Button used to invoke the command
			Dim CommandButton As New Button()
			CommandButton.Command = ApplicationCommands.Open
			CommandButton.Content = "Open (KeyBindings: Ctrl-R, Ctrl-0)"
			MainStackPanel.Children.Add(CommandButton)
			'</SnippetCommandHandlerButtonCommandSource>

			'<SnippetCommandHandlerBindingInit>
			' Creating CommandBinding and attaching an Executed and CanExecute handler
			Dim OpenCmdBinding As New CommandBinding(ApplicationCommands.Open, AddressOf OpenCmdExecuted, AddressOf OpenCmdCanExecute)

			Me.CommandBindings.Add(OpenCmdBinding)
			'</SnippetCommandHandlerBindingInit>

			'<SnippetCommandHandlerKeyBindingCodeBehind>
			' Creating a KeyBinding between the Open command and Ctrl-R
			Dim OpenCmdKeyBinding As New KeyBinding(ApplicationCommands.Open, Key.R, ModifierKeys.Control)

			Me.InputBindings.Add(OpenCmdKeyBinding)
			'</SnippetCommandHandlerKeyBindingCodeBehind>






		End Sub

		'<SnippetCommandHandlerExecutedHandler>
		Private Sub OpenCmdExecuted(ByVal target As Object, ByVal e As ExecutedRoutedEventArgs)
			MessageBox.Show("The command has been invoked.")
		End Sub
		'</SnippetCommandHandlerExecutedHandler>

		'<SnippetCommandHandlerCanExecuteHandler>
		Private Sub OpenCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			e.CanExecute = True
		End Sub
		'</SnippetCommandHandlerCanExecuteHandler>

	End Class
End Namespace