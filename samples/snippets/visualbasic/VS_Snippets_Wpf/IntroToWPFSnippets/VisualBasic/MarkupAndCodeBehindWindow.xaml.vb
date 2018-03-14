'<SnippetMarkupAndCodeBehindWindowCODEBEHIND>
imports System.Windows ' Window, RoutedEventArgs, MessageBox

Namespace SDKSample

    Public Class MarkupAndCodeBehindWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            'Register event handler with button Click event
            AddHandler Me.button.Click, New RoutedEventHandler(AddressOf Me.button_Click)

        End Sub

        Private Sub button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MessageBox.Show("Hello, Windows Presentation Foundation!")
        End Sub

    End Class

End Namespace
'</SnippetMarkupAndCodeBehindWindowCODEBEHIND>