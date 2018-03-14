NotInheritable Class App
    Inherits Application

    Protected Overrides Sub OnLaunched(args As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
        Dim rootFrame As New Frame()
        rootFrame.Navigate(GetType(BlankPage))
        Window.Current.Content = rootFrame
        Window.Current.Activate()
    End Sub

End Class
