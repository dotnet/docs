   ' Process the SOAP message received and write to a log file.
   Public Overrides Sub ProcessMessage(message As SoapMessage)
      Select Case message.Stage
         Case SoapMessageStage.BeforeSerialize
         Case SoapMessageStage.AfterSerialize
            WriteOutput(CType(message, SoapClientMessage))
         Case SoapMessageStage.BeforeDeserialize
            WriteInput(CType(message, SoapClientMessage))
         Case SoapMessageStage.AfterDeserialize
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage
   
   
   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutput(message As SoapClientMessage)
      newStream.Position = 0
      Dim myFileStream As New FileStream(filename, FileMode.Append, _
         FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "================================== Request at " & DateTime.Now)

      ' Print to the log file the request header field for SoapAction header.
      myStreamWriter.WriteLine("The SoapAction Http request header field is: ")
      myStreamWriter.WriteLine(ControlChars.Tab & message.Action)

      ' Print to the log file the type of the client that invoked
      ' the XML Web service method.
      myStreamWriter.WriteLine("The type of the client is: ")
      If message.Client.GetType().Equals(GetType(MathSvc)) Then
         myStreamWriter.WriteLine(ControlChars.Tab & "MathSvc")
      End If

     ' Print to the log file the method invoked by the client.
      myStreamWriter.WriteLine( _
         "The method that has been invoked by the client is:")
      myStreamWriter.WriteLine(ControlChars.Tab & message.MethodInfo.Name)

      ' Print to the log file if the method invoked is OneWay.
      If message.OneWay Then
         myStreamWriter.WriteLine( _
            "The client doesn't wait for the server to finish processing")
      Else
         myStreamWriter.WriteLine( _
            "The client waits for the server to finish processing")
      End If 

      ' Print to the log file the URL of the site that provides 
      ' implementation of the method.
      myStreamWriter.WriteLine( _
         "The url of the XML Web service method that has been requested is: ")
      myStreamWriter.WriteLine(ControlChars.Tab & message.Url)
      myStreamWriter.WriteLine("The contents of the SOAP envelope are: ")
      myStreamWriter.Flush()

      ' Copy the contents of one stream to another. 
      Copy(newStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      newStream.Position = 0

      ' Copy the contents of one stream to another. 
      Copy(newStream, oldStream)
  End Sub 'WriteOutput