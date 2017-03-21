      WindowsIdentity^ windowsIdentity = WindowsIdentity::GetCurrent();
      array<String^>^roles = gcnew array<String^>(10);
      if ( windowsIdentity->IsAuthenticated )
      {
         
         // Add custom NetworkUser role.
         roles[ 0 ] = L"NetworkUser";
      }

      if ( windowsIdentity->IsGuest )
      {
         
         // Add custom GuestUser role.
         roles[ 1 ] = L"GuestUser";
      }

      if ( windowsIdentity->IsSystem )
      {
         
         // Add custom SystemUser role.
         roles[ 2 ] = L"SystemUser";
      }
      
      // Construct a GenericIdentity object based on the current Windows
      // identity name and authentication type.
      String^ authenticationType = windowsIdentity->AuthenticationType;
      String^ userName = windowsIdentity->Name;
      GenericIdentity^ genericIdentity = gcnew GenericIdentity(
         userName,authenticationType );
      
      // Construct a GenericPrincipal object based on the generic identity
      // and custom roles for the user.
      GenericPrincipal^ genericPrincipal = gcnew GenericPrincipal(
         genericIdentity,roles );