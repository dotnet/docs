        Dim getInfo = My.Computer.FileSystem.GetDriveInfo("C:\")
        MsgBox("The drive's type is " & getInfo.DriveType)
        MsgBox("The drive has " & getInfo.TotalFreeSpace & " bytes free.")