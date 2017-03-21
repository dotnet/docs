   // Get Import by Index.
   Import^ myImport = myServiceDescription->Imports[ myServiceDescription->Imports->Count - 1 ];
   Console::WriteLine( "Import by Index..." );
   if ( myImportCollection->Contains( myImport ) )
   {
      Console::WriteLine( "Import Namespace ' {0} ' is found in 'ImportCollection'.", myImport->Namespace );
      Console::WriteLine( "Index of '{0}' in 'ImportCollection' = {1}",
         myImport->Namespace, myImportCollection->IndexOf( myImport ) );
      Console::WriteLine( "Deleting Import from 'ImportCollection'..." );
      myImportCollection->Remove( myImport );
      if ( myImportCollection->IndexOf( myImport ) == -1 )
            Console::WriteLine( "Import is successfully removed from Import Collection." );
   }