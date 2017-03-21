      if ( myServiceDescription->Services->Contains( myService ) )
      {
         Console::WriteLine( "The mentioned service exists at index {0} in the WSDL.", myServiceDescription->Services->IndexOf( myService ) );

         array<Service^>^myServiceArray = gcnew array<Service^>(myServiceDescription->Services->Count);

         // Copy the services into an array.
         myServiceDescription->Services->CopyTo( myServiceArray, 0 );
         IEnumerator^ myEnumerator = myServiceArray->GetEnumerator();
         Console::WriteLine( "The names of services in the array are" );
         while ( myEnumerator->MoveNext() )
         {
            Service^ myService1 = dynamic_cast<Service^>(myEnumerator->Current);
            Console::WriteLine( myService1->Name );
         }
      }
      else
      {
         Console::WriteLine( "Service does not exist in the WSDL." );
      }