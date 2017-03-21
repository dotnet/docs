      switch ( option )
      {
         case Option::First:
            result = 1.0;
            break;

         // Insert additional cases.

         default:
            #if defined(TRACE)
            Trace::Fail( String::Format( "Unsupported option {0}", option ),
               "Result set to 1.0" );
            #endif
            result = 1.0;
            break;
      }