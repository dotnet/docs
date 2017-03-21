        Private Sub getNewStreamReader()
            Dim S As Stream = File.OpenRead("C:\Temp\Test.txt")
            'Get a new StreamReader in ASCII format from a
            'file using a buffer and byte order mark detection
            Dim SrAsciiFromFileFalse512 As StreamReader = New StreamReader("C:\Temp\Test.txt", _
                System.Text.Encoding.ASCII, False, 512)
            'Get a new StreamReader in ASCII format from a
            'file with byte order mark detection = false
            Dim SrAsciiFromFileFalse As StreamReader = New StreamReader("C:\Temp\Test.txt", _
                System.Text.Encoding.ASCII, False)
            'Get a new StreamReader in ASCII format from a file 
            Dim SrAsciiFromFile As StreamReader = New StreamReader("C:\Temp\Test.txt", _
                System.Text.Encoding.ASCII)
            'Get a new StreamReader from a
            'file with byte order mark detection = false        
            Dim SrFromFileFalse As StreamReader = New StreamReader("C:\Temp\Test.txt", False)
            'Get a new StreamReader from a file
            Dim SrFromFile As StreamReader = New StreamReader("C:\Temp\Test.txt")
            'Get a new StreamReader in ASCII format from a
            'FileStream with byte order mark detection = false and a buffer
            Dim SrAsciiFromStreamFalse512 As StreamReader = New StreamReader(S, _
                System.Text.Encoding.ASCII, False, 512)
            'Get a new StreamReader in ASCII format from a
            'FileStream with byte order mark detection = false
            Dim SrAsciiFromStreamFalse = New StreamReader(S, _
                System.Text.Encoding.ASCII, False)
            'Get a new StreamReader in ASCII format from a FileStream
            Dim SrAsciiFromStream As StreamReader = New StreamReader(S, _
                System.Text.Encoding.ASCII)
            'Get a new StreamReader from a
            'FileStream with byte order mark detection = false
            Dim SrFromStreamFalse As StreamReader = New StreamReader(S, False)
            'Get a new StreamReader from a FileStream
            Dim SrFromStream As StreamReader = New StreamReader(S)

        End Sub