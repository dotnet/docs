   CodeTypeDeclaration^ baseClass = gcnew CodeTypeDeclaration( "DocumentProperties" );
   baseClass->IsPartial = true;
   baseClass->IsClass = true;
   baseClass->Attributes = MemberAttributes::Public;

   // Extend the DocumentProperties class in the unit namespace.
   ( *docPropUnit)->Namespaces[ 0 ]->Types->Add( baseClass );