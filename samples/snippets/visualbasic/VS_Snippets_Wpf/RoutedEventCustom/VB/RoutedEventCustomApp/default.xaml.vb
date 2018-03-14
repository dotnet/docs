Imports System
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Controls


Namespace SDKSample

    Partial Public Class RoutedEventCustomApp
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub TapHandler(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            MessageBox.Show("Tapped!")
        End Sub

    End Class

End Namespace
