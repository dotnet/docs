static bool CompileCode( CodeDomProvider^ provider,
   String^ sourceFile,
   String^ exeFile )
{

   CompilerParameters^ cp = gcnew CompilerParameters;
   if ( !cp)  
   {
      return false;
   }

   // Generate an executable instead of 
   // a class library.
   cp->GenerateExecutable = true;
   
   // Set the assembly file name to generate.
   cp->OutputAssembly = exeFile;
   
   // Generate debug information.
   cp->IncludeDebugInformation = true;
   
   // Add an assembly reference.
   cp->ReferencedAssemblies->Add( "System.dll" );
   
   // Save the assembly as a physical file.
   cp->GenerateInMemory = false;
   
   // Set the level at which the compiler 
   // should start displaying warnings.
   cp->WarningLevel = 3;
   
   // Set whether to treat all warnings as errors.
   cp->TreatWarningsAsErrors = false;
   
   // Set compiler argument to optimize output.
   cp->CompilerOptions = "/optimize";
   
   // Set a temporary files collection.
   // The TempFileCollection stores the temporary files
   // generated during a build in the current directory,
   // and does not delete them after compilation.
   cp->TempFiles = gcnew TempFileCollection( ".",true );

   if ( provider->Supports( GeneratorSupport::EntryPointMethod ) )
   {
      // Specify the class that contains 
      // the main method of the executable.
      cp->MainClass = "Samples.Class1";
   }

   if ( Directory::Exists( "Resources" ) )
   {
      if ( provider->Supports( GeneratorSupport::Resources ) )
      {
         // Set the embedded resource file of the assembly.
         // This is useful for culture-neutral resources,
         // or default (fallback) resources.
         cp->EmbeddedResources->Add( "Resources\\Default.resources" );

         // Set the linked resource reference files of the assembly.
         // These resources are included in separate assembly files,
         // typically localized for a specific language and culture.
         cp->LinkedResources->Add( "Resources\\nb-no.resources" );
      }
   }

   // Invoke compilation.
   CompilerResults^ cr = provider->CompileAssemblyFromFile( cp, sourceFile );

   if ( cr->Errors->Count > 0 )
   {
      // Display compilation errors.
      Console::WriteLine( "Errors building {0} into {1}",
         sourceFile, cr->PathToAssembly );
      for each ( CompilerError^ ce in cr->Errors )
      {
         Console::WriteLine( "  {0}", ce->ToString() );
         Console::WriteLine();
      }
   }
   else
   {
      Console::WriteLine( "Source {0} built into {1} successfully.",
         sourceFile, cr->PathToAssembly );
   }

   // Return the results of compilation.
   if ( cr->Errors->Count > 0 )
   {
      return false;
   }
   else
   {
      return true;
   }
}