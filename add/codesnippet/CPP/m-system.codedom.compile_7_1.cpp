         array<CompilerInfo^>^allCompilerInfo = CodeDomProvider::GetAllCompilerInfo();
         for ( int i = 0; i < allCompilerInfo->Length; i++ )
         {
            String^ defaultLanguage;
            String^ defaultExtension;
            CompilerInfo^ info = allCompilerInfo[ i ];
            CodeDomProvider^ provider = nullptr;
            if ( info )
               provider = info->CreateProvider();

            if ( provider )
            {
               // Display information about this configured provider.
               Console::WriteLine( "Language provider:  {0}", provider->ToString() );
               Console::WriteLine();
               Console::WriteLine( "  Supported file extension(s):" );
               array<String^>^extensions = info->GetExtensions();
               for ( int i = 0; i < extensions->Length; i++ )
                   Console::WriteLine( "    {0}", extensions[ i ] );

               defaultExtension = provider->FileExtension;
               if (  !defaultExtension->StartsWith( "." ) )
                   defaultExtension = String::Concat( ".", defaultExtension );

               Console::WriteLine( "  Default file extension:  {0}\n", defaultExtension );
               Console::WriteLine( "  Supported language(s):" );
               array<String^>^languages = info->GetLanguages();
               for ( int i = 0; i < languages->Length; i++ )
                   Console::WriteLine( "    {0}", languages[ i ] );

               defaultLanguage = CodeDomProvider::GetLanguageFromExtension( defaultExtension );
               Console::WriteLine(  "  Default language:        {0}", defaultLanguage );
               Console::WriteLine();
               
               // Get the compiler settings for this provider.
               CompilerParameters^ langCompilerConfig = info->CreateDefaultCompilerParameters();
               if ( langCompilerConfig )
               {
                  Console::WriteLine( "  Compiler options:        {0}", langCompilerConfig->CompilerOptions );
                  Console::WriteLine( "  Compiler warning level:  {0}", langCompilerConfig->WarningLevel.ToString() );
               }
            }

         }