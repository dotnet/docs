//This sample requires full trust
[PermissionSetAttribute(SecurityAction::Demand, Name = "FullTrust")]
public ref class MyProxy: public RealProxy
{
private:
   String^ stringUri;
   MarshalByRefObject^ targetObject;

public:
   MyProxy( Type^ type )
      : RealProxy( type )
   {
      targetObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( type ));
      ObjRef^ myObject = RemotingServices::Marshal( targetObject );
      stringUri = myObject->URI;
   }

   MyProxy( Type^ type, MarshalByRefObject^ targetObject )
      : RealProxy( type )
   {
      this->targetObject = targetObject;
   }

   virtual IMessage^ Invoke( IMessage^ message ) override
   {
      message->Properties[ "__Uri" ] = stringUri;
      IMethodMessage^ myMethodMessage = dynamic_cast<IMethodMessage^>(ChannelServices::SyncDispatchMessage( message ));
      Console::WriteLine( "---------IMethodMessage* example-------" );
      Console::WriteLine( "Method name : {0}", myMethodMessage->MethodName );
      Console::WriteLine( "LogicalCallContext has information : {0}", myMethodMessage->LogicalCallContext->HasInfo );
      Console::WriteLine( "Uri : {0}", myMethodMessage->Uri );
      return myMethodMessage;
   }
};