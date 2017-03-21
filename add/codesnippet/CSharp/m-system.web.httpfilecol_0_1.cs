HttpFileCollection MyFileColl = Request.Files;
 HttpPostedFile MyPostedMember = MyFileColl.Get(0);
 String MyFileName = MyPostedMember.FileName;
   