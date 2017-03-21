int indx;
 
 String[] arr = Request.AcceptTypes;    
 for (indx = 0; indx < arr.Length; indx++) {
    Response.Write("Accept Type " + indx +": " + arr[indx] + "<br>");
 }
   