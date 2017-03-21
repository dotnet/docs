public:
   void useDns()
   {
      // Create a DnsPermission instance.
      DnsPermission^ permission = gcnew DnsPermission( PermissionState::Unrestricted );
      // Check for permission.
      permission->Demand();
      Console::WriteLine( "Attributes and Values of DnsPermission instance :" );
      // Print the attributes and values.
      PrintKeysAndValues( permission->ToXml()->Attributes );
      // Check the permission state.
      if ( permission->IsUnrestricted() )
      {
         Console::WriteLine( "Overall permissions : Unrestricted" );
      }
      else
      {
         Console::WriteLine( "Overall permissions : Restricted" );
      }
   }

private:
   void PrintKeysAndValues( Hashtable^ myList )
   {
      // Get the enumerator that can iterate through the hash table.
      IDictionaryEnumerator^ myEnumerator = myList->GetEnumerator();
      Console::WriteLine( "\t-KEY-\t-VALUE-" );
      while ( myEnumerator->MoveNext() )
      {
         Console::WriteLine( "\t {0}:\t {1}", myEnumerator->Key, myEnumerator->Value );
      }
      Console::WriteLine();
   }