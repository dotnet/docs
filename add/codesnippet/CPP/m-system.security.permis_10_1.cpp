      // Display the intersection of two permission sets.
      PermissionSet^ ps3 = ps2->Intersect( ps1 );
      Console::WriteLine( "The intersection of the first permission set and the second permission set = {0}", ps3 );