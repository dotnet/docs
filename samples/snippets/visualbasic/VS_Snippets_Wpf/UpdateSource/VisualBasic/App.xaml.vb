﻿Public Class app
    Inherits Application

    ' Methods
    Private Sub AppStartingUp(ByVal sender As Object, ByVal args As StartupEventArgs)
        Dim window As New Window1
        window.Show()
    End Sub

End Class
