   Assembly^ SampleAssembly;
   SampleAssembly = Assembly::LoadFrom( "c:\\Sample.Assembly.dll" );
   // Obtain a reference to a method known to exist in assembly.
   MethodInfo^ Method = SampleAssembly->GetTypes()[ 0 ]->GetMethod( "Method1" );
   // Obtain a reference to the parameters collection of the MethodInfo instance.
   array<ParameterInfo^>^ Params = Method->GetParameters();
   // Display information about method parameters.
   // Param = sParam1
   //   Type = System::String
   //   Position = 0
   //   Optional=False
   for each ( ParameterInfo^ Param in Params )
   {
      Console::WriteLine( "Param= {0}", Param->Name );
      Console::WriteLine( "  Type= {0}", Param->ParameterType );
      Console::WriteLine( "  Position= {0}", Param->Position );
      Console::WriteLine( "  Optional= {0}", Param->IsOptional );
   }