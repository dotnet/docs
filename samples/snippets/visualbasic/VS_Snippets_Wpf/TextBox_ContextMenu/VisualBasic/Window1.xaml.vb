Imports System     
Imports System.Windows     
Imports System.Windows.Controls     

Namespace SDKSample

    Partial Public Class Window1
        Inherits Window
        '<Snippet_TextBox_ContextMenu>
        Private Sub MenuChange(ByVal sender As Object, ByVal args As RoutedEventArgs)
            Dim rb As RadioButton = CType(sender, RadioButton)
            If myGrid.Children.Contains(cxmTextBox) Then
                Select Case rb.Name
                    Case "rbCustom"
                        cxmTextBox.ContextMenu = cxm
                    Case "rbDefault"
                        'Clearing the value of the ContextMenu property
                        'restores the default TextBox context menu.
                        cxmTextBox.ClearValue(ContextMenuProperty)
                    Case "rbDisabled"
                        'Setting the ContextMenu propety to 
                        'null disables the context menu.
                        cxmTextBox.ContextMenu = Nothing
                End Select
            Else : Return
            End If
        End Sub

        Private Sub ClickPaste(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cxmTextBox.Paste()
        End Sub
        Private Sub ClickCopy(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cxmTextBox.Copy()
        End Sub
        Private Sub ClickCut(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cxmTextBox.Cut()
        End Sub
        Private Sub ClickSelectAll(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cxmTextBox.SelectAll()
        End Sub
        Private Sub ClickClear(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cxmTextBox.Clear()
        End Sub
        Private Sub ClickUndo(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cxmTextBox.Undo()
        End Sub
        Private Sub ClickRedo(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cxmTextBox.Redo()
        End Sub
        Private Sub ClickSelectLine(ByVal sender As Object, ByVal args As RoutedEventArgs)
            Dim lineIndex As Integer = cxmTextBox.GetLineIndexFromCharacterIndex(cxmTextBox.CaretIndex)
            Dim lineStartingCharIndex As Integer = cxmTextBox.GetCharacterIndexFromLineIndex(lineIndex)
            Dim lineLength As Integer = cxmTextBox.GetLineLength(lineIndex)
            cxmTextBox.Select(lineStartingCharIndex, lineLength)
        End Sub
        Private Sub CxmOpened(ByVal sender As Object, ByVal args As RoutedEventArgs)
            'Only allow copy/cut if something is selected to copy/cut.
            If cxmTextBox.SelectedText = "" Then
                cxmItemCopy.IsEnabled = cxmItemCut.IsEnabled = False
            Else
                cxmItemCopy.IsEnabled = cxmItemCut.IsEnabled = True
                'Only allow paste if there is text on the clipboard to paste.
                If Clipboard.ContainsText() Then
                    cxmItemPaste.IsEnabled = True
                Else
                    cxmItemPaste.IsEnabled = False
                End If
            End If
        End Sub
        '</Snippet_TextBox_ContextMenu>

    End Class
End Namespace
