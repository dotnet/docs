       switch ( option )
       {
          case Option::First:
             result = 1.0;
             break;
    
          // Insert additional cases.
          
          default:
             #if defined(DEBUG)
             Debug::Fail( "Unknown Option" + option );
             #endif
             result = 1.0;
             break;
       }