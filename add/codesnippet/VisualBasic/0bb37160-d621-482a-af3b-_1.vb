        Dim MyFile, MyPath, MyName As String
        ' Returns "WIN.INI" if it exists.
        MyFile = Dir("C:\WINDOWS\WIN.INI")

        ' Returns filename with specified extension. If more than one *.INI
        ' file exists, the first file found is returned.
        MyFile = Dir("C:\WINDOWS\*.INI")

        ' Call Dir again without arguments to return the next *.INI file in the
        ' same directory.
        MyFile = Dir()

        ' Return first *.TXT file, including files with a set hidden attribute.
        MyFile = Dir("*.TXT", vbHidden)

        ' Display the names in C:\ that represent directories.
        MyPath = "c:\"   ' Set the path.
        MyName = Dir(MyPath, vbDirectory)   ' Retrieve the first entry.
        Do While MyName <> ""   ' Start the loop.
            ' Use bitwise comparison to make sure MyName is a directory.
            If (GetAttr(MyPath & MyName) And vbDirectory) = vbDirectory Then
                ' Display entry only if it's a directory.
                MsgBox(MyName)
            End If
            MyName = Dir()   ' Get next entry.
        Loop