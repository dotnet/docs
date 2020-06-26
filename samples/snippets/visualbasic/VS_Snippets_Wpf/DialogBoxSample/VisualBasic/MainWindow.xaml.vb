Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports Microsoft.Win32

Namespace SDKSample
    Public Class MainWindow
        Inherits Window
        
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub documentTextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
            Me.needsToBeSaved = True
        End Sub

        Private Sub editFindMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim dlg As New FindDialogBox(Me.documentTextBox)
            dlg.Owner = Me
            AddHandler dlg.TextFound, New TextFoundEventHandler(AddressOf Me.dlg_TextFound)
            dlg.Show()
        End Sub

        Private Sub fileExit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MyBase.Close()
        End Sub

        Private Sub fileOpen_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.OpenDocument()
        End Sub

        Private Sub filePrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.PrintDocument()
        End Sub

        Private Sub fileSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.SaveDocument()
        End Sub

        Private Sub formatFontMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim dlg As New FontDialogBox
            dlg.Owner = Me
            dlg.FontFamily = Me.documentTextBox.FontFamily
            dlg.FontSize = Me.documentTextBox.FontSize
            dlg.FontWeight = Me.documentTextBox.FontWeight
            dlg.FontStyle = Me.documentTextBox.FontStyle
            dlg.ShowDialog()
            Dim dialogResult As Nullable(Of Boolean) = dlg.DialogResult
            If (dialogResult.GetValueOrDefault AndAlso dialogResult.HasValue) Then
                Me.documentTextBox.FontFamily = dlg.FontFamily
                Me.documentTextBox.FontSize = dlg.FontSize
                Me.documentTextBox.FontWeight = dlg.FontWeight
                Me.documentTextBox.FontStyle = dlg.FontStyle
            End If
        End Sub

        Private Sub formatMarginsMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Instantiate the dialog box
            Dim dlg As New MarginsDialogBox

            ' Configure the dialog box
            dlg.Owner = Me
            dlg.DocumentMargin = Me.documentTextBox.Margin

            ' Open the dialog box modally 
            dlg.ShowDialog()

            ' Process data entered by user if dialog box is accepted
            If (dlg.DialogResult.GetValueOrDefault = True) Then
                Me.documentTextBox.Margin = dlg.DocumentMargin
            End If
        End Sub

        Private Sub mainWindow_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
            If Me.needsToBeSaved Then
                Dim msg As String = "This document needs to be saved. Click Yes to save and exit, No to exit without saving, or Cancel to not exit."
                Dim title As String = "Word Processor"
                Dim buttons As MessageBoxButton = MessageBoxButton.YesNoCancel
                Dim icon As MessageBoxImage = MessageBoxImage.Exclamation
                Select Case MessageBox.Show(msg, title, buttons, icon)
                    Case MessageBoxResult.Yes
                        Me.SaveDocument()
                        Exit Sub
                    Case MessageBoxResult.Cancel
                        e.Cancel = True
                        Exit Sub
                End Select
            End If
        End Sub

        Private Sub OpenDocument()
            Dim dlg As New OpenFileDialog
            dlg.FileName = "Document"
            dlg.DefaultExt = ".wpf"
            dlg.Filter = "Word Processor Files (.wpf)|*.wpf"
            Dim dialogResult As Nullable(Of Boolean) = dlg.ShowDialog
            If (dialogResult.GetValueOrDefault AndAlso dialogResult.HasValue) Then
                Dim filename As String = dlg.FileName
            End If
        End Sub

        Private Sub PrintDocument()
            Dim dlg As New PrintDialog
            dlg.PageRangeSelection = PageRangeSelection.AllPages
            dlg.UserPageRangeEnabled = True
            Dim dialogResult As Nullable(Of Boolean) = dlg.ShowDialog
            If (dialogResult.GetValueOrDefault AndAlso dialogResult.HasValue) Then
                ' Print ...
            End If
        End Sub

        Private Sub SaveDocument()
            Dim dlg As New SaveFileDialog
            dlg.FileName = "Document"
            dlg.DefaultExt = ".wpf"
            dlg.Filter = "Word Processor Files (.wpf)|*.wpf"
            Dim nullable1 As Nullable(Of Boolean) = dlg.ShowDialog
            Dim dialogResult As Nullable(Of Boolean) = dlg.ShowDialog
            If (dialogResult.GetValueOrDefault AndAlso dialogResult.HasValue) Then
                Dim filename As String = dlg.FileName
            End If
        End Sub

        Private needsToBeSaved As Boolean
        Private Sub dlg_TextFound(ByVal sender As Object, ByVal e As EventArgs)
            Dim dlg As FindDialogBox = DirectCast(sender, FindDialogBox)
            Me.documentTextBox.Select(dlg.Index, dlg.Length)
            Me.documentTextBox.Focus()
        End Sub
    End Class
End Namespace
