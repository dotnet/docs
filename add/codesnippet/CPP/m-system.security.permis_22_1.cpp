      // Remove FileIOPermission from the permission set.
      ps5->RemovePermission( FileIOPermission::typeid );
      Console::WriteLine( "The last permission set after removing FileIOPermission = {0}", ps5 );