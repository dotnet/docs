Imports System.Text


Namespace VisualBasic
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>

    Partial Public Class Window1
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub messageBoxButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetMsgBoxConfigureCODEBEHIND>
            ' Configure the message box to be displayed
            Dim messageBoxText As String = "Do you want to save changes?"
            Dim caption As String = "Word Processor"
            Dim button As MessageBoxButton = MessageBoxButton.YesNoCancel
            Dim icon As MessageBoxImage = MessageBoxImage.Warning
            '</SnippetMsgBoxConfigureCODEBEHIND>

            '<SnippetMsgBoxShowCODEBEHIND>
            ' Display message box
            MessageBox.Show(messageBoxText, caption, button, icon)
            '</SnippetMsgBoxShowCODEBEHIND>

            '<SnippetMsgBoxShowAndResultCODEBEHIND1>
            ' Display message box
            Dim result As MessageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon)

            ' Process message box results
            Select Case result
                Case MessageBoxResult.Yes
                    ' User pressed Yes button
                    ' ...
                Case MessageBoxResult.No
                    ' User pressed No button
                    ' ...
                Case MessageBoxResult.Cancel
                    ' User pressed Cancel button
                    ' ...
            End Select
            '</SnippetMsgBoxShowAndResultCODEBEHIND1>
        End Sub

        Private Sub openFileDialog_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetOpenFileDialogBoxCODEBEHIND>
            ' Configure open file dialog box
            Dim dlg As New Microsoft.Win32.OpenFileDialog()
            dlg.FileName = "Document" ' Default file name
            dlg.DefaultExt = ".txt" ' Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt" ' Filter files by extension

            ' Show open file dialog box
            Dim result? As Boolean = dlg.ShowDialog()

            ' Process open file dialog box results
            If result = True Then
                ' Open document
                Dim filename As String = dlg.FileName
            End If
            '</SnippetOpenFileDialogBoxCODEBEHIND>
        End Sub

        Private Sub saveFileDialog_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetSaveFileDialogBoxCODEBEHIND>
            ' Configure save file dialog box
            Dim dlg As New Microsoft.Win32.SaveFileDialog()
            dlg.FileName = "Document" ' Default file name
            dlg.DefaultExt = ".text" ' Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt" ' Filter files by extension

            ' Show save file dialog box
            Dim result? As Boolean = dlg.ShowDialog()

            ' Process save file dialog box results
            If result = True Then
                ' Save document
                Dim filename As String = dlg.FileName
            End If
            '</SnippetSaveFileDialogBoxCODEBEHIND>
        End Sub

        Private Sub printDialog_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetPrintDialogBoxCODEBEHIND>
            ' Configure printer dialog box
            Dim dlg As New PrintDialog()
            dlg.PageRangeSelection = PageRangeSelection.AllPages
            dlg.UserPageRangeEnabled = True

            ' Show save file dialog box
            Dim result? As Boolean = dlg.ShowDialog()

            ' Process save file dialog box results
            If result = True Then
                ' Print document
            End If
            '</SnippetPrintDialogBoxCODEBEHIND>
        End Sub

        

    End Class
End Namespace