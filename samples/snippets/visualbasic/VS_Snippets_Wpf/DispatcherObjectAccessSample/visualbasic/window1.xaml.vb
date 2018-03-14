Imports System.Threading
Imports System.Windows.Threading



Namespace SDKSamples
	Partial Public Class Window1
		Inherits Window
		' Delegate used to place a work item onto the Dispatcher.
		Private Delegate Sub UpdateUIDelegate(ByVal button As Button)

		Public Sub New()
			InitializeComponent()

			' Get the id of the UI thread for display purposes.
			_uiThreadID = Me.Dispatcher.Thread.ManagedThreadId
			lblUIThreadID.Content = _uiThreadID
		End Sub

		'<SnippetDispatcherObjectAccessCheckAccess>
		' Uses the DispatcherObject.CheckAccess method to determine if 
		' the calling thread has access to the thread the UI object is on
		Private Sub TryToUpdateButtonCheckAccess(ByVal uiObject As Object)
			Dim theButton As Button = TryCast(uiObject, Button)

			If theButton IsNot Nothing Then
				' Checking if this thread has access to the object
				If theButton.CheckAccess() Then
					' This thread has access so it can update the UI thread
					UpdateButtonUI(theButton)
				Else
					' This thread does not have access to the UI thread
					' Pushing update method on the Dispatcher of the UI thread
					theButton.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New UpdateUIDelegate(AddressOf UpdateButtonUI), theButton)
				End If
			End If
		End Sub
		'</SnippetDispatcherObjectAccessCheckAccess>


		' Uses the DispatcherObject.VerifyAccess method to determine if 
		' the calling thread has access to the thread the UI object is on.
		Private Sub TryToUpdateButtonVerifyAccess(ByVal uiObject As Object)
			Dim theButton As Button = TryCast(uiObject, Button)

			If theButton IsNot Nothing Then
				Try
					'<SnippetDispatcherObjectAccessVerifyAccess>
					' Check if this thread has access to this object.
					theButton.VerifyAccess()

					' Thread has access to the object, so update the UI.
					UpdateButtonUI(theButton)
					'</SnippetDispatcherObjectAccessVerifyAccess>

				' Cannot access objects on the thread.
				Catch e As InvalidOperationException
					' Exception error meessage.
					MessageBox.Show("Exception ToString: " & vbLf & vbLf & e.ToString(), "Execption Caught! Thrown During AccessVerify().")

					MessageBox.Show("Pushing job onto UI Thread Dispatcher")

					' Placing job onto the Dispatcher of the UI Thread.
					theButton.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New UpdateUIDelegate(AddressOf UpdateButtonUI), theButton)
				End Try
			End If
		End Sub


		Private Sub threadStartingCheckAccess()
			' Try to update a Button created on the UI thread.
			TryToUpdateButtonCheckAccess(ButtonOnUIThread)
		End Sub

		Private Sub threadStartingVerifyAccess()
			' Try to update a Button created on the UI thread.
			TryToUpdateButtonVerifyAccess(ButtonOnUIThread)
		End Sub

		Private Sub CreateThread(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim threadStartingPoint As ThreadStart

			' Determine which ThreadStart to use.
			If rbCheckAccess.IsChecked = True Then
				threadStartingPoint = New ThreadStart(AddressOf threadStartingCheckAccess)
			Else
				threadStartingPoint = New ThreadStart(AddressOf threadStartingVerifyAccess)
			End If

			' Create and start a new thread.
			Dim backgroundThread As New Thread(threadStartingPoint)
			backgroundThread.SetApartmentState(ApartmentState.STA)
			backgroundThread.Start()

			' Update thread information for display purposes.
			_backgroundThreadID = backgroundThread.ManagedThreadId
			lblBackgroundThreadID.Content = _backgroundThreadID.ToString()
		End Sub


		Private Sub UpdateButtonUI(ByVal theButton As Button)
			' Update the content of the button with the current time.
			theButton.Content = Date.Now.TimeOfDay
		End Sub

		Private _uiThreadID As Integer
		Private _backgroundThreadID As Integer
	End Class
End Namespace