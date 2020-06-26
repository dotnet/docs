Imports System.ComponentModel

Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Show1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            CType(New Show1Window(), Show1Window).ShowDialog()
        End Sub
        Private Sub Show2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            CType(New Show2Window(), Show2Window).ShowDialog()
        End Sub
        Private Sub Show3(ByVal sender As Object, ByVal e As RoutedEventArgs)
            CType(New Show3Window(), Show3Window).ShowDialog()
        End Sub
        Private Sub Show4(ByVal sender As Object, ByVal e As RoutedEventArgs)
            CType(New Show4Window(), Show4Window).ShowDialog()
        End Sub
        Private Sub Show5(ByVal sender As Object, ByVal e As RoutedEventArgs)
            CType(New Show5Window(), Show5Window).ShowDialog()
        End Sub
        Private Sub Show6(ByVal sender As Object, ByVal e As RoutedEventArgs)
            CType(New Show6Window(), Show6Window).ShowDialog()
        End Sub
    End Class
End Namespace