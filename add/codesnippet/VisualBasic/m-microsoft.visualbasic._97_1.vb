        Dim OldName, NewName As String
        OldName = "OLDFILE"
        ' Define file names.
        NewName = "NEWFILE"
        ' Rename file.
        Rename(OldName, NewName)

        OldName = "C:\OLDDIR\OLDFILE"
        NewName = "C:\NEWDIR\NEWFILE"
        ' Move and rename file.
        Rename(OldName, NewName)