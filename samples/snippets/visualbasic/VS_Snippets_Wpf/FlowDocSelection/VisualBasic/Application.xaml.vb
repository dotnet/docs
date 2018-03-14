Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

    Sub New()

        Dim win2 As New Window2()
        win2.Show()

        Dim win3 As New Window3()
        win3.Show()
    End Sub

End Class
