      newStream.Position = 0;
      FileStream myFileStream = new FileStream(filename, FileMode.Append,
         FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine(
         "================================== Request at "
         + DateTime.Now);

      // Print to the log file the request header field for SoapAction header.
      myStreamWriter.WriteLine("The SoapAction Http request header field is: ");
      myStreamWriter.WriteLine("\t" + message.Action);

      // Print to the log file the type of the client that invoked 
      // the XML Web service method.
      myStreamWriter.WriteLine("The type of the client is: ");
      if((message.Client.GetType()).Equals(typeof(MathSvc)))
         myStreamWriter.WriteLine("\tMathSvc");

      // Print to the log file the method invoked by the client.
      myStreamWriter.WriteLine(
         "The method that has been invoked by the client is:");
      myStreamWriter.WriteLine("\t" + message.MethodInfo.Name);

      // Print to the log file if the method invoked is OneWay.
      if(message.OneWay)
         myStreamWriter.WriteLine(
           "The client doesn't wait for the server to finish processing");
      else
         myStreamWriter.WriteLine(
           "The client waits for the server to finish processing");

      // Print to the log file the URL of the site that provides 
      // implementation of the method.
      myStreamWriter.WriteLine(
         "The URL of the XML Web service method that has been requested is: ");
      myStreamWriter.WriteLine("\t" + message.Url);
      myStreamWriter.WriteLine("The contents of the SOAP envelope are: ");
      myStreamWriter.Flush();

      // Copy the contents of one stream to another. 
      Copy(newStream, myFileStream);
      myFileStream.Close();
      newStream.Position = 0;

      // Copy the contents of one stream to another. 
      Copy(newStream, oldStream);