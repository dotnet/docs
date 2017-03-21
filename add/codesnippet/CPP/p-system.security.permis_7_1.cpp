      Console::WriteLine( "Creating the intersection of the second and "
      "first permissions." );
      sp4 = dynamic_cast<DataProtectionPermission^>(sp2->Intersect( sp1 ));
      Console::WriteLine( "The value of the Flags property is: {0}", sp4->Flags );
      