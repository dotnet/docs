        Dim procID As Integer
        ' Run calculator.
        procID = Shell("C:\Windows\system32\calc.exe", AppWinStyle.NormalFocus)
        ' The preceding path is for Windows XP.
        ' The Windows 2000 path is C:\WINNT\system32\calc.exe.