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