Dim MyFileStream As FileStream
 Dim FileSize As Long
 
 MyFileStream = New FileStream("sometext.txt", FileMode.Open)
 FileSize = MyFileStream.Length
 
 Dim Buffer(CInt(FileSize)) As Byte
 MyFileStream.Read(Buffer, 0, CInt(FileSize))
 MyFileStream.Close()
 
 Response.Write("<b>File Contents: </b>")
 Response.BinaryWrite(Buffer)
    