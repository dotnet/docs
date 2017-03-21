            CodeDomProvider provider;

            // Check for a provider corresponding to the input language.  
            if (CodeDomProvider.IsDefinedLanguage(language))
            {
                provider = CodeDomProvider.CreateProvider(language);

                // Display information about this language provider.

                Console.WriteLine("Language provider:  {0}", 
                    provider.ToString());
                Console.WriteLine();
                Console.WriteLine("  Default file extension:  {0}", 
                    provider.FileExtension);
                Console.WriteLine();

                // Get the compiler settings for this language.

                CompilerInfo langCompilerInfo = CodeDomProvider.GetCompilerInfo(language);
                CompilerParameters langCompilerConfig = langCompilerInfo.CreateDefaultCompilerParameters();
            
                Console.WriteLine("  Compiler options:        {0}", 
                    langCompilerConfig.CompilerOptions);
                Console.WriteLine("  Compiler warning level:  {0}", 
                    langCompilerConfig.WarningLevel);
            }
            else
            {
                // Tell the user that the language provider was not found.
                Console.WriteLine("There is no provider configured for input language \"{0}\".", 
                    language);
            }