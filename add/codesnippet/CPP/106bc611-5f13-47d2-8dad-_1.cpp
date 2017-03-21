      mySoapHeaders = gcnew array<MySoapHeader^>(mySoapHeaderCollection->Count);
      mySoapHeaderCollection->CopyTo( mySoapHeaders, 0 );