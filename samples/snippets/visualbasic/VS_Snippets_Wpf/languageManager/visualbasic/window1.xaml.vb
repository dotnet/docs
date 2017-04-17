Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports System.Globalization

Namespace languageManagerSample

	Partial Public Class Window1
		Inherits Window

		Private Sub changeLang(ByVal sender As Object, ByVal e As RoutedEventArgs)
				' <Snippet1>
				Me.Dispatcher.Thread.CurrentCulture.Name.ToString()
				InputLanguageManager.SetInputLanguage(myTextBox, CultureInfo.CreateSpecificCulture("fr"))
				tb2.Text = "Available Input Languages:"
				lb1.ItemsSource = InputLanguageManager.Current.AvailableInputLanguages
				tb3.Text = "Input Language of myTextBox is " & InputLanguageManager.GetInputLanguage(myTextBox).ToString()
				tb4.Text = "CurrentCulture is Set to " & Me.Dispatcher.Thread.CurrentCulture.Name.ToString()
				' </Snippet1>

				' <Snippet2>
				InputMethod.SetPreferredImeState(myTextBox, InputMethodState.On)
				InputMethod.Current.ImeSentenceMode = ImeSentenceModeValues.Automatic
				InputMethod.Current.HandwritingState = InputMethodState.On
				InputMethod.Current.SpeechMode = SpeechMode.Dictation
				Dim myInputScope As New InputScope()
				myInputScope.RegularExpression = "W|P|F"
				InputMethod.SetInputScope(myTextBox, myInputScope)
				tb6.Text = "Configuration UI Available?: " & InputMethod.Current.CanShowConfigurationUI.ToString()
				' </Snippet2>    
		End Sub

		Private Sub inputManager(ByVal sender As Object, ByVal e As RoutedEventArgs)
				' <Snippet3>
				InputLanguageManager.SetInputLanguage(tb1, CultureInfo.CreateSpecificCulture("fr"))
				tb1.Text = "Current Input Language is " & InputLanguageManager.Current.CurrentInputLanguage.ToString()
				' </Snippet3>
		End Sub

	End Class
End Namespace