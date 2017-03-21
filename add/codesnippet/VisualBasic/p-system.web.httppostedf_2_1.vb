Dim MyFileColl As HttpFileCollection = Request.Files
 Dim MyPostedFile As HttpPostedFile = MyFileColl.Get(0)
 Dim MyFileName As String = MyPostedFile.FileName
    