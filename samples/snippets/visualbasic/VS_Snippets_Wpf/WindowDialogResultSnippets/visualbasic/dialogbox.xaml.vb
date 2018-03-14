'<SnippetWindowDialogResultCODEBEHIND>

Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class DialogBox
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        ' The accept button is a button whose IsDefault property is set to true.
        ' This event is raised whenever this button is clicked, or the ENTER key
        ' is pressed.
        Private Sub acceptButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Accept the dialog and return the dialog result
            Me.DialogResult = True
        End Sub
    End Class
End Namespace
'</SnippetWindowDialogResultCODEBEHIND>