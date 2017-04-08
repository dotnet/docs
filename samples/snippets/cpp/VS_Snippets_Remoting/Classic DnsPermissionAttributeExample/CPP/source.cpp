

#using <System.dll>

using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Net;
using namespace System;

//<Snippet1>
//Uses the DnsPermissionAttribute to restrict access only to those who have permission.

[DnsPermission(SecurityAction::Demand,Unrestricted=true)]
public ref class MyClass
{
public:
   static IPAddress^ GetIPAddress()
   {
      IPAddress^ ipAddress = Dns::Resolve( "localhost" )->AddressList[ 0 ];
      return ipAddress;
   }

};

int main()
{
   try
   {
      
      //Grants Access.
      Console::WriteLine( " Access granted\n The local host IP Address is :{0}", MyClass::GetIPAddress() );
   }
   // Denies Access.
   catch ( SecurityException^ securityException ) 
   {
      Console::WriteLine( "Access denied" );
      Console::WriteLine( securityException->ToString() );
   }

}

//</Snippet1>
