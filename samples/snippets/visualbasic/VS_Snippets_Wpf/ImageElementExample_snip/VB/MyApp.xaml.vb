﻿
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Navigation
Imports System.Data
Imports System.Xml
Imports System.Configuration


Namespace ImageElementExample
    '/ <summary>
    '/ Interaction logic for MyApp.xaml
    '/ </summary>

    Partial Class MyApp
        Inherits Application

        Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
            Dim mainWindow As New SampleViewer()
            mainWindow.Show()

        End Sub
    End Class
End Namespace