public:
   static void MyMethod( Type^ type, Type^ baseType )
   {
      #if defined(TRACE)
      Trace::Assert( type != nullptr, "Type parameter is null", "Can't get object for null type" );
      #endif
      
      // Perform some processing.
   }