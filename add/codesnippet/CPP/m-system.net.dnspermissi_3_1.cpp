public:
   void UseDns()
   {
      // Create a DnsPermission instance.
      DnsPermission^ myPermission = gcnew DnsPermission( PermissionState::Unrestricted );
      // Check for permission.
      myPermission->Demand();
      // Create an identical copy of the above 'DnsPermission' Object*.
      DnsPermission^ myPermissionCopy = dynamic_cast<DnsPermission^>(myPermission->Copy());
      Console::WriteLine( "Attributes and Values of 'DnsPermission' instance :" );
      // Print the attributes and values.
      PrintKeysAndValues( myPermission->ToXml()->Attributes );
      Console::WriteLine( "Attribute and values of copied instance :" );
      PrintKeysAndValues( myPermissionCopy->ToXml()->Attributes );
   }

private:
   void PrintKeysAndValues( Hashtable^ myHashtable )
   {
      // Get the enumerator that can iterate through the hash table.
      IDictionaryEnumerator^ myEnumerator = myHashtable->GetEnumerator();
      Console::WriteLine( "\t-KEY-\t-VALUE-" );
      while ( myEnumerator->MoveNext() )
      {
         Console::WriteLine( "\t {0}:\t {1}", myEnumerator->Key, myEnumerator->Value );
      }
      Console::WriteLine();
   }