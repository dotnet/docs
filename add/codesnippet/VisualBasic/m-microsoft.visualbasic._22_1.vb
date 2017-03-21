        Dim MyStamp As Date
        ' Assume TESTFILE was last modified on October 12, 2001 at 4:35:47 PM.
        ' Assume English/U.S. locale settings.
        ' Returns "10/12/2001 4:35:47 PM".
        MyStamp = FileDateTime("C:\TESTFILE.txt")