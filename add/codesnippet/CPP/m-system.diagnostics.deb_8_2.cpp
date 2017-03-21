       switch ( option )
       {
          case Option::First:
             result = 1.0;
             break;
    
          // Insert additional cases.
          
          default:
             #if defined(DEBUG)
             Debug::Fail( "Unknown Option" + option, "Result set to 1.0" );
             #endif
             result = 1.0;
             break;
       }