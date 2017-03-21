   catch ( Exception^ e ) 
   {
      #if defined(DEBUG)
      Debug::Fail( "Unknown Option " + option + ", using the default." );
      #endif
   }