      // Copy elements of collection to an Object array.
      array<Object^>^myObjectArray2 = gcnew array<Object^>(myCollection->Count);
      myCollection->CopyTo( myObjectArray2, 0 );
      Console::WriteLine( "Collection elements are copied to an object array." );