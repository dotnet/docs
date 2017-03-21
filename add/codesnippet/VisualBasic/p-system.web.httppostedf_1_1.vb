Dim Loop1 As Integer
 Dim MyFileCollection As HttpFileCollection = Request.Files
 
 For Loop1 = 0 To MyFileCollection.Count - 1
    If MyFileCollection(Loop1).ContentType = "video/mpeg" Then
       '...
    End If
 Next Loop1
    