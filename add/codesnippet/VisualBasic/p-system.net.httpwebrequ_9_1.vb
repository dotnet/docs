	   ' Create a new 'HttpWebRequest' Object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            Console.WriteLine(ControlChars.Cr + "The timeout time of the request before setting the property is  {0}  milliSeconds", myHttpWebRequest.Timeout)
           ' Set the  'Timeout' property of the HttpWebRequest to 10 milliseconds.
	    myHttpWebRequest.Timeout = 10	
            ' Display the 'Timeout' property of the 'HttpWebRequest' on the console.
            Console.WriteLine(ControlChars.Cr + "The timeout time of the request after setting the timeout is {0}  milliSeconds", myHttpWebRequest.Timeout)
            ' A HttpWebResponse object is created and is GetResponse Property of the HttpWebRequest associated with it 
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)