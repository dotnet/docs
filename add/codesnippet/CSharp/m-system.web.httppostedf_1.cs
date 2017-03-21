String TempFileName;
 HttpFileCollection MyFileCollection = Request.Files;
 
 for (int Loop1 = 0; Loop1 < MyFileCollection.Count; Loop1++)
 {
    // Create a new file name.
    TempFileName = "C:\\TempFiles\\File_" + Loop1.ToString();
    // Save the file.
    MyFileCollection[Loop1].SaveAs(TempFileName);
 }
   