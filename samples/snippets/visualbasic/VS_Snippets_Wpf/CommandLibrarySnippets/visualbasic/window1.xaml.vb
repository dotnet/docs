Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Input


Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()



		End Sub


		' <SnippetKeyGestureGetProperties>
		Private Sub CmdExecutedHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			' This method gets the KeyGestures Associated with a Command 
			' and displays the Key and ModifierKeys properties.

			Dim cmd As RoutedCommand = TryCast(e.Command, RoutedCommand)
			Dim modifierKey As ModifierKeys
			Dim key As Key

			For Each gesture As InputGesture In cmd.InputGestures
				key = (CType(gesture, KeyGesture)).Key
				modifierKey = (CType(gesture, KeyGesture)).Modifiers

				' Outputs the key and modifierKeys ToString to a TextBox
				txtResults.Text &= "The KeyGesture is: " & key.ToString() & "+" & modifierKey.ToString() & vbLf
			Next gesture
		End Sub
		' </SnippetKeyGestureGetProperties>

		Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)


			' <SnippetKeyBindingKeyGestureSetProperties>
			' Defining the KeyGesture.
			Dim FindCmdKeyGesture As New KeyGesture(Key.F, (ModifierKeys.Shift Or ModifierKeys.Alt))

			' Defining the KeyBinding.
			Dim FindKeyBinding As New KeyBinding(ApplicationCommands.Find, FindCmdKeyGesture)

			' Binding the KeyBinding to the Root Window.
			Me.InputBindings.Add(FindKeyBinding)
			' </SnippetKeyBindingKeyGestureSetProperties>

			' <SnippetKeyBindingWithNoModifier>
			Dim OpenCmdKeyGesture As New KeyGesture(Key.F12)
			Dim OpenKeyBinding As New KeyBinding(ApplicationCommands.Open, OpenCmdKeyGesture)

			Me.InputBindings.Add(OpenKeyBinding)
			' </SnippetKeyBindingWithNoModifier>

			' <SnippetKeyBindingWithKeyAndModifiers>
			Dim CloseCmdKeyGesture As New KeyGesture(Key.L, ModifierKeys.Alt)

			Dim CloseKeyBinding As New KeyBinding(ApplicationCommands.Close, CloseCmdKeyGesture)

			Me.InputBindings.Add(CloseKeyBinding)
			' </SnippetKeyBindingWithKeyAndModifiers>

			' <SnippetKeyBindingMultipleModifiers>
			Dim CopyKeyBinding As New KeyBinding(ApplicationCommands.Copy, Key.D, (ModifierKeys.Control Or ModifierKeys.Shift))

			Me.InputBindings.Add(CopyKeyBinding)
			' </SnippetKeyBindingMultipleModifiers>

			' <SnippetKeyBindingDefatulCtor>
			Dim RedoKeyBinding As New KeyBinding()
			RedoKeyBinding.Modifiers = ModifierKeys.Alt
			RedoKeyBinding.Key = Key.F
			RedoKeyBinding.Command = ApplicationCommands.Redo

			Me.InputBindings.Add(RedoKeyBinding)
			' </SnippetKeyBindingDefatulCtor>

			' <SnippetMouseBindingAddedToInputBinding>
			Dim OpenCmdMouseGesture As New MouseGesture()
			OpenCmdMouseGesture.MouseAction = MouseAction.WheelClick
			OpenCmdMouseGesture.Modifiers = ModifierKeys.Control

			Dim OpenCmdMouseBinding As New MouseBinding()
			OpenCmdMouseBinding.Gesture = OpenCmdMouseGesture
			OpenCmdMouseBinding.Command = ApplicationCommands.Open

			Me.InputBindings.Add(OpenCmdMouseBinding)
			' </SnippetMouseBindingAddedToInputBinding>

			' <SnippetMouseBindingAddedCommand>
			Dim PasteCmdMouseGesture As New MouseGesture(MouseAction.MiddleClick, ModifierKeys.Alt)

			ApplicationCommands.Paste.InputGestures.Add(PasteCmdMouseGesture)
			' </SnippetMouseBindingAddedCommand>

			Dim pasteBind As New KeyGesture(Key.V, ModifierKeys.Alt)
			ApplicationCommands.Paste.InputGestures.Add(pasteBind)

			' <SnippetInputBindingAddingComand>
			Dim HelpCmdKeyGesture As New KeyGesture(Key.H, ModifierKeys.Alt)

			Dim inputBinding As InputBinding
			inputBinding = New InputBinding(ApplicationCommands.Help, HelpCmdKeyGesture)

			Me.InputBindings.Add(inputBinding)
			' </SnippetInputBindingAddingComand>

			' <SnippetMouseBindingMouseAction> 
			Dim CutCmdMouseGesture As New MouseGesture(MouseAction.MiddleClick)

			Dim CutMouseBinding As New MouseBinding(ApplicationCommands.Cut, CutCmdMouseGesture)

			' RootWindow is an instance of Window.
			RootWindow.InputBindings.Add(CutMouseBinding)
			' </SnippetMouseBindingMouseAction> 

			' <SnippetMouseBindingGesture>
			Dim NewCmdMouseGesture As New MouseGesture()
			NewCmdMouseGesture.Modifiers = ModifierKeys.Alt
			NewCmdMouseGesture.MouseAction = MouseAction.MiddleClick

			Dim NewMouseBinding As New MouseBinding()
            NewMouseBinding.Command = ApplicationCommands.[New]
			NewMouseBinding.Gesture = NewCmdMouseGesture

			' RootWindow is an instance of Window. 
			RootWindow.InputBindings.Add(NewMouseBinding)
			' </SnippetMouseBindingGesture>
		End Sub


		Private Sub MyCommandExecute(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Dim srcCommand As RoutedUICommand = TryCast(e.Command, RoutedUICommand)
			txtGesture.Text = String.Empty
			txtGesture.FontWeight = FontWeights.Heavy
			txtGesture.Text &= "Command:  " & srcCommand.Name & vbLf
			txtGesture.Text &= "Owner Type:  " & srcCommand.OwnerType.ToString() & vbLf
			txtGesture.Text &= "Text :  " & srcCommand.Text & vbLf & vbLf & vbLf
			txtGesture.FontWeight = FontWeights.Normal
			If srcCommand IsNot Nothing Then
				txtGesture.Text &= "Number of Gestures: " & srcCommand.InputGestures.Count.ToString() & vbLf
				If srcCommand.InputGestures.Count = 0 Then
					txtGesture.Text += vbLf & "No Gestures"
				Else
					For Each gesture As InputGesture In srcCommand.InputGestures
						txtGesture.Text += vbLf & gesture.ToString() & vbLf

						Dim keyGesture As KeyGesture = TryCast(gesture, KeyGesture)
						If keyGesture IsNot Nothing Then
							txtGesture.Text &= "Key: " & keyGesture.Key.ToString() & vbLf
							txtGesture.Text &= "Modifers: " & keyGesture.Modifiers.ToString() & vbLf
						End If

						txtGesture.Text += vbLf

						Dim mouseGesture As MouseGesture = TryCast(gesture, MouseGesture)
						If mouseGesture IsNot Nothing Then
							txtGesture.Text &= "Mouse Action: " & mouseGesture.MouseAction.ToString() & vbLf
							txtGesture.Text &= "Modifers: " & mouseGesture.Modifiers.ToString() & vbLf
						End If
						If mouseGesture Is Nothing Then
							txtGesture.Text &= "No Mouse Gestures" & vbLf
						End If

					Next gesture
				End If


			End If

		End Sub

		' <SnippetKeyDownHandlerKeyGestureMatches>
		Private Overloads Sub OnKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
			Dim keyGesture As New KeyGesture(Key.B, ModifierKeys.Control)

			If keyGesture.Matches(Nothing, e) Then
				MessageBox.Show("Trapped Key Gesture")
			End If
		End Sub
		' </SnippetKeyDownHandlerKeyGestureMatches>

		' <SnippetKeyDownHandlerMouseGestureMatches>
		Private Overloads Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim mouseGesture As New MouseGesture(MouseAction.MiddleClick,ModifierKeys.Control)

			If mouseGesture.Matches(Nothing, e) Then
				MessageBox.Show("Trapped Mouse Gesture")
			End If
		End Sub
		' </SnippetKeyDownHandlerMouseGestureMatches>

		Private Sub MyCanExecuteCommand(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			e.CanExecute = True
		End Sub

		Private Sub cmdButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			txtGesture.Text = String.Empty
			txtGesture.Text &= "Windows Input Bindings " & vbLf
			For Each binding As InputBinding In Me.InputBindings
				Dim gesture As KeyGesture = TryCast(binding.Gesture, KeyGesture)
				If gesture IsNot Nothing Then
					txtGesture.Text += gesture.Key.ToString() & "   " & gesture.Modifiers.ToString() & "   " & (CType(binding.Command, RoutedCommand)).Name & vbLf
				End If

			Next binding

		End Sub

	End Class
End Namespace