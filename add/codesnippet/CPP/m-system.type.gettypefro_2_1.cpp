   MyClass1^ myClass1 = gcnew MyClass1;
   // Get the type referenced by the specified type handle.
   Type^ myClass1Type = Type::GetTypeFromHandle( Type::GetTypeHandle( myClass1 ) );
   Console::WriteLine( "The Names of the Attributes : {0}", myClass1Type->Attributes );