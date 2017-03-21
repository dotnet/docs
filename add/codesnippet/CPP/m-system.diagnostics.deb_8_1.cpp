   catch ( Exception^ e ) 
   {
      #if defined(DEBUG)
      Debug::Fail( "Cannot find SpecialController, proceeding with StandardController", "Setting Controller to default value" );
      #endif
   }