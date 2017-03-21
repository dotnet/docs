String FileName;
 FileInfo MyFileInfo;
 long StartPos = 0, FileSize;
 
 FileName = "c:\\temp\\login.txt";
 MyFileInfo = new FileInfo(FileName);
 FileSize = MyFileInfo.Length;
 
 Response.Write("Please Login: <br>");
 Response.WriteFile(FileName, StartPos, FileSize);
    