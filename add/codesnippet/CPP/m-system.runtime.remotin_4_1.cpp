   // Determine whether an XML namespace represents a CLR namespace.
   String^ clrNamespace = SoapServices::XmlNsForClrType;
   if ( SoapServices::IsClrTypeNamespace( clrNamespace ) )
   {
      Console::WriteLine( L"The namespace {0} is a CLR namespace.",
         clrNamespace );
   }
   else
   {
      Console::WriteLine( L"The namespace {0} is not a CLR namespace.",
         clrNamespace );
   }