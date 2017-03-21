   array<Object^>^myObject = gcnew array<Object^>(3);
   myObject[ 0 ] = 66;
   myObject[ 1 ] = "puri";
   myObject[ 2 ] = 33.33;
   
   // Get the array of 'Type' class objects.
   array<Type^>^myTypeArray = Type::GetTypeArray( myObject );
   Console::WriteLine( "Full names of the 'Type' objects in the array are:" );
   for ( int h = 0; h < myTypeArray->Length; h++ )
   {
      Console::WriteLine( myTypeArray[ h ]->FullName );

   }