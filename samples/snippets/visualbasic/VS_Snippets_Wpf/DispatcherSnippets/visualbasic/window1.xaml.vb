Imports System.Text
Imports System.Threading
Imports System.Windows.Threading
Imports System.Timers
Imports System.Security.Permissions


Namespace DispatcherSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Private count As Integer = 0
		Private ticks As Integer = 0
        Private frame As New DispatcherFrame()

        Private timer As New System.Timers.Timer()
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnLoaded(ByVal sender As Object, ByVal e As EventArgs)
			txtDisplay.TextWrapping = TextWrapping.Wrap
			timer.Interval = 1000
			AddHandler timer.Elapsed, AddressOf timer_Elapsed
			timer.Enabled = True
		End Sub

		Private Sub timer_Elapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs)
			ticks += 1
			txtDisplay.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New DispatcherOperationCallback(AddressOf tickers), Nothing)

			If ticks > 20 Then
				frame.Continue = False
				timer.Enabled = False
			End If
		End Sub

		Public Function tickers(ByVal o As Object) As Object
			txtDisplay.Text &= " $tick$ "
			Return Nothing
		End Function

		Private Sub btn4(ByVal sender As Object, ByVal e As RoutedEventArgs)


		End Sub

		'<SnippetDispatcherDispatcherFrameDoEvents>
		<SecurityPermissionAttribute(SecurityAction.Demand, Flags := SecurityPermissionFlag.UnmanagedCode)>
		Public Sub DoEvents()
			Dim frame As New DispatcherFrame()
			Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, New DispatcherOperationCallback(AddressOf ExitFrame), frame)
			Dispatcher.PushFrame(frame)
		End Sub

		Public Function ExitFrame(ByVal f As Object) As Object
			CType(f, DispatcherFrame).Continue = False

			Return Nothing
		End Function
		'</SnippetDispatcherDispatcherFrameDoEvents>

		Private Sub DisableProcessing(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetDispatcherDisableProcessing>
			' The Dispose() method is called at the end of the using statement.
			' Calling Dispose on the DispatcherProcessingDisabled structure, 
			' which is returned from the call to DisableProcessing, will
			' re-enable Dispatcher processing.
			Using Dispatcher.DisableProcessing()
				' Do work while the dispatcher processing is disabled.
				Thread.Sleep(2000)
			End Using
			'</SnippetDispatcherDisableProcessing>
		End Sub

		Private Sub btnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			lblDisplay.Content = "Executing"
			DoEvents()
			Thread.Sleep(2000)

			lblDisplay.Content = "Finished"
		End Sub

		Private Sub btn3(ByVal sender As Object, ByVal e As RoutedEventArgs)
			lblDisplay.Content = "Stage_1"

			For x As Integer = 0 To 99
				Me.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New DispatcherOperationCallback(AddressOf DoWork), x)
			Next x
			DoEvents()
			Thread.Sleep(2000)

            lblDisplay.Content = lblDisplay.Content.ToString() & "  Statge_2"
		End Sub

		Public Function DoWork(ByVal para As Object) As Object
			If CInt(Fix(para)) Mod 10 = 0 Then
				txtDisplay.Text += vbLf
			End If
			txtDisplay.Text += (CInt(Fix(para))).ToString()

			Return Nothing
		End Function

		<SecurityPermissionAttribute(SecurityAction.Demand, Flags := SecurityPermissionFlag.UnmanagedCode)>
		Public Sub DoEvents2()
			Dim frame As New DispatcherFrame()

			Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Send, New DispatcherOperationCallback(AddressOf ExitFrames), frame)

			Dispatcher.PushFrame(frame)
		End Sub





		Public Sub UpdateLabel()
			txtDisplay.Text &= " *** "
		End Sub

		Public Function ExitFrames(ByVal f As Object) As Object
			count += 1

			Dim frame As DispatcherFrame = TryCast(f, DispatcherFrame)


			Thread.Sleep(2000)
			If count < 5 Then
				UpdateLabel()
			Else
			End If



			Return Nothing
		End Function
	End Class
End Namespace