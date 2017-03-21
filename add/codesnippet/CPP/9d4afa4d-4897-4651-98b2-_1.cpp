      MethodBuilder^ myMethodBuilder = nullptr;

      AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;
      // Create assembly in current CurrentDomain
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      // Create a dynamic assembly
      myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly(
         myAssemblyName, AssemblyBuilderAccess::RunAndSave );
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      FieldInfo^ myFieldInfo =
         myModuleBuilder->DefineUninitializedData( "myField", 2, FieldAttributes::Public );
      // Create a type in the module
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "TempClass", TypeAttributes::Public );
      FieldBuilder^ myGreetingField = myTypeBuilder->DefineField( "Greeting",
         String::typeid, FieldAttributes::Public );
      array<Type^>^myConstructorArgs = {String::typeid};
      // Define a constructor of the dynamic class.
      ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor(
         MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );
      PermissionSet^ myPset = gcnew PermissionSet( PermissionState::Unrestricted );
      // Add declarative security to the constructor.
      Console::WriteLine( "Adding declarative security to the constructor....." );
      Console::WriteLine( "The Security action to be taken is \"DENY\" and" +
         " Permission set is \"UNRESTRICTED\"." );
      myConstructor->AddDeclarativeSecurity( SecurityAction::Deny, myPset );
      MethodAttributes myMethodAttributes = myConstructor->Attributes;
      Type^ myAttributeType = MethodAttributes::typeid;
      int myAttribValue = (int)myMethodAttributes;
      if (  !myAttributeType->IsEnum )
      {
         Console::WriteLine( "This is not an Enum" );
      }
      array<FieldInfo^>^myFieldInfo1 = myAttributeType->GetFields( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static) );
      Console::WriteLine( "The Field info names of the Attributes for the constructor are:" );
      for ( int i = 0; i < myFieldInfo1->Length; i++ )
      {
         int myFieldValue =  *dynamic_cast<Int32^>(myFieldInfo1[ i ]->GetValue( nullptr ));
         if ( (myFieldValue & myAttribValue) == myFieldValue )
         {
            Console::WriteLine( "   {0}", myFieldInfo1[ i ]->Name );
         }
      }

      Type^ myType2 = myConstructor->DeclaringType;
      Console::WriteLine( "The declaring type is : {0}", myType2 );
      ParameterBuilder^ myParameterBuilder1 =
         myConstructor->DefineParameter( 1, ParameterAttributes::Out, "My Parameter Name1" );
      Console::WriteLine( "The name of the parameter is : {0}",
         myParameterBuilder1->Name );
      if ( myParameterBuilder1->IsIn )
            Console::WriteLine( "{0} is Input parameter.", myParameterBuilder1->Name );
      else
            Console::WriteLine( "{0} is not Input Parameter.", myParameterBuilder1->Name );
      ParameterBuilder^ myParameterBuilder2 =
         myConstructor->DefineParameter( 1, ParameterAttributes::In, "My Parameter Name2" );
      Console::WriteLine( "The Parameter name is : {0}",
         myParameterBuilder2->Name );
      if ( myParameterBuilder2->IsIn )
            Console::WriteLine( "{0} is Input parameter.", myParameterBuilder2->Name );
      else
            Console::WriteLine( "{0} is not Input Parameter.", myParameterBuilder2->Name );