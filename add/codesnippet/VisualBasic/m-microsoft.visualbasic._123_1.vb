        ' Assume current path on C drive is "C:\WINDOWS\SYSTEM".
        ' Assume current path on D drive is "D:\EXCEL".
        ' Assume C is the current drive.
        Dim MyPath As String
        MyPath = CurDir()   ' Returns "C:\WINDOWS\SYSTEM".
        MyPath = CurDir("C"c)   ' Returns "C:\WINDOWS\SYSTEM".
        MyPath = CurDir("D"c)   ' Returns "D:\EXCEL".