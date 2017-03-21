Imports System.Threading
Imports System.Windows.Threading



Namespace SDKSamples
	Partial Public Class Window1
		Inherits Window
		' Delegate used to push a worker itme onto the Dispatcher.
		Private Delegate Sub UpdateUIDelegate(ByVal button As Button)

		Public Sub New()
			InitializeComponent()

			' Get the ID of the UI thread for display purposes.
			_uiThreadID = Me.Dispatcher.Thread.ManagedThreadId
			lblUIThreadID.Content = _uiThreadID
		End Sub

		'<SnippetDispatcherAccessCheckAccess>
		' Uses the Dispatcher.CheckAccess method to determine if 
		' the calling thread has access to the thread the UI object is on.
		Private Sub TryToUpdateButtonCheckAccess(ByVal uiObject As Object)
			Dim theButton As Button = TryCast(uiObject, Button)

			If theButton IsNot Nothing Then
				' Checking if this thread has access to the object.
				If theButton.Dispatcher.CheckAccess() Then
					' This thread has access so it can update the UI thread.
					UpdateButtonUI(theButton)
				Else
					' This thread does not have access to the UI thread.
					' Place the update method on the Dispatcher of the UI thread.
					theButton.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New UpdateUIDelegate(AddressOf UpdateButtonUI), theButton)
				End If
			End If
		End Sub
		'</SnippetDispatcherAccessCheckAccess>

        '<SnippetDispatcherAccessVerifyAccess>
		' Uses the Dispatcher.VerifyAccess method to determine if 
		' the calling thread has access to the thread the UI object is on.
		Private Sub TryToUpdateButtonVerifyAccess(ByVal uiObject As Object)
			Dim theButton As Button = TryCast(uiObject, Button)

			If theButton IsNot Nothing Then
				Try
                    ' Check if this thread has access to this object.
                    theButton.Dispatcher.VerifyAccess()

                    ' The thread has access to the object, so update the UI.
                    UpdateButtonUI(theButton)

                    ' Cannot access objects on the thread.
                Catch e As InvalidOperationException
                    ' Exception Error Message.
                    MessageBox.Show("Exception ToString: " & vbLf & vbLf & e.ToString(), "Execption Caught! Thrown During AccessVerify().")

                    MessageBox.Show("Pushing job onto UI Thread Dispatcher")

                    ' Placing job onto the Dispatcher of the UI Thread.
                    theButton.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New UpdateUIDelegate(AddressOf UpdateButtonUI), theButton)
                End Try
			End If
        End Sub
        '</SnippetDispatcherAccessVerifyAccess>


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
			' Update the Button content with the current time.
			theButton.Content = Date.Now.TimeOfDay
		End Sub

		Private _uiThreadID As Integer
		Private _backgroundThreadID As Integer
	End Class
End Namespace