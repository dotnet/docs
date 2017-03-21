   // Process the SOAP message received and write to log file.
   public override void ProcessMessage(SoapMessage message) 
   {
      switch (message.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutput( message );
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInput( message );
            break;
         case SoapMessageStage.AfterDeserialize:
            break;
         default:
            throw new Exception("invalid stage");
      }
   }