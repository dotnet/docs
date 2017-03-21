Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Input

' Interaction logic for Window1.xaml
Namespace WCSamples
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
        '<SnippetCommandHandlerBothHandlers>

        '<SnippetCommandHandlerExecutedHandler>
        Private Sub OpenCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
            Dim command, targetobj As String
            command = CType(e.Command, RoutedCommand).Name
            targetobj = CType(sender, FrameworkElement).Name
            MessageBox.Show("The " + command + " command has been invoked on target object " + targetobj)
        End Sub
        '</SnippetCommandHandlerExecutedHandler>
        '<SnippetCommandHandlerCanExecuteHandler>
        Private Sub OpenCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
            e.CanExecute = True
        End Sub
        '</SnippetCommandHandlerCanExecuteHandler>

        '</SnippetCommandHandlerBothHandlers>

    End Class
End Namespace

