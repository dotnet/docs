         if (  !fileExtension->StartsWith(  "." ) )
            fileExtension = String::Concat( ".", fileExtension );

         // Get the language associated with the file extension.
         CodeDomProvider^ provider = nullptr;
         if ( CodeDomProvider::IsDefinedExtension( fileExtension ) )
         {
            String^ language = CodeDomProvider::GetLanguageFromExtension( fileExtension );
            if ( language )
               Console::WriteLine( "The language \"{0}\" is associated with file extension \"{1}\"\n",
                                    language, fileExtension );

            // Check for a corresponding language provider.
            if ( language && CodeDomProvider::IsDefinedLanguage( language ) )
            {
               provider = CodeDomProvider::CreateProvider( language );
               if ( provider )
               {
                  // Display information about this language provider.
                  Console::WriteLine( "Language provider:  {0}\n", provider->ToString() );
                  
                  // Get the compiler settings for this language.
                  CompilerInfo^ langCompilerInfo = CodeDomProvider::GetCompilerInfo( language );
                  if ( langCompilerInfo )
                  {
                     CompilerParameters^ langCompilerConfig = langCompilerInfo->CreateDefaultCompilerParameters();
                     if ( langCompilerConfig )
                     {
                        Console::WriteLine( "  Compiler options:        {0}", langCompilerConfig->CompilerOptions );
                        Console::WriteLine( "  Compiler warning level:  {0}", langCompilerConfig->WarningLevel.ToString() );
                     }
                  }
               }
            }
         }

         if ( provider == nullptr )  // Tell the user that the language provider was not found.
            Console::WriteLine( "There is no language provider associated with input file extension \"{0}\".", fileExtension );
