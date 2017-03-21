      switch ( option )
      {
         case Option::First:
            result = 1.0;
            break;

         // Insert additional cases.

         default:
            #if defined(TRACE)
            Trace::Fail(String::Format("Unknown Option {0}", option));
            #endif
            result = 1.0;
            break;
      }