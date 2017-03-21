    
   // Get all URI's with Accept permission.  
   IEnumerator myEnum1 = myWebPermission1.AcceptList;
   Console.WriteLine("\n\nThe URIs with Accept permission are :\n");
    while (myEnum1.MoveNext())
    { Console.WriteLine("\tThe URI is : "+myEnum1.Current); }
    