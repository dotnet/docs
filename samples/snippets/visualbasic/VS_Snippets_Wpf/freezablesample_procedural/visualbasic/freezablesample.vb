'
'
'   This sample demonstrates the Freezable class.
'
'
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls

Namespace Microsoft.Samples.Animation.LocalAnimations

	' Displays the sample.
	Public Class MyApp
		Inherits Application


		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			CreateAndShowMainWindow()
		End Sub


		Private Sub CreateAndShowMainWindow()
			' Create the application's main window.
			Dim myWindow As New NavigationWindow()

			' Display the sample
			Dim myContent As Page = New FreezableExample()
			myWindow.Navigate(myContent)
			MainWindow = myWindow
			myWindow.Show()
		End Sub
	End Class


	Public Class FreezableExample
		Inherits Page

		Private myMainPanel As StackPanel

		Public Sub New()
		   Me.WindowTitle = "Freezable Example"


			myMainPanel = New StackPanel()
			UnFrozenExample()
			FrozenExample()
			CloneExample()
			exceptionExample()
			Me.Content = myMainPanel

		End Sub

		Private Sub UnFrozenExample()

			' <SnippetUnFrozenExampleShort>
			Dim myButton As New Button()
			Dim myBrush As New SolidColorBrush(Colors.Yellow)
			myButton.Background = myBrush


			' Changes the button's background to red.
			myBrush.Color = Colors.Red
			' </SnippetUnFrozenExampleShort>

			myMainPanel.Children.Add(myButton)
		End Sub

		Private Sub FrozenExample()
			' <SnippetFrozenExamplePart1>
			Dim myButton As New Button()
			Dim myBrush As New SolidColorBrush(Colors.Yellow)
			myButton.Background = myBrush
			' </SnippetFrozenExamplePart1>

			' <SnippetFrozenExamplePart2>
			If myBrush.CanFreeze Then
				' Makes the brush unmodifiable.
				myBrush.Freeze()
			End If
			' </SnippetFrozenExamplePart2>

			myMainPanel.Children.Add(myButton)
		End Sub

		Private Sub exceptionExample()

			' <SnippetExceptionExample>

			' <SnippetFreezeExample1>
			Dim myButton As New Button()
			Dim myBrush As New SolidColorBrush(Colors.Yellow)

			If myBrush.CanFreeze Then
				' Makes the brush unmodifiable.
				myBrush.Freeze()
			End If

			myButton.Background = myBrush
			' </SnippetFreezeExample1>

			Try

				' Throws an InvalidOperationException, because the brush is frozen.
				myBrush.Color = Colors.Red
			Catch ex As InvalidOperationException
				MessageBox.Show("Invalid operation: " & ex.ToString())
			End Try

			' </SnippetExceptionExample>

			myMainPanel.Children.Add(myButton)


		End Sub

		Private Sub checkIsFrozenExample()

			' <SnippetCheckIsFrozenExample>

			Dim myButton As New Button()
			Dim myBrush As New SolidColorBrush(Colors.Yellow)

			If myBrush.CanFreeze Then
				' Makes the brush unmodifiable.
				myBrush.Freeze()
			End If

			myButton.Background = myBrush


			If myBrush.IsFrozen Then ' Evaluates to true.
				' If the brush is frozen, create a clone and
				' modify the clone.
				Dim myBrushClone As SolidColorBrush = myBrush.Clone()
				myBrushClone.Color = Colors.Red
				myButton.Background = myBrushClone
			Else
				' If the brush is not frozen,
				' it can be modified directly.
				myBrush.Color = Colors.Red
			End If


			' </SnippetCheckIsFrozenExample>

			myMainPanel.Children.Add(myButton)


		End Sub




		Private Sub CloneExample()

			' <SnippetCloneExample>
			Dim myButton As New Button()
			Dim myBrush As New SolidColorBrush(Colors.Yellow)

			' Freezing a Freezable before it provides
			' performance improvements if you don't
			' intend on modifying it. 
			If myBrush.CanFreeze Then
				' Makes the brush unmodifiable.
				myBrush.Freeze()
			End If


			myButton.Background = myBrush

			' If you need to modify a frozen brush,
			' the Clone method can be used to
			' create a modifiable copy.
			Dim myBrushClone As SolidColorBrush = myBrush.Clone()

			' Changing myBrushClone does not change
			' the color of myButton, because its
			' background is still set by myBrush.
			myBrushClone.Color = Colors.Red

			' Replacing myBrush with myBrushClone
			' makes the button change to red.
			myButton.Background = myBrushClone
			' </SnippetCloneExample>



			myMainPanel.Children.Add(myButton)
		End Sub





	End Class

	' <SnippetCreateInstanceCoreExample>
	Public Class MyFreezable
		Inherits Freezable
		' Typical implementation of CreateInstanceCore
		Protected Overrides Function CreateInstanceCore() As Freezable

			Return New MyFreezable()
		End Function


		' ...
		' Other code for the MyFreezableClass.
		' ...


	End Class

	' </SnippetCreateInstanceCoreExample>    



	' Starts the application.
	Friend NotInheritable Class EntryClass
        <System.STAThread()>
        Shared Sub Main()
            Dim app As New MyApp()
            app.Run()
        End Sub
	End Class
End Namespace
