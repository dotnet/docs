   System::Net::NetworkInformation::NetworkInformationPermission^ unrestricted = gcnew System::Net::NetworkInformation::NetworkInformationPermission( System::Security::Permissions::PermissionState::Unrestricted );
   
   Console::WriteLine( L"Is unrestricted? {0}", unrestricted->IsUnrestricted() );
   