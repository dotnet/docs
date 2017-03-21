   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInputBeforeDeserialize(myMessage As SoapMessage)
      Copy(myOldStream, myNewStream)
      Dim myFileStream As _
         New FileStream(myFileName, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "---------------------------------- Response at " + DateTime.Now)
      Dim myStream As Stream = myMessage.Stream
      myStreamWriter.Write("Length of data in the current response: ")
      myStreamWriter.WriteLine(myStream.Length)
      myStreamWriter.Flush()
      myNewStream.Position = 0
      Copy(myNewStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      myNewStream.Position = 0
   End Sub 'WriteInputBeforeDeserialize