
            ' Create a new WebRequest Object to the mentioned URL.
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
            Console.WriteLine(ControlChars.Cr + "The Timeout time of the request before setting is : {0} milliseconds", myWebRequest.Timeout)

            ' Set the 'Timeout' property in Milliseconds.
	     myWebRequest.Timeout = 10000

           ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
