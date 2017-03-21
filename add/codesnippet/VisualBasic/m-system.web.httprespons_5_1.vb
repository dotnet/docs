Dim FileName As String
 Dim MyFileInfo As FileInfo
 Dim StartPos, FileSize As Long
 
 FileName = "c:\\temp\\login.txt"
 MyFileInfo = New FileInfo(FileName)
 FileSize = MyFileInfo.Length 
 
 Response.Write("Please Login: <br>")
 Response.WriteFile(FileName, StartPos, FileSize)
    