    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    Private Shared Sub IsSubsetOfDemo()
        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows)
        Dim uiPerm2 As New UIPermission(UIPermissionWindow.SafeSubWindows)
        CheckIsSubsetOfWindow(uiPerm1, uiPerm2)
        uiPerm1 = New UIPermission(UIPermissionClipboard.AllClipboard)
        uiPerm2 = New UIPermission(UIPermissionClipboard.OwnClipboard)
        CheckIsSubsetOfClipBoard(uiPerm1, uiPerm2)

    End Sub 'IsSubsetOfDemo

    Private Shared Sub CheckIsSubsetOfWindow(ByVal uiPerm1 As UIPermission, ByVal uiPerm2 As UIPermission)
        If uiPerm1.IsSubsetOf(uiPerm2) Then
            Console.WriteLine(uiPerm1.Window.ToString() + " is a subset of " + uiPerm2.Window.ToString())
        Else
            Console.WriteLine(uiPerm1.Window.ToString() + " is not a subset of " + uiPerm2.Window.ToString())
        End If

        If uiPerm2.IsSubsetOf(uiPerm1) Then
            Console.WriteLine(uiPerm2.Window.ToString() + " is a subset of " + uiPerm1.Window.ToString())
        Else
            Console.WriteLine(uiPerm2.Window.ToString() + " is not a subset of " + uiPerm1.Window.ToString())
        End If

    End Sub 'CheckIsSubsetOfWindow

    Private Shared Sub CheckIsSubsetOfClipBoard(ByVal uiPerm1 As UIPermission, ByVal uiPerm2 As UIPermission)
        If uiPerm1.IsSubsetOf(uiPerm2) Then
            Console.WriteLine(uiPerm1.Clipboard.ToString() + " is a subset of " + uiPerm2.Clipboard.ToString())
        Else
            Console.WriteLine(uiPerm1.Clipboard.ToString() + " is not a subset of " + uiPerm2.Clipboard.ToString())
        End If

        If uiPerm2.IsSubsetOf(uiPerm1) Then
            Console.WriteLine(uiPerm2.Clipboard.ToString() + " is a subset of " + uiPerm1.Clipboard.ToString())
        Else
            Console.WriteLine(uiPerm2.Clipboard.ToString() + " is not a subset of " + uiPerm1.Clipboard.ToString())
        End If

    End Sub 'CheckIsSubsetOfClipBoard
