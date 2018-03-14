Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace VisualBasic
    '<SnippetGetPageNavigationServiceCODEBEHIND>
    Partial Public Class HomePage
        Inherits Page
        Public Sub New()
            InitializeComponent()

            ' Don't allow back navigation if no navigation service
            If Me.NavigationService IsNot Nothing Then
                Me.goBackButton.IsEnabled = False
            End If
        End Sub

        Private Sub goBackButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Go to previous entry in journal back stack
            If Me.NavigationService.CanGoBack Then
                Me.NavigationService.GoBack()
            End If
        End Sub
    End Class
    '</SnippetGetPageNavigationServiceCODEBEHIND>
End Namespace