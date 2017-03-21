            ' MyHeader class inherits from the SoapHeader class.
            Dim customHeader As New MyHeader()
            customHeader.MyValue = "Header value for MyValue"

            ' Set the EncodedMustUnderstand property to true.
            customHeader.EncodedMustUnderstand = "1"

            Dim myWebService As New WebService_SoapHeader_EncodedMustUnderstand()
            myWebService.MyHeaderValue = customHeader
            Dim results As String = myWebService.MyWebMethod1()
            Console.WriteLine(results)
            Try
                results = myWebService.MyWebMethod2()
            Catch myException As Exception
                Console.WriteLine("Exception raised in MyWebMethod2.")
                Console.WriteLine("Message: " & myException.Message)
            End Try