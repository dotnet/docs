      catch ( Exception^ ) 
      {
         #if defined(TRACE)
         Trace::Fail( "Unknown Option " + option + ", using the default." );
         #endif
      }