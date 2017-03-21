      // Display the result of a call to the ContainsNonCodeAccessPermissions method.
      // Gets a value indicating whether the PermissionSet contains permissions
      // that are not derived from CodeAccessPermission.
      // Returns true if the PermissionSet contains permissions that are not
      // derived from CodeAccessPermission; otherwise, false.
      Console::WriteLine( "ContainsNonCodeAccessPermissions method returned {0}", ps1->ContainsNonCodeAccessPermissions() );