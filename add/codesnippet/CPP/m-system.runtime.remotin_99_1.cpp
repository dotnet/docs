   virtual ObjRef^ CreateObjRef( Type^ ServerType ) override
   {
      Console::WriteLine( "CreateObjRef Method Called ..." );
      CustomObjRef ^ myObjRef = gcnew CustomObjRef( myMarshalByRefObject,ServerType );
      myObjRef->URI = myUri;
      return myObjRef;
   }