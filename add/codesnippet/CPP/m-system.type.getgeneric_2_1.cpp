      if ( t->IsGenericType )
      {
         
         // If this is a generic type, display the type arguments.
         //
         array<Type^>^typeArguments = t->GetGenericArguments();
         Console::WriteLine( L"\tList type arguments ({0}):",
            typeArguments->Length );
         System::Collections::IEnumerator^ myEnum =
            typeArguments->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Type^ tParam = safe_cast<Type^>(myEnum->Current);
            
            // If this is a type parameter, display its
            // position.
            //
            if ( tParam->IsGenericParameter )
            {
               Console::WriteLine(
                  L"\t\t{0}\t(unassigned - parameter position {1})",
                  tParam, tParam->GenericParameterPosition );
            }
            else
            {
               Console::WriteLine( L"\t\t{0}", tParam );
            }
         }
      }