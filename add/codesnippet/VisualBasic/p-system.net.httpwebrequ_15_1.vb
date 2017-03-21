
Class HttpWebRequest_Connection
  
  Shared Sub Main()
    Try

      ' Create a new 'HttpWebRequest' object for the specified Uri. Make sure that 
      ' a default proxy is set if you are behind a firewall.
      Dim myHttpWebRequest1 As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
      myHttpWebRequest1.KeepAlive = False
      ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      Dim myHttpWebResponse1 As HttpWebResponse = CType(myHttpWebRequest1.GetResponse(), HttpWebResponse)

      Console.WriteLine(ControlChars.Cr + "The HTTP request Headers for the first request are {0}", myHttpWebRequest1.Headers)
      Console.WriteLine("Press Enter Key to Continue..........")
      Console.Read()
      Dim streamResponse As Stream = myHttpWebResponse1.GetResponseStream()
      Dim streamRead As New StreamReader(streamResponse)
      Dim readBuff(256) As [Char]
      Dim count As Integer = streamRead.Read(readBuff, 0, 256)
      Console.WriteLine("The contents of the Html page are......." + ControlChars.Cr)
      While count > 0
        Dim outputData As New [String](readBuff, 0, count)
        Console.Write(outputData)
        count = streamRead.Read(readBuff, 0, 256)
      End While
      ' Close the Stream object.
      streamResponse.Close()
      streamRead.Close()
     ' Release the resources held by response object.
      myHttpWebResponse1.Close()
      Console.WriteLine()
     ' Create a new 'HttpWebRequest' object  to the specified Uri.   
      Dim myHttpWebRequest2 As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
      myHttpWebRequest2.Connection = "Close"
      ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      Dim myHttpWebResponse2 As HttpWebResponse = CType(myHttpWebRequest2.GetResponse(), HttpWebResponse)
    ' Release the resources held by response object.
    myHttpWebResponse2.Close()
      Console.WriteLine(ControlChars.Cr + "The Http RequestHeaders are " + ControlChars.Cr + "{0}", myHttpWebRequest2.Headers)
      Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue.........")
      Console.Read()
    Catch e As ArgumentException
      Console.WriteLine(ControlChars.Cr + "The second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close'")
      Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
    Catch e As WebException
      Console.WriteLine("WebException raised!")
      Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
      Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
    Catch e As Exception
      Console.WriteLine("Exception raised!")
      Console.WriteLine("Source :{0} ", e.Source)
      Console.WriteLine("Message : {0}", e.Message)
    End Try
  End Sub ' Main
End Class ' HttpWebRequest_Connection