      // Create a second permission set and compare it to the first permission set.
      ps2->AddPermission( gcnew EnvironmentPermission( EnvironmentPermissionAccess::Read,"USERNAME" ) );
      ps2->AddPermission( gcnew EnvironmentPermission( EnvironmentPermissionAccess::Write,"COMPUTERNAME" ) );
	  IEnumerator^ list =  ps1->GetEnumerator();
	  Console::WriteLine("Permissions in first permission set:");
            while (list->MoveNext())
				Console::WriteLine(list->Current->ToString());
      Console::WriteLine( "Second permission IsSubsetOf first permission = {0}", ps2->IsSubsetOf( ps1 ) );