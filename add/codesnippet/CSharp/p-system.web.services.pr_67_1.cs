   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInputBeforeDeserialize(SoapMessage myMessage)
   {
      Copy(myOldStream, myNewStream);
      FileStream myFileStream = 
         new FileStream(myFileName, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine(
         "---------------------------------- Response at " + DateTime.Now);     
      Stream myStream = myMessage.Stream;
      myStreamWriter.Write("Length of data in the current response: ");
      myStreamWriter.WriteLine(myStream.Length);
      myStreamWriter.Flush();
      myNewStream.Position = 0;
      Copy(myNewStream, myFileStream);
      myStreamWriter.Close();
      myFileStream.Close();
      myNewStream.Position = 0;
   }