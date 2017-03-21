
      // Display the union of two permission sets.
      PermissionSet^ ps5 = ps3->Union( ps4 );
      Console::WriteLine( "The union of permission set 3 and permission set 4 = {0}", ps5 );