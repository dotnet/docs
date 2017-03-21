      array<ServiceDescription^>^myArray = gcnew array<ServiceDescription^>(myCollection->Count);

      // Copy the collection to a ServiceDescription array.
      myCollection->CopyTo( myArray, 0 );
      for ( int i = 0; i < myArray->Length; i++ )
         Console::WriteLine( "Name of element in array: {0}", myArray[ i ]->Name );