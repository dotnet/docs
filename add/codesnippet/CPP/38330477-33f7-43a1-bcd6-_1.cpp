      // Create a WebPermission.
      WebPermission^ myWebPermission1 = gcnew WebPermission;

      // Allow Connect access to the specified URLs.
      myWebPermission1->AddPermission( NetworkAccess::Connect, gcnew Regex( "http://www\\.contoso\\.com/.*",
         (RegexOptions)(RegexOptions::Compiled | RegexOptions::IgnoreCase | RegexOptions::Singleline) ) );

      myWebPermission1->Demand();