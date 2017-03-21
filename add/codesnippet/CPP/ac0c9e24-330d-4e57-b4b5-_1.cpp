         MethodBuilder^ myMethodBuilder = nullptr;
         AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;

         // Create assembly in current CurrentDomain.
         AssemblyName^ myAssemblyName = gcnew AssemblyName;
         myAssemblyName->Name = "TempAssembly";

         // Create a dynamic assembly.
         myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );

         // Create a dynamic module in the assembly.
         myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule", true );
         FieldInfo^ myFieldInfo2 = myModuleBuilder->DefineUninitializedData( "myField", 2, FieldAttributes::Public );

         // Create a type in the module.
         TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "TempClass", TypeAttributes::Public );
         FieldBuilder^ myGreetingField = myTypeBuilder->DefineField( "Greeting", String::typeid, FieldAttributes::Public );
         array<Type^>^myConstructorArgs = {String::typeid};

         // Define a constructor of the dynamic class.
         ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );

         // Set the method implementation flags for the constructor.
         myConstructor->SetImplementationFlags( static_cast<MethodImplAttributes>(MethodImplAttributes::PreserveSig | MethodImplAttributes::Runtime) );

         // Get the method implementation flags for the constructor.
         MethodImplAttributes myMethodAttributes = myConstructor->GetMethodImplementationFlags();
         Type^ myAttributeType = MethodImplAttributes::typeid;
         int myAttribValue = (int)myMethodAttributes;
         if (  !myAttributeType->IsEnum )
         {
            Console::WriteLine( "This is not an Enum" );
         }

         // Display the field info names of the retrieved method implementation flags.
         array<FieldInfo^>^myFieldInfo = myAttributeType->GetFields( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static) );
         Console::WriteLine( "The Field info names of the MethodImplAttributes for the constructor are:" );
         for ( int i = 0; i < myFieldInfo->Length; i++ )
         {
            int myFieldValue =  *safe_cast<Int32^>(myFieldInfo[ i ]->GetValue( nullptr ));
            if ( (myFieldValue & myAttribValue) == myFieldValue )
            {
               Console::WriteLine( " {0}", myFieldInfo[ i ]->Name );
            }
         }