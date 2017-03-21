public ref class HelloService: public MarshalByRefObject
{
public:
   String^ HelloMethod( String^ name )
   {
      Console::WriteLine( "Hello {0}", name );
      return "Hello {0}",name;
   }


   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]
   String^ HeaderMethod( String^ name, array<Header^>^arrHeader )
   {
      Console::WriteLine( "HeaderMethod {0}", name );
      
      //Header Set with the header array passed
      CallContext::SetHeaders( arrHeader );
      return "HeaderMethod {0}",name;
   }
};