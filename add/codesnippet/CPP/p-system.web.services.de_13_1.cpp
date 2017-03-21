   // Get Binding Name = S"MathServiceSoap".
   myBinding = myServiceDescription->Bindings[ "MathServiceHttpGet" ];
   if ( myBinding != nullptr )
   {
      Console::WriteLine( "\n\nName : {0}", myBinding->Name );
      Console::WriteLine( "Type : {0}", myBinding->Type );
   }