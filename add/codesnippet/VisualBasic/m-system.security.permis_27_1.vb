    ' ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    ' permission with the specified state from the XML encoding.
    Private Shared Sub ToFromXmlDemo()


        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows)
        Dim uiPerm2 As New UIPermission(PermissionState.None)
        uiPerm2.FromXml(uiPerm1.ToXml())
        Dim result As Boolean = uiPerm2.Equals(uiPerm1)
        If result Then
            Console.WriteLine("Result of ToFromXml = " + uiPerm2.ToString())
        Else
            Console.WriteLine(uiPerm2.ToString())
            Console.WriteLine(uiPerm1.ToString())
        End If

    End Sub 'ToFromXmlDemo 
End Class 'UIPermissionDemo