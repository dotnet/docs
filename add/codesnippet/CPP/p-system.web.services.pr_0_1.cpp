public:
   virtual void ProcessMessage( SoapMessage^ message ) override
   {
      switch ( message->Stage )
      {
         case SoapMessageStage::BeforeSerialize:
            break;

         case SoapMessageStage::AfterSerialize:
            WriteOutput( message );
            break;

         case SoapMessageStage::BeforeDeserialize:
            WriteInput( message );
            break;

         case SoapMessageStage::AfterDeserialize:
            break;


      }
   }