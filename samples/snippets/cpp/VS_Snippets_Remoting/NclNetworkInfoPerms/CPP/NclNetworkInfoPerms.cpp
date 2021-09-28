
// NclNetworkInfoPerms
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::NetworkInformation;
static void CreatePermission()
{
   
   //<Snippet6>
   //<Snippet5>
   //<Snippet2>
   //<Snippet1>
   System::Net::NetworkInformation::NetworkInformationPermission^ unrestricted = gcnew System::Net::NetworkInformation::NetworkInformationPermission( System::Security::Permissions::PermissionState::Unrestricted );
   
   //</Snippet1>
   Console::WriteLine( L"Is unrestricted? {0}", unrestricted->IsUnrestricted() );
   
   //</Snippet2>
   //<Snippet4>
   //<Snippet3>
   System::Net::NetworkInformation::NetworkInformationPermission^ read = gcnew System::Net::NetworkInformation::NetworkInformationPermission( System::Net::NetworkInformation::NetworkInformationAccess::Read );
   
   //</Snippet3>
   System::Net::NetworkInformation::NetworkInformationPermission^ copyPermission = dynamic_cast<System::Net::NetworkInformation::NetworkInformationPermission^>(read->Copy());
   
   //</Snippet4>
   System::Net::NetworkInformation::NetworkInformationPermission^ unionPermission = dynamic_cast<System::Net::NetworkInformation::NetworkInformationPermission^>(read->Union( unrestricted ));
   Console::WriteLine( L"Is subset?{0}", read->IsSubsetOf( unionPermission ) );
   
   //</Snippet5>
   System::Net::NetworkInformation::NetworkInformationPermission^ intersectPermission = dynamic_cast<System::Net::NetworkInformation::NetworkInformationPermission^>(read->Intersect( unrestricted ));
   
   //</Snippet6>
   //<Snippet7>
   System::Net::NetworkInformation::NetworkInformationPermission^ permission = gcnew System::Net::NetworkInformation::NetworkInformationPermission( System::Security::Permissions::PermissionState::None );
   permission->AddPermission( System::Net::NetworkInformation::NetworkInformationAccess::Read );
   Console::WriteLine( L"Access is {0}", permission->Access );
   
   //</Snippet7>
}

int main()
{
   CreatePermission();
}

