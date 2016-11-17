    Private Function UnicodeStringToBytes( 
        ByVal str As String) As Byte()

        Return System.Text.Encoding.Unicode.GetBytes(str)
    End Function