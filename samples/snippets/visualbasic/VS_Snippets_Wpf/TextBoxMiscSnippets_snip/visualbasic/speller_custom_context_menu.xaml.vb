' <SnippetSpellerCustomContextMenuCodeExampleWholePage>

Namespace SDKSample
    Partial Public Class SpellerCustomContextMenu
        Inherits Page

        Private Sub OnWindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

            'This is required for the first time ContextMenu invocation 
            'so that TextEditor doesnt handle it.
            myTextBox.ContextMenu = GetContextMenu()
        End Sub

        Private Sub tb_ContextMenuOpening(ByVal sender As Object,
                                          ByVal e As RoutedEventArgs)

            Dim caretIndex, cmdIndex As Integer
            Dim spellingError As SpellingError

            myTextBox.ContextMenu = GetContextMenu()
            caretIndex = myTextBox.CaretIndex

            cmdIndex = 0
            spellingError = myTextBox.GetSpellingError(caretIndex)
            If spellingError IsNot Nothing Then
                For Each str As String In spellingError.Suggestions
                    Dim mi As New MenuItem()
                    mi.Header = str
                    mi.FontWeight = FontWeights.Bold
                    mi.Command = EditingCommands.CorrectSpellingError
                    mi.CommandParameter = str
                    mi.CommandTarget = myTextBox
                    myTextBox.ContextMenu.Items.Insert(cmdIndex, mi)
                    cmdIndex += 1
                Next str
                Dim separatorMenuItem1 As New Separator()
                myTextBox.ContextMenu.Items.Insert(cmdIndex, separatorMenuItem1)
                cmdIndex += 1
                Dim ignoreAllMI As New MenuItem()
                ignoreAllMI.Header = "Ignore All"
                ignoreAllMI.Command = EditingCommands.IgnoreSpellingError
                ignoreAllMI.CommandTarget = myTextBox
                myTextBox.ContextMenu.Items.Insert(cmdIndex, ignoreAllMI)
                cmdIndex += 1
                Dim separatorMenuItem2 As New Separator()
                myTextBox.ContextMenu.Items.Insert(cmdIndex, separatorMenuItem2)
            End If
        End Sub

        ' Gets a fresh context menu. 
        Private Function GetContextMenu() As ContextMenu
            Dim cm As New ContextMenu()

            'Can create STATIC custom menu items if exists here...
            Dim m1, m2, m3, m4 As MenuItem
            m1 = New MenuItem()
            m1.Header = "File"
            m2 = New MenuItem()
            m2.Header = "Save"
            m3 = New MenuItem()
            m3.Header = "SaveAs"
            m4 = New MenuItem()
            m4.Header = "Recent Files"

            'Can add functionality for the custom menu items here...

            cm.Items.Add(m1)
            cm.Items.Add(m2)
            cm.Items.Add(m3)
            cm.Items.Add(m4)

            Return cm
        End Function

    End Class
End Namespace
' </SnippetSpellerCustomContextMenuCodeExampleWholePage>