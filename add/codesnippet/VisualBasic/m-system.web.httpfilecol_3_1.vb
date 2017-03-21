Dim MyFileColl As HttpFileCollection = Request.Files
 Dim MyPostedMember As HttpPostedFile = MyFileColl.Get("CustInfo")
 Dim MyFileName As String = MyPostedMember.FileName
      