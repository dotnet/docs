            ' Create a new WebRequest Object to the mentioned URL.
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
            Console.WriteLine(ControlChars.Cr + ControlChars.Lf +"The Uri that was requested is {0}", myWebRequest.RequestUri)
            ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
			      ' Get the stream containing content returned by the server.
            Dim streamResponse As Stream = myWebResponse.GetResponseStream()
            Console.WriteLine(ControlChars.Cr + ControlChars.Lf + "The Uri that responded to the request is {0}", myWebResponse.ResponseUri)
            ' Print the HTML contents of the page to the console. 
            Dim reader As New StreamReader(streamResponse)
			      ' Read the content.
			      Dim responseFRomServer As String = reader.ReadToEnd()
            ' Display the content.
            Console.WriteLine(ControlChars.Cr + ControlChars.Lf +"The HTML Contents received:")
            Console.WriteLine (responseFromServer)
            ' Cleanup the streams and the response.
            reader.Close ()
            streamResponse.Close ()
            myWebResponse.Close ()