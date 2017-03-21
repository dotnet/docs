   ObjRef^ objRefSample = RemotingServices::GetObjRefForProxy( myRemoteObject );
   Console::WriteLine( "***ObjRef Details***" );
   Console::WriteLine( "URI:\t {0}", objRefSample->URI );
   array<Object^>^channelData = objRefSample->ChannelInfo->ChannelData;
   Console::WriteLine( "Channel Info:" );
   IEnumerator^ myEnum = channelData->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ o = safe_cast<Object^>(myEnum->Current);
      Console::WriteLine( "\t {0}", o );
   }

   IEnvoyInfo^ envoyInfo = objRefSample->EnvoyInfo;
   if ( envoyInfo == nullptr )
   {
      Console::WriteLine( "This ObjRef does not have envoy information." );
   }
   else
   {
      IMessageSink^ envoySinks = envoyInfo->EnvoySinks;
      Console::WriteLine( "Envoy Sink Class: {0}", envoySinks );
   }

   IRemotingTypeInfo^ typeInfo = objRefSample->TypeInfo;
   Console::WriteLine( "Remote type name: {0}", typeInfo->TypeName );
   Console::WriteLine( "Can my Object* cast to a Bitmap? {0}", typeInfo->CanCastTo( System::Drawing::Bitmap::typeid, objRefSample ) );