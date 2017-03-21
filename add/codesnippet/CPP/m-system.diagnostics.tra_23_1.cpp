protected:
   // Create an index for an array.
   int index;

   void Method()
   {
      // Perform some action that sets the index.
      // Test that the index value is valid.
      #if defined(TRACE)
      Trace::Assert( index > -1 );
      #endif
   }