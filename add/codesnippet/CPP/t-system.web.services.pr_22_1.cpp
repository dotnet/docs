   // Process the SOAP message received and write to a log file.
   void ProcessMessage( SoapMessage^ message )
   {
      switch ( message->Stage )
      {
         case SoapMessageStage::BeforeSerialize:
            break;
         case SoapMessageStage::AfterSerialize:
            WriteOutput( dynamic_cast<SoapClientMessage^>(message) );
            break;
         case SoapMessageStage::BeforeDeserialize:
            WriteInput( dynamic_cast<SoapClientMessage^>(message) );
            break;
         case SoapMessageStage::AfterDeserialize:
            break;
         default:
            throw gcnew Exception( "invalid stage" );
      }
   }

   // Write the contents of the outgoing SOAP message to the log file.
   void WriteOutput( SoapClientMessage^ message )
   {
      newStream->Position = 0;
      FileStream^ myFileStream = gcnew FileStream( filename, FileMode::Append,
         FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine(
         "================================== Request at {0}", DateTime::Now );
      
      // Print to the log file the request header field for SoapAction header.
      myStreamWriter->WriteLine( "The SoapAction Http request header field is: " );
      myStreamWriter->WriteLine( "\t{0}", message->Action );
      
      // Print to the log file the type of the client that invoked 
      // the XML Web service method.
      myStreamWriter->WriteLine( "The type of the client is: " );
      if ( (message->Client->GetType())->Equals( typeid<MathSvc^> ) )
      {
         myStreamWriter->WriteLine( "\tMathSvc" );
      }
      
      // Print to the log file the method invoked by the client.
      myStreamWriter->WriteLine(
         "The method that has been invoked by the client is:" );
      myStreamWriter->WriteLine( "\t{0}", message->MethodInfo->Name );
      
      // Print to the log file if the method invoked is OneWay.
      if ( message->OneWay )
      {
         myStreamWriter->WriteLine(
            "The client doesn't wait for the server to finish processing" );
      }
      else
      {
         myStreamWriter->WriteLine(
         "The client waits for the server to finish processing" );
      }
      
      // Print to the log file the URL of the site that provides 
      // implementation of the method.
      myStreamWriter->WriteLine(
         "The URL of the XML Web service method that has been requested is: " );
      myStreamWriter->WriteLine( "\t{0}", message->Url );
      myStreamWriter->WriteLine( "The contents of the SOAP envelope are: " );
      myStreamWriter->Flush();
      
      // Copy the contents of one stream to another. 
      Copy( newStream, myFileStream );
      myFileStream->Close();
      newStream->Position = 0;
      
      // Copy the contents of one stream to another. 
      Copy( newStream, oldStream );
   }