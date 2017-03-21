      NamedPermissionSet^ allPerms = gcnew NamedPermissionSet(
         L"allPerms" );
      allPerms->AddPermission( gcnew SecurityPermission(
         SecurityPermissionFlag::Execution ) );
      allPerms->AddPermission( gcnew ZoneIdentityPermission(
         SecurityZone::MyComputer ) );
      allPerms->AddPermission( gcnew SiteIdentityPermission(
         L"www.contoso.com" ) );

      ( *policyStatement)->PermissionSet = allPerms;