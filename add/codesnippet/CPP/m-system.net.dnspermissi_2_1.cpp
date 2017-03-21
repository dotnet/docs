public:
   void useDns()
   {
      // Create a DnsPermission instance.
      dnsPermission1 = gcnew DnsPermission( PermissionState::Unrestricted );
      dnsPermission2 = gcnew DnsPermission( PermissionState::None );
      // Check for permission.
      dnsPermission1->Demand();
      dnsPermission2->Demand();
      Console::WriteLine( "Attributes and Values of first DnsPermission instance :" );
      PrintKeysAndValues( dnsPermission1->ToXml()->Attributes );
      Console::WriteLine( "Attributes and Values of second DnsPermission instance :" );
      PrintKeysAndValues( dnsPermission2->ToXml()->Attributes );
      Console::WriteLine( "Union of both instances : " );
      MyUnion();
      Console::WriteLine( "Intersection of both instances : " );
      MyIntersection();
   }

private:
   void PrintKeysAndValues( Hashtable^ myList )
   {
      // Get the enumerator that can iterate through the hash tabble.
      IDictionaryEnumerator^ myEnumerator = myList->GetEnumerator();
      Console::WriteLine( "\t-KEY-\t-VALUE-" );
      while ( myEnumerator->MoveNext() )
      {
         Console::WriteLine( "\t {0}:\t {1}", myEnumerator->Key, myEnumerator->Value );
      }
      Console::WriteLine();
   }

   // Create a DnsPermission instance that is the intersection of current
   // DnsPermission instance and the specified DnsPermission instance.
   void MyIntersection()
   {
      DnsPermission^ permission = dynamic_cast<DnsPermission^>(dnsPermission1->Intersect( dnsPermission2 ));
      // Print the attributes and the values of the intersection instance of
      // DnsPermission.
      PrintKeysAndValues( permission->ToXml()->Attributes );
   }