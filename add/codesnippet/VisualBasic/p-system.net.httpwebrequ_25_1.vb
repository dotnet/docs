    ' Create a new 'Uri' object with the mentioned string.
    Dim myUri As New Uri("http://www.contoso.com")
    ' Create a new 'HttpWebRequest' object with the above 'Uri' object.
    Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
    ' Create a new 'DateTime' object.
    Dim targetDate As DateTime = DateTime.Now
    targetDate.AddDays(-7.0)
    myHttpWebRequest.IfModifiedSince = targetDate
    
    Try
      ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
      Console.WriteLine("Response headers for recently modified page" + ControlChars.Cr + "{0}" + ControlChars.Cr, myHttpWebResponse.Headers)
      Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
      Dim streamRead As New StreamReader(streamResponse)
      Dim readBuff(256) As [Char]
      Dim count As Integer = streamRead.Read(readBuff, 0, 256)
      Console.WriteLine(ControlChars.Cr + "The contents of Html Page are :  " + ControlChars.Cr)
      While count > 0
        Dim outputData As New [String](readBuff, 0, count)
        Console.Write(outputData)
        count = streamRead.Read(readBuff, 0, 256)
      End While

      ' Close the Stream object.
      streamResponse.Close()
      streamRead.Close()
      ' Release the HttpWebResponse Resource.
      myHttpWebResponse.Close()
      Console.WriteLine(ControlChars.Cr + "Press 'Enter' key to continue.................")
      Console.Read()
    Catch e As WebException
      If e.Response IsNot Nothing
      
        If CType(e.Response,HttpWebResponse).StatusCode = HttpStatusCode.NotModified
          Console.WriteLine((ControlChars.Cr + "The page has not been modified since " + targetDate))
        Else
          Console.WriteLine(ControlChars.Cr + "Unexpected status code = " + Ctype(e.Response,HttpWebResponse).StatusCode)
        End If
      Else
        Console.WriteLine(ControlChars.Cr + "Unexpected Web Exception " + e.Message) 
      End If
    End Try  