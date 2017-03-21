HttpFileCollection MyFileColl = Request.Files;
 HttpPostedFile MyPostedMember = MyFileColl.Get("CustInfo");
 String MyFileName = MyPostedMember.FileName;
      