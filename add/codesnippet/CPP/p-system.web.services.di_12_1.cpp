   ICollection^ myCollection = myDiscoveryClientDocumentCollection->Keys;
   array<Object^>^myObjectCollection =
      gcnew array<Object^>(myDiscoveryClientDocumentCollection->Count);
   myCollection->CopyTo( myObjectCollection, 0 );
   Console::WriteLine( "The discovery documents in the collection are :" );
   for ( int iIndex = 0; iIndex < myObjectCollection->Length; iIndex++ )
      Console::WriteLine( myObjectCollection[ iIndex ] );