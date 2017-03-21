Dim Loop1 As Integer
 Dim TempFileName As String
 Dim MyFileCollection As HttpFileCollection = Request.Files
 
 For Loop1 = 0 To MyFileCollection.Count - 1
    ' Create a new file name.
    TempFileName = "C:\TempFiles\File_" & CStr(Loop1)
    ' Save the file.
    MyFileCollection(Loop1).SaveAs(TempFileName)
 Next Loop1
   