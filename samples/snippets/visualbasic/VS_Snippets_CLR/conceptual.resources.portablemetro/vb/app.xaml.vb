' The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

''' <summary>
''' Provides application-specific behavior to supplement the default Application class.
''' </summary>
NotInheritable Class App
    Inherits Application

    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used when the application is launched to open a specific file, to display
    ''' search results, and so forth.
    ''' </summary>
    ''' <param name="args">Details about the launch request and process.</param>
    Protected Overrides Sub OnLaunched(args As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
        If args.PreviousExecutionState = ApplicationExecutionState.Terminated Then
            ' TODO: Load state from previously suspended application
        End If

        ' Create a Frame to act navigation context and navigate to the first page
        Dim rootFrame As New Frame()
        rootFrame.Navigate(GetType(BlankPage))

        ' Place the frame in the current Window and ensure that it is active
        Window.Current.Content = rootFrame
        Window.Current.Activate()
    End Sub

    ''' <summary>
    ''' Invoked when application execution is being suspended.  Application state is saved
    ''' without knowing whether the application will be terminated or resumed with the contents
    ''' of memory still intact.
    ''' </summary>
    ''' <param name="sender">The source of the suspend request.</param>
    ''' <param name="e">Details about the suspend request.</param>
    Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        ' TODO: Save application state and stop any background activity
    End Sub

End Class
