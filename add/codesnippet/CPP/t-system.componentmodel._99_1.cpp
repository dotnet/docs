      try
      {
         License^ licTest = nullptr;
         licTest = LicenseManager::Validate( Form1::typeid, this );
      }
      catch ( LicenseException^ licE ) 
      {
         Console::WriteLine( licE->Message );
         Console::WriteLine( licE->LicensedType );
         Console::WriteLine( licE->StackTrace );
         Console::WriteLine( licE->Source );
      }