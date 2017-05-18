'<SnippetButtonControlTemplateWindowCODEBEHIND>
Imports System.Windows

Namespace SDKSample

    Public Class ControlTemplateButtonWindow
        Inherits Window

        Public Sub New()

            InitializeComponent()

        End Sub

        Private Sub button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MessageBox.Show("Hello, Windows Presentation Foundation!")
        End Sub

    End Class

End Namespace
'</SnippetButtonControlTemplateWindowCODEBEHIND>