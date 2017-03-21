   ' Process the SOAP message received and write to log file.
   Public Overrides Sub ProcessMessage(message As SoapMessage)
      Select Case message.Stage
         Case SoapMessageStage.BeforeSerialize
            WriteOutputBeforeSerialize(message)
         Case SoapMessageStage.AfterSerialize
            WriteOutputAfterSerialize(message)
         Case SoapMessageStage.BeforeDeserialize
            WriteInputBeforeDeserialize(message)
         Case SoapMessageStage.AfterDeserialize
            WriteInputAfterDeserialize(message)
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage

   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutputBeforeSerialize(message As SoapMessage)
      Dim myFileStream As New FileStream( _
         filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "================================== Request at " & _
         DateTime.Now)
      myStreamWriter.WriteLine("The method that has been invoked is: ")
      myStreamWriter.WriteLine(ControlChars.Tab & message.MethodInfo.ToString())
      myStreamWriter.WriteLine("The contents of the SOAPAction HTTP header is:")
      myStreamWriter.WriteLine(ControlChars.Tab & message.Action)
      myStreamWriter.WriteLine("The contents of HTTP Content-type header is:")
      myStreamWriter.WriteLine(ControlChars.Tab & message.ContentType)
      If message.OneWay Then
         myStreamWriter.WriteLine( _
            "The method invoked on the client shall not wait" & _
            " till the server finishes")
      Else
         myStreamWriter.WriteLine( _
            "The method invoked on the client shall wait" & _
            " till the server finishes")
      End If
      myStreamWriter.WriteLine( _
         "The site where the XML Web service is available is: ")
      myStreamWriter.WriteLine(ControlChars.Tab & message.Url)
      myStreamWriter.WriteLine("The values of the in parameters are:")
      myStreamWriter.WriteLine("Value of first in parameter: {0}", _
         message.GetInParameterValue(0))
      myStreamWriter.WriteLine("Value of second in parameter: {0}", _
         message.GetInParameterValue(1))
      myStreamWriter.WriteLine()
      myStreamWriter.Flush()
      myStreamWriter.Close()
      myFileStream.Close()
   End Sub 'WriteOutputBeforeSerialize

   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInputAfterDeserialize(message As SoapMessage)
      Dim myFileStream As _
         New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine()
      myStreamWriter.WriteLine("The values of the out parameter are:")
      myStreamWriter.WriteLine("The value of the out parameter is: {0}", _
         message.GetOutParameterValue(0))
      myStreamWriter.WriteLine("The values of the return parameter are:")
      myStreamWriter.WriteLine("The value of the return parameter is: {0}", _
         message.GetReturnValue())
      myStreamWriter.Flush()
      myStreamWriter.Close()
      myFileStream.Close()
   End Sub 'WriteInputAfterDeserialize
