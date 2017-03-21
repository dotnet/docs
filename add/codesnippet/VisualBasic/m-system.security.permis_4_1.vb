    ' Union creates a new permission that is the union of the current permission
    ' and the specified permission.
    Private Shared Sub UnionDemo()
        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows)
        Dim uiPerm2 As New UIPermission(UIPermissionWindow.SafeSubWindows)
        Dim p3 As UIPermission = CType(uiPerm1.Union(uiPerm2), UIPermission)
        Try
            If Not (p3 Is Nothing) Then
                Console.WriteLine("The union of " + uiPerm1.Window.ToString() + " and " + vbLf + vbTab + uiPerm2.Window.ToString() + " is " + vbLf + vbTab + p3.Window.ToString() + vbLf)

            Else
                Console.WriteLine("The union of " + uiPerm1.Window.ToString() + " and " + vbLf + vbTab + uiPerm2.Window.ToString() + " is null." + vbLf)
            End If
        Catch e As SystemException
            Console.WriteLine("The union of " + uiPerm1.Window.ToString() + " and " + vbLf + vbTab + uiPerm2.Window.ToString() + " failed.")

            Console.WriteLine(e.Message)
        End Try

    End Sub 'UnionDemo
