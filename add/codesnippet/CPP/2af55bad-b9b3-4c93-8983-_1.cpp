   // Get an IDictionary of properties for a given proxy.
   IDictionary^ myDictionary = ChannelServices::GetChannelSinkProperties( myProxy );
   ICollection^ myKeysCollection = myDictionary->Keys;
   array<Object^>^myKeysArray = gcnew array<Object^>(myKeysCollection->Count);
   ICollection^ myValuesCollection = myDictionary->Values;
   array<Object^>^myValuesArray = gcnew array<Object^>(myValuesCollection->Count);
   myKeysCollection->CopyTo( myKeysArray, 0 );
   myValuesCollection->CopyTo( myValuesArray, 0 );
   for ( int iIndex = 0; iIndex < myKeysArray->Length; iIndex++ )
   {
      Console::WriteLine( "Property Name : {0} value : {1}", myKeysArray[ iIndex ], myValuesArray[ iIndex ] );

   }