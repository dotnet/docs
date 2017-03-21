   void main()
   {
      AssemblyBuilder^ myAssembly = CreateAssembly("MyEmitTestAssembly");
      
      // Defines a standalone managed resource for this assembly.
      IResourceWriter^ myResourceWriter = 
         myAssembly->DefineResource( "myResourceFile", "A sample Resource File", 
            "MyAssemblyResource.resources", ResourceAttributes::Private );

      myResourceWriter->AddResource( "AddResource Test", "Testing for the added resource" );

      myAssembly->Save(myAssembly->GetName()->Name + ".dll" );
      
      // Defines an unmanaged resource file for this assembly.
      myAssembly->DefineUnmanagedResource(  "MyAssemblyResource.resources" );
   };
