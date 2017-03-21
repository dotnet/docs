         // Array of Headers with name and values initialized.
         Header[] myArrSetHeader = {new Header("Header0","CallContextHeader0"),
                                      new Header("Header1","CallContextHeader1")};

         // Pass the Header Array with method call.
         // Header will be set in the method by'CallContext.SetHeaders' method in remote object.

         Console.WriteLine("Remote HeaderMethod output is " +
                                 myService.HeaderMethod("CallContextHeader",myArrSetHeader));

         Header[] myArrGetHeader;
         // Get Header Array.
         myArrGetHeader=CallContext.GetHeaders();
         if (null == myArrGetHeader)
            Console.WriteLine("CallContext.GetHeaders Failed");
         else
            Console.WriteLine("Headers:");
         foreach(Header myHeader in myArrGetHeader)
         {
            Console.WriteLine("Value in Header '{0}' is '{1}'.",myHeader.Name,myHeader.Value);
         }