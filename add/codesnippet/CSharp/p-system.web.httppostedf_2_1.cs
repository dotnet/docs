HttpFileCollection MyFileColl = Request.Files;
 HttpPostedFile MyPostedFile = MyFileColl.Get(0);
 String MyFileName = MyPostedFile.FileName;
    