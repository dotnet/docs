Imports System ' EventArgs
Imports System.ComponentModel ' CancelEventArgs
Imports System.Windows ' window

Namespace VisualBasic
    Partial Public Class DataWindow
        Inherits Window
        ' Is data dirty
        Private isDataDirty As Boolean = False

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub documentTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.isDataDirty = True
        End Sub

        Private Sub DataWindow_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
            MessageBox.Show("Closing called")

            ' If data is dirty, notify user and ask for a response
            If Me.isDataDirty Then
                Dim msg As String = "Data is dirty. Close without saving?"
                Dim result As MessageBoxResult = MessageBox.Show(msg, "Data App", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                If result = MessageBoxResult.No Then
                    ' If user doesn't want to close, cancel closure
                    e.Cancel = True
                End If
            End If
        End Sub
    End Class
End Namespace
