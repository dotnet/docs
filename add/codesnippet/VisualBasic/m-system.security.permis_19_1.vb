    'Copy creates and returns an identical copy of the current permission.
    Private Shared Sub CopyDemo()

        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows)
        Dim uiPerm2 As New UIPermission(PermissionState.None)
        uiPerm2 = CType(uiPerm1.Copy(), UIPermission)
        If Not (uiPerm2 Is Nothing) Then
            Console.WriteLine("The copy succeeded:  " + uiPerm2.ToString() + " " + vbLf)
        End If

    End Sub 'CopyDemo
