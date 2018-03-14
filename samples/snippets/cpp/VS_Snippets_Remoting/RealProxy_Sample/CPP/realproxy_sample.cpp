

// System.Runtime.Remoting.Proxies.RealProxy.SupportsInterface(Guid);
// System.Runtime.Remoting.Proxies.RealProxy.GetCOMIUnknown(bool);
// System.Runtime.Remoting.Proxies.RealProxy.SetCOMIUnknown(IntPtr);
/* The following example demonstrates implementation of methods
'GetCOMIUnknown','SupportsInterface' and 'SetCOMIUnknown' of 
System.Runtime.Remoting.Proxies.RealProxy.

The following program has a 'CustomProxy' referring to unmanaged COM component.
A COM Runtime Wrapper takes care of method call to unmanaged world. SupportsInterface
method is overridden to return address of COM Runtime Wrapper.
*/
#using <InterOp.ActiveDS.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Activation;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Contexts;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Permissions;
using namespace ActiveDs;
// using namespace InterOpADS;
public ref class MyProxy: public RealProxy
{
private:
   String^ m_URI;
   MarshalByRefObject^ myMarshalByRefObject;

public:
	[SecurityPermission(SecurityAction::LinkDemand)]
   MyProxy()
      : RealProxy()
   {
      Console::WriteLine( "MyProxy Constructor Called..." );
	  myMarshalByRefObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance(WinNTSystemInfo::typeid ));
      ObjRef^ myObjRef = RemotingServices::Marshal( myMarshalByRefObject );
      m_URI = myObjRef->URI;
   }

   [SecurityPermission(SecurityAction::LinkDemand)]
   MyProxy( Type^ myType )
      : RealProxy( myType )
   {
      Console::WriteLine( "MyProxy Constructor Called..." );
      myMarshalByRefObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( myType ));
      ObjRef^ myObjRef = RemotingServices::Marshal( myMarshalByRefObject );
      m_URI = myObjRef->URI;
   }

   [SecurityPermission(SecurityAction::LinkDemand)]
   MyProxy( Type^ myType, MarshalByRefObject^ targetObject )
      : RealProxy( myType )
   {
      Console::WriteLine( "MyProxy Constructor Called..." );
      myMarshalByRefObject = targetObject;
      ObjRef^ myObjRef = RemotingServices::Marshal( myMarshalByRefObject );
      m_URI = myObjRef->URI;
   }

   [SecurityPermission(SecurityAction::LinkDemand, Flags = SecurityPermissionFlag::Infrastructure)]
   virtual IMessage^ Invoke( IMessage^ msg ) override
   {
      if ( dynamic_cast<IConstructionCallMessage^>(msg) )
      {
         
         // Initialize a new instance of remote object
         IConstructionReturnMessage^ myIConstructionReturnMessage = this->InitializeServerObject( dynamic_cast<IConstructionCallMessage^>(msg) );
         ConstructionResponse^ constructionResponse = gcnew ConstructionResponse( nullptr,dynamic_cast<IMethodCallMessage^>(msg) );
         return constructionResponse;
      }

      IDictionary^ myIDictionary = msg->Properties;
      IMessage^ retMsg;
      myIDictionary->default[ "__Uri" ] = m_URI;
      
      // Synchronously dispatch messages to server.
      retMsg = ChannelServices::SyncDispatchMessage( msg );
      
      // Pushing return value and OUT parameters back onto stack
      IMethodReturnMessage^ mrm = dynamic_cast<IMethodReturnMessage^>(retMsg);
      return retMsg;
   }

   // <Snippet1>
   // <Snippet2>
   // <Snippet3>
   [SecurityPermission(SecurityAction::LinkDemand, Flags = SecurityPermissionFlag::Infrastructure)]
   IntPtr SupportsInterface( Guid * /*myGuid*/ )
   {
      Console::WriteLine( "SupportsInterface method called" );
      
      // Object reference is requested for communication with unmanaged objects
      // in the current process through COM.
      IntPtr myIntPtr = this->GetCOMIUnknown( false );
      
      // Stores an unmanaged proxy of the object.
      this->SetCOMIUnknown( myIntPtr );
      
      // return COM Runtime Wrapper pointer.
      return myIntPtr;
   }
   // </Snippet3>
   // </Snippet2>
   // </Snippet1>
};


// Acts as a custom proxy user.
[SecurityPermission(SecurityAction::LinkDemand)]
int main()
{
   Console::WriteLine( "" );
   Console::WriteLine( "CustomProxy Sample" );
   Console::WriteLine( "==================" );
   MyProxy^ mProxy = gcnew MyProxy( WinNTSystemInfo::typeid);
   WinNTSystemInfo^ myHelloServer = dynamic_cast<WinNTSystemInfo^>(mProxy->GetTransparentProxy());
   Console::WriteLine( "Machine Name = {0}", myHelloServer->ComputerName );
   Console::WriteLine( "Domain Name = {0}", myHelloServer->DomainName );
   Console::WriteLine( "User Name = {0}", myHelloServer->UserName );

   // Construct Guid object from unmanaged Interface 'IADsWinNTSystemInfo' guid.
   Guid myGuid = Guid("{6C6D65DC-AFD1-11D2-9CB9-0000F87A369E}");
   IntPtr myIntrPtr = mProxy->SupportsInterface(  &myGuid );
   Console::WriteLine( "Requested Interface Pointer= {0}", myIntrPtr.ToInt32() );
}
