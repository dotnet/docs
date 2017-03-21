    Private Sub ExtractAssociatedIconEx()
        Dim ico As Icon = Icon.ExtractAssociatedIcon("C:\WINDOWS\system32\notepad.exe")
        Me.Icon = ico

    End Sub