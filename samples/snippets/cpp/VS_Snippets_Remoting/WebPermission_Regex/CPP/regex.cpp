#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Text::RegularExpressions;
using namespace System::Collections;

void MySample()
{
// <Snippet1>
   //  Create a Regex that accepts all URLs containing the host fragment www.contoso.com.
   Regex^ myRegex = gcnew Regex( "http://www\\.contoso\\.com/.*" );
   
   // Create a WebPermission that gives permissions to all the hosts containing the same host fragment.
   WebPermission^ myWebPermission = gcnew WebPermission( NetworkAccess::Connect,myRegex );
   
   //Add connect privileges for a www.adventure-works.com.
   myWebPermission->AddPermission( NetworkAccess::Connect, "http://www.adventure-works.com" );
   
   //Add accept privileges for www.alpineskihouse.com.
   myWebPermission->AddPermission( NetworkAccess::Accept, "http://www.alpineskihouse.com/" );
   
   // Check whether all callers higher in the call stack have been granted the permission.
   myWebPermission->Demand();
   
   // Get all the URIs with Connect permission.
   IEnumerator^ myConnectEnum = myWebPermission->ConnectList;
   Console::WriteLine( "\nThe 'URIs' with 'Connect' permission are :\n" );
   while ( myConnectEnum->MoveNext() )
   {
      Console::WriteLine( "\t{0}", myConnectEnum->Current );
   }
   
   // Get all the URIs with Accept permission.   
   IEnumerator^ myAcceptEnum = myWebPermission->AcceptList;
   Console::WriteLine( "\n\nThe 'URIs' with 'Accept' permission is :\n" );

   while ( myAcceptEnum->MoveNext() )
   {
      Console::WriteLine( "\t{0}", myAcceptEnum->Current );
   }
// </Snippet1>
}

int main()
{
   MySample();
}
