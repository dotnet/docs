public:
   static void MyMethod( Type^ type, Type^ baseType )
   {
     #if defined(TRACE)
     Trace::Assert( type != nullptr, "Type parameter is null" );
     #endif
      
      // Perform some processing.
   }