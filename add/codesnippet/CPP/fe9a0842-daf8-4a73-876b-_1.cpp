   System::Net::NetworkInformation::NetworkInformationPermission^ permission = gcnew System::Net::NetworkInformation::NetworkInformationPermission( System::Security::Permissions::PermissionState::None );
   permission->AddPermission( System::Net::NetworkInformation::NetworkInformationAccess::Read );
   Console::WriteLine( L"Access is {0}", permission->Access );
   