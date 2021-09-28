﻿Imports System.Windows ' Window, MessageBox
Imports System.Windows.Input ' MouseButtonEventArgs

Namespace SDKSample

    Public Class EllipseEventHandlingWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub clickableEllipse_MouseUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            MessageBox.Show("You clicked the ellipse!")
        End Sub

    End Class

End Namespace