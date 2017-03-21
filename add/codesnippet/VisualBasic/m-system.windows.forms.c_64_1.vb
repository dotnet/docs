    ' Demonstrates SetFileDropList, ContainsFileDroList, and GetFileDropList
    Public Function SwapClipboardFileDropList(ByVal replacementList _
        As System.Collections.Specialized.StringCollection) _
        As System.Collections.Specialized.StringCollection

        Dim returnList As System.Collections.Specialized.StringCollection _
            = Nothing

        If Clipboard.ContainsFileDropList() Then

            returnList = Clipboard.GetFileDropList()
            Clipboard.SetFileDropList(replacementList)
        End If

        Return returnList

    End Function