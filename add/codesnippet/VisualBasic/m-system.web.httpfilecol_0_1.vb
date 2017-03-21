Dim MyFileColl As HttpFileCollection = Request.Files
 Dim MyPostedMember As HttpPostedFile = MyFileColl.Get(0)
 Dim MyFileName As String = MyPostedMember.FileName
   