// <snippet10>
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Security::Principal;
using namespace System::Text;
using namespace System::Security::Permissions;

public ref class Remotable: public MarshalByRefObject
{
public:

   // A method to call remotely.
   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]	
   String^ GetMessage()
   {
      // Create a message.
      StringBuilder^ message = gcnew StringBuilder( "call" );
      
      // Identity the calling principal.
      IIdentity^ remoteIdentity = dynamic_cast<IIdentity^>(System::Runtime::Remoting::Messaging::CallContext::GetData( "__remotePrincipal" ));
      if ( remoteIdentity == nullptr )
      {
         message->Append( " by an unknown caller" );
      }
      else
      {
         message->AppendFormat( " by {0}", remoteIdentity->Name );
      }

      
      // Identify the executing principal.
      IIdentity^ localIdentity = dynamic_cast<IIdentity^>(WindowsIdentity::GetCurrent());
      message->AppendFormat( " was executed as {0}.", localIdentity->Name );
      
      // Return the message.
      return (message->ToString());
   }

};

// </snippet10>
