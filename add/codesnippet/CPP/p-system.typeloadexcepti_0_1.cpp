   // Load the mscorlib assembly and get a reference to it.
   // You must supply the fully qualified assembly name for mscorlib.dll here.
   Assembly^ myAssembly = Assembly::Load( "Assembly text name, Version, Culture, PublicKeyToken" );
   try
   {
      Console::WriteLine( "This program throws an exception upon successful run." );
      
      // Attempt to load a non-existent type from an assembly. 
      Type^ myType = myAssembly->GetType( "System.NonExistentType", true );
   }
   catch ( TypeLoadException^ e ) 
   {
      // Display the name of the Type that was not found.
      Console::WriteLine( "TypeLoadException: \n\tError loading the type '{0}' from the assembly 'mscorlib'", e->TypeName );
      Console::WriteLine( "\tError Message = {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: Error Message = {0}", e->Message );
   }