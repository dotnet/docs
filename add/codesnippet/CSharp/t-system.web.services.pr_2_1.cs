   // Process the SOAP message received and write to log file.
   public override void ProcessMessage(SoapMessage message) 
   {
      switch (message.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            WriteOutputBeforeSerialize(message);
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutputAfterSerialize(message);
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInputBeforeDeserialize(message);
            break;
         case SoapMessageStage.AfterDeserialize:
            WriteInputAfterDeserialize(message);
            break;
         default:
            throw new Exception("invalid stage");
      }
   }

   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutputBeforeSerialize(SoapMessage message)
   {
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("================================== Request at "
         + DateTime.Now);
      myStreamWriter.WriteLine("The method that has been invoked is: ");
      myStreamWriter.WriteLine("\t" + message.MethodInfo);
      myStreamWriter.WriteLine(
         "The contents of the SOAPAction HTTP header is:");
      myStreamWriter.WriteLine("\t" + message.Action);
      myStreamWriter.WriteLine("The contents of HTTP Content-type header is:");
      myStreamWriter.WriteLine("\t" + message.ContentType);
      if(message.OneWay)
         myStreamWriter.WriteLine(
            "The method invoked on the client shall not wait"
            + " till the server finishes");
      else
         myStreamWriter.WriteLine(
            "The method invoked on the client shall wait"
            + " till the server finishes");
      myStreamWriter.WriteLine(
         "The site where the XML Web service is available is:");
      myStreamWriter.WriteLine("\t" + message.Url);
      myStreamWriter.WriteLine("The values of the in parameters are:");
      myStreamWriter.WriteLine("Value of first in parameter: {0}",
         message.GetInParameterValue(0));
      myStreamWriter.WriteLine("Value of second in parameter: {0}",
         message.GetInParameterValue(1));
      myStreamWriter.WriteLine();
      myStreamWriter.Flush();
      myStreamWriter.Close();
      myFileStream.Close();
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInputAfterDeserialize(SoapMessage message)
   {
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine();
      myStreamWriter.WriteLine("The values of the out parameter are:");
      myStreamWriter.WriteLine("The value of the out parameter is: {0}",
         message.GetOutParameterValue(0));
      myStreamWriter.WriteLine("The values of the return parameter are:");
      myStreamWriter.WriteLine("The value of the return parameter is: {0}",
         message.GetReturnValue());
      myStreamWriter.Flush();
      myStreamWriter.Close();
      myFileStream.Close();
   }
