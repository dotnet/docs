HttpFileCollection MyFileCollection = Request.Files;
 
 for (int Loop1 = 0; Loop1 < MyFileCollection.Count; Loop1++)
 {
    if (MyFileCollection[Loop1].ContentType == "video/mpeg")
    {
       //...
    }
 }
    