   CodeTypeDeclaration^ baseClass = gcnew CodeTypeDeclaration( "DocumentProperties" );
   baseClass->IsPartial = true;
   baseClass->IsClass = true;
   baseClass->Attributes = MemberAttributes::Public;
   baseClass->BaseTypes->Add( gcnew CodeTypeReference( System::Object::typeid ) );

   // Add the DocumentProperties class to the namespace.
   sampleSpace->Types->Add( baseClass );