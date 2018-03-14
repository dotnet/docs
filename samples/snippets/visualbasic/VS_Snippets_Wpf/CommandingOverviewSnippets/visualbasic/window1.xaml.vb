Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Input
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Threading



Namespace SDKSamples
	Partial Public Class Window1
		Inherits Window
		'<SnippetCommandingOverviewCommandDefinition>
		Public Shared CustomRoutedCommand As New RoutedCommand()
		'</SnippetCommandingOverviewCommandDefinition>


		Public Sub New()
			InitializeComponent()

			'<SnippetCommandingOverviewKeyBinding>
			Dim OpenKeyGesture As New KeyGesture(Key.B, ModifierKeys.Control)

			Dim OpenCmdKeybinding As New KeyBinding(ApplicationCommands.Open, OpenKeyGesture)

			Me.InputBindings.Add(OpenCmdKeybinding)
			'</SnippetCommandingOverviewKeyBinding>

			'<SnippetCommandingOverviewKeyGestureOnCmd>
			Dim OpenCmdKeyGesture As New KeyGesture(Key.B, ModifierKeys.Control)

			ApplicationCommands.Open.InputGestures.Add(OpenCmdKeyGesture)
			'</SnippetCommandingOverviewKeyGestureOnCmd>

			'<SnippetCommandingOverviewCommandTargetCodeBehind> 
			' Creating the UI objects
			Dim mainStackPanel As New StackPanel()
			Dim pasteTextBox As New TextBox()
			Dim stackPanelMenu As New Menu()
			Dim pasteMenuItem As New MenuItem()

			' Adding objects to the panel and the menu
			stackPanelMenu.Items.Add(pasteMenuItem)
			mainStackPanel.Children.Add(stackPanelMenu)
			mainStackPanel.Children.Add(pasteTextBox)

			' Setting the command to the Paste command
			pasteMenuItem.Command = ApplicationCommands.Paste
			'</SnippetCommandingOverviewCommandTargetCodeBehind> 

			' Setting the command target to the TextBox
			pasteMenuItem.CommandTarget = pasteTextBox

			'<SnippetCommandingOverviewCustomCommandSourceCodeBehind>
			' create the ui
			Dim CustomCommandStackPanel As New StackPanel()
			Dim CustomCommandButton As New Button()
			CustomCommandStackPanel.Children.Add(CustomCommandButton)

			CustomCommandButton.Command = CustomRoutedCommand
			'</SnippetCommandingOverviewCustomCommandSourceCodeBehind>

			'<SnippetCommandingOverviewCustomCommandBindingCodeBehind>
			Dim customCommandBinding As New CommandBinding(CustomRoutedCommand, AddressOf ExecutedCustomCommand, AddressOf CanExecuteCustomCommand)

			' attach CommandBinding to root window
			Me.CommandBindings.Add(customCommandBinding)
			'</SnippetCommandingOverviewCustomCommandBindingCodeBehind>

			sp.Children.Add(mainStackPanel)
			pasteTextBox.Background = Brushes.Bisque

			sp.Children.Add(CustomCommandStackPanel)

			'<SnippetCommandingOverviewCmdSource>
			Dim cmdSourcePanel As New StackPanel()
			Dim cmdSourceContextMenu As New ContextMenu()
			Dim cmdSourceMenuItem As New MenuItem()

			' Add ContextMenu to the StackPanel.
			cmdSourcePanel.ContextMenu = cmdSourceContextMenu
			cmdSourcePanel.ContextMenu.Items.Add(cmdSourceMenuItem)

			' Associate Command with MenuItem.
			cmdSourceMenuItem.Command = ApplicationCommands.Properties
			'</SnippetCommandingOverviewCmdSource>

			cmdSourcePanel.Background = Brushes.Black
			cmdSourcePanel.Height = 100
			cmdSourcePanel.Width = 100
			mainStackPanel.Children.Add(cmdSourcePanel)

		End Sub



		Private Sub AddCommand(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' <SnippetCommandingOverviewCmdManagerAddHandlers>
			CommandManager.AddExecutedHandler(helpButton, AddressOf HelpCmdExecuted)
			CommandManager.AddCanExecuteHandler(helpButton, AddressOf HelpCmdCanExecute)
			' </SnippetCommandingOverviewCmdManagerAddHandlers>
		End Sub
		Private Sub RemoveCommand(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' <SnippetCommandingOverviewCmdManagerRemoveHandlers>
			CommandManager.RemoveExecutedHandler(helpButton, AddressOf HelpCmdExecuted)
			CommandManager.RemoveCanExecuteHandler(helpButton, AddressOf HelpCmdCanExecute)
			' </SnippetCommandingOverviewCmdManagerRemoveHandlers>
		End Sub

		' <SnippetCommandingOverviewCmdManagerExecutedHandler>
		Private Sub HelpCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			' OpenHelpFile opens the help file
			OpenHelpFile()
		End Sub
		' </SnippetCommandingOverviewCmdManagerExecutedHandler>

		' <SnippetCommandingOverviewCmdManagerCanExecuteHandler>
		Private Sub HelpCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			' HelpFilesExists() determines if the help file exists
			If HelpFileExists() = True Then
				e.CanExecute = True
			Else
				e.CanExecute = False
			End If
		End Sub
		' </SnippetCommandingOverviewCmdManagerCanExecuteHandler>

		Private Sub OpenHelpFile()
			MessageBox.Show("The Help File")
		End Sub

		Private Function HelpFileExists() As Boolean
			Return True
		End Function

		Private Sub MyExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			MessageBox.Show("Command Executed")
		End Sub

		'<SnippetCommandingOverviewExecuted> 
		Private Sub ExecutedCustomCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			MessageBox.Show("Custom Command Executed")
		End Sub
		'</SnippetCommandingOverviewExecuted> 

		'<SnippetCommandingOverviewCanExecute> 
		' CanExecuteRoutedEventHandler that only returns true if
		' the source is a control.
		Private Sub CanExecuteCustomCommand(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			Dim target As Control = TryCast(e.Source, Control)

			If target IsNot Nothing Then
				e.CanExecute = True
			Else
				e.CanExecute = False
			End If
		End Sub
		'</SnippetCommandingOverviewCanExecute> 


		'<SnippetCommandingOverviewMultipleCmdHander>
		Private Sub ExecutedDisplayCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Dim command As RoutedCommand = TryCast(e.Command, RoutedCommand)

			If command IsNot Nothing Then
				If command Is MediaCommands.Pause Then
					   MyPauseMethod()
				End If
				If command Is MediaCommands.Play Then
					   MyPlayMethod()
				End If
				If command Is MediaCommands.Stop Then
					   MyStopMethod()
				End If
			End If
		End Sub
		'</SnippetCommandingOverviewMultipleCmdHander>

		'<SnippetCommandingOverviewMultipleCanExecute>
		Private Sub CanExecuteDisplayCommand(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			Dim command As RoutedCommand = TryCast(e.Command, RoutedCommand)

			If command IsNot Nothing Then
				If command Is MediaCommands.Play Then
					If IsPlaying() = False Then
						e.CanExecute = True
					Else
						e.CanExecute = False
					End If
				End If

				If command Is MediaCommands.Stop Then
					If IsPlaying() = True Then
						e.CanExecute = True
					Else
						e.CanExecute = False
					End If
				End If
			End If
		End Sub
		'</SnippetCommandingOverviewMultipleCanExecute>


		Public Sub MyPlayMethod()
			MessageBox.Show("Play")
		End Sub
		Public Sub MyPauseMethod()
			MessageBox.Show("Pause")
		End Sub
		Public Sub MyStopMethod()
			MessageBox.Show("Stop")
		End Sub
		Public Function IsPlaying() As Boolean
			Return True
		End Function

		Public Sub CodeBehindSnippets()

			Dim pasteMenuItem As New MenuItem()
			pasteMenuItem.Command = ApplicationCommands.Paste

			'set the CommandTarget to the 
			pasteMenuItem.CommandTarget = mainTextBox

		End Sub

	End Class

	'***********************************************************************
	'**
	'** This snippets are for the Threading Article from the Architect
	'** After Beta2 I'll create a new sniphost sample for them.
	'**
	'***********************************************************************


	'<SnippetThreadingArticleWeatherComponent1>
	Public Class WeatherComponent
		Inherits Component
		'gets weather: Synchronous 
		Public Function GetWeather() As String
			Dim weather As String = ""

			'predict the weather

			Return weather
		End Function

		'get weather: Asynchronous 
		Public Sub GetWeatherAsync()
			'get the weather
		End Sub

		Public Event GetWeatherCompleted As GetWeatherCompletedEventHandler
	End Class

	Public Class GetWeatherCompletedEventArgs
		Inherits AsyncCompletedEventArgs
		Public Sub New(ByVal [error] As Exception, ByVal canceled As Boolean, ByVal userState As Object, ByVal weather As String)
			MyBase.New([error], canceled, userState)
			_weather = weather
		End Sub

		Public ReadOnly Property Weather() As String
			Get
				Return _weather
			End Get
		End Property
		Private _weather As String
	End Class

	Public Delegate Sub GetWeatherCompletedEventHandler(ByVal sender As Object, ByVal e As GetWeatherCompletedEventArgs)
	'</SnippetThreadingArticleWeatherComponent1>

	'<SnippetThreadingArticleWeatherComponent2>
	Public Class WeatherComponent2
		Inherits Component
		Public Function GetWeather() As String
			Return fetchWeatherFromServer()
		End Function

		Private requestingContext As DispatcherSynchronizationContext = Nothing

		Public Sub GetWeatherAsync()
			If requestingContext IsNot Nothing Then
				Throw New InvalidOperationException("This component can only handle 1 async request at a time")
			End If

			requestingContext = CType(DispatcherSynchronizationContext.Current, DispatcherSynchronizationContext)

			Dim fetcher As New NoArgDelegate(AddressOf Me.fetchWeatherFromServer)

			' Launch thread
			fetcher.BeginInvoke(Nothing, Nothing)
		End Sub

		Private Sub [RaiseEvent](ByVal e As GetWeatherCompletedEventArgs)
            RaiseEvent GetWeatherCompleted(Me, e)
		End Sub

		Private Function fetchWeatherFromServer() As String
			' do stuff
			Dim weather As String = ""

			Dim e As New GetWeatherCompletedEventArgs(Nothing, False, Nothing, weather)

			Dim callback As New SendOrPostCallback(AddressOf DoEvent)
			requestingContext.Post(callback, e)
			requestingContext = Nothing

			Return e.Weather
		End Function

		Private Sub DoEvent(ByVal e As Object)
			'do stuff
		End Sub

		Public Event GetWeatherCompleted As GetWeatherCompletedEventHandler
		Public Delegate Function NoArgDelegate() As String
	End Class
	'</SnippetThreadingArticleWeatherComponent2>
End Namespace