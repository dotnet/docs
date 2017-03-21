         ' Array of Headers with name and values initialized.
         Dim myArrSetHeader As Header() =  {New Header("Header0", "CallContextHeader0"), _
                                                   New Header("Header1", "CallContextHeader1")}

         ' Pass the Header Array with method call.
         ' Header will be set in the method by'CallContext.SetHeaders' method in remote object.

         Console.WriteLine("Remote HeaderMethod output is " _
                              + myService.HeaderMethod("CallContextHeader", myArrSetHeader))

         Dim myArrGetHeader() As Header
         ' Get Header Array.

         myArrGetHeader = CallContext.GetHeaders()
         If myArrGetHeader Is Nothing Then
            Console.WriteLine("CallContext.GetHeaders Failed")
         Else
            Console.WriteLine("Headers:")
         End If

         Dim myHeader As Header
         For each myHeader in myArrGetHeader
            Console.WriteLine("Value in Header '{0}' is '{1}'.",myHeader.Name,myHeader.Value)
         Next