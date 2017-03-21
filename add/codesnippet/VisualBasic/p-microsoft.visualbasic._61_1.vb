        Dim getInfo = System.IO.DriveInfo.GetDrives()
        For Each info In getInfo
            MsgBox(info.name)
        Next