[AttributeUsageAttribute(AttributeTargets::Class)]
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::LinkDemand,
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::InheritanceDemand,
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
public ref class MyProxyAttribute: public ProxyAttribute
{
public:
   MyProxyAttribute(){}

   // Create an instance of ServicedComponentProxy
   virtual MarshalByRefObject^ CreateInstance( Type^ serverType ) override
   {
      return ProxyAttribute::CreateInstance( serverType );
   }

   virtual RealProxy^ CreateProxy( ObjRef^ objRef1, Type^ serverType, Object^ serverObject, Context^ serverContext ) override
   {
      MyProxy^ myCustomProxy = gcnew MyProxy( serverType );
      if ( serverContext != nullptr )
      {
         RealProxy::SetStubData( myCustomProxy, serverContext );
      }

      if ( ( !serverType->IsMarshalByRef) && (serverContext == nullptr) )
      {
         throw gcnew RemotingException( "Bad Type for CreateProxy" );
      }

      return myCustomProxy;
   }
};

[MyProxyAttribute]
ref class CustomServer: public ContextBoundObject
{
public:
   CustomServer()
   {
      Console::WriteLine( "CustomServer Base Class constructor called" );
   }

   void HelloMethod( String^ str )
   {
      Console::WriteLine( "HelloMethod of Server is invoked with message : {0}", str );
   }
};