int loop1;
 HttpFileCollection MyFileColl = Request.Files;
 
 for( loop1 = 0; loop1 < MyFileColl.Count; loop1++)
 {
    if( MyFileColl.GetKey(loop1) == "CustInfo")
    {
       //...
    }
 }
    