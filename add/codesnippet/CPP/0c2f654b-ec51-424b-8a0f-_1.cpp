   System::Net::NetworkInformation::NetworkInformationPermission^ unrestricted = gcnew System::Net::NetworkInformation::NetworkInformationPermission( System::Security::Permissions::PermissionState::Unrestricted );
   
   Console::WriteLine( L"Is unrestricted? {0}", unrestricted->IsUnrestricted() );
   
   System::Net::NetworkInformation::NetworkInformationPermission^ read = gcnew System::Net::NetworkInformation::NetworkInformationPermission( System::Net::NetworkInformation::NetworkInformationAccess::Read );
   
   System::Net::NetworkInformation::NetworkInformationPermission^ copyPermission = dynamic_cast<System::Net::NetworkInformation::NetworkInformationPermission^>(read->Copy());
   
   System::Net::NetworkInformation::NetworkInformationPermission^ unionPermission = dynamic_cast<System::Net::NetworkInformation::NetworkInformationPermission^>(read->Union( unrestricted ));
   Console::WriteLine( L"Is subset?{0}", read->IsSubsetOf( unionPermission ) );
   