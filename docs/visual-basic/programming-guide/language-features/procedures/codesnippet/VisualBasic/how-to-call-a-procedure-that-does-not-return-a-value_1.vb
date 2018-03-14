        Dim notepadID As Integer
        ' Activate a running Notepad process.
        AppActivate("Untitled - Notepad")
        ' AppActivate can also use the return value of the Shell function.
        ' Shell runs a new instance of Notepad.
        notepadID = Shell("C:\WINNT\NOTEPAD.EXE", AppWinStyle.NormalFocus)
        ' Activate the new instance of Notepad.  
        AppActivate(notepadID)