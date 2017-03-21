      Console::WriteLine( "Copying the second permission to the fourth "
      "permission." );
      sp4 = dynamic_cast<DataProtectionPermission^>(sp2->Copy());
      rc = sp4->Equals( sp2 );
      Console::WriteLine( "Is the fourth permission equal to the second "
      "permission? {0}", (rc ? (String^)"Yes" : "No") );
      