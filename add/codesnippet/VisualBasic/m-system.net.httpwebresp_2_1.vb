            ' Creates an HttpWebRequest for the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Sends the HttpWebRequest and waits for a response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine("Response Received.Trying to Close the response stream..")
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
            Console.WriteLine("Response Stream successfully closed")