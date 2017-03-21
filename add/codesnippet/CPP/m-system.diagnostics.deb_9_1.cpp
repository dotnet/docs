   // Create a local value.
   int index;
   
   // Perform some action that sets the local value.
   index = -40;
   
   // Test that the local value is valid. 
   #if defined(DEBUG)
   Debug::Assert( index > -1 );
   #endif