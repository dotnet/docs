   bool SetGetPathListDemo()
   {
      try
      {
         Console::WriteLine( "********************************************************\n" );
         FileIOPermission^ fileIOPerm1;
         Console::WriteLine( "Creating a FileIOPermission with AllAccess rights for 'C:\\Examples\\Test\\TestFile.txt" );
         
         fileIOPerm1 = gcnew FileIOPermission( FileIOPermissionAccess::AllAccess,"C:\\Examples\\Test\\TestFile.txt" );
         
         Console::WriteLine( "Adding 'C:\\Temp' to the write access list, and \n 'C:\\Examples\\Test' to read access." );
         fileIOPerm1->AddPathList( FileIOPermissionAccess::Write, "C:\\Temp" );
         fileIOPerm1->AddPathList( FileIOPermissionAccess::Read, "C:\\Examples\\Test" );
         array<String^>^paths = fileIOPerm1->GetPathList( FileIOPermissionAccess::Read );
         Console::WriteLine( "Read access before SetPathList = " );
         IEnumerator^ myEnum = paths->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            String^ path = safe_cast<String^>(myEnum->Current);
            Console::WriteLine( "\t{0}", path );
         }

         Console::WriteLine( "Setting the read access list to \n'C:\\Temp'" );
         fileIOPerm1->SetPathList( FileIOPermissionAccess::Read, "C:\\Temp" );
         paths = fileIOPerm1->GetPathList( FileIOPermissionAccess::Read );
         Console::WriteLine( "Read access list after SetPathList = " );
         IEnumerator^ myEnum1 = paths->GetEnumerator();
         while ( myEnum1->MoveNext() )
         {
            String^ path = safe_cast<String^>(myEnum1->Current);
            Console::WriteLine( "\t{0}", path );
         }

         paths = fileIOPerm1->GetPathList( FileIOPermissionAccess::Write );
         Console::WriteLine( "Write access list after SetPathList = " );
         IEnumerator^ myEnum2 = paths->GetEnumerator();
         while ( myEnum2->MoveNext() )
         {
            String^ path = safe_cast<String^>(myEnum2->Current);
            Console::WriteLine( "\t{0}", path );
         }

         Console::WriteLine( "Write access = \n{0}", fileIOPerm1->GetPathList( FileIOPermissionAccess::AllAccess ) );
      }
      catch ( ArgumentException^ e ) 
      {
         
         // FileIOPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
         Console::WriteLine( "An ArgumentException occurred as a result of using AllAccess. This property cannot be used as a parameter in GetPathList because it represents more than one type of file variable access. : \n{0}", e );
      }

      return true;
   }

