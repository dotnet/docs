      catch ( Exception^ ) 
      {
        #if defined(TRACE)
        Trace::Fail( String::Format( "Invalid value: {0}", value ),
            "Resetting value to newValue." );
         #endif
         value = newValue;
      }