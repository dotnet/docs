            if (fileExtension[0] != '.')
            {
                fileExtension = "." + fileExtension;
            }

            // Get the language associated with the file extension.
            if (CodeDomProvider.IsDefinedExtension(fileExtension))
            {
                CodeDomProvider provider;
                String language = CodeDomProvider.GetLanguageFromExtension(fileExtension);

                Console.WriteLine("The language \"{0}\" is associated with file extension \"{1}\"", 
                    language, fileExtension);
                Console.WriteLine();
            
                // Next, check for a corresponding language provider.

                if (CodeDomProvider.IsDefinedLanguage(language))
                {
                    provider = CodeDomProvider.CreateProvider(language);

                    // Display information about this language provider.

                    Console.WriteLine("Language provider:  {0}", 
                        provider.ToString());
                    Console.WriteLine();

                    // Get the compiler settings for this language.

                    CompilerInfo langCompilerInfo = CodeDomProvider.GetCompilerInfo(language);
                    CompilerParameters langCompilerConfig = langCompilerInfo.CreateDefaultCompilerParameters();

                    Console.WriteLine("  Compiler options:        {0}", 
                        langCompilerConfig.CompilerOptions);
                    Console.WriteLine("  Compiler warning level:  {0}", 
                        langCompilerConfig.WarningLevel);
                }
            }
            else 
            {
                // Tell the user that the language provider was not found.
                Console.WriteLine("There is no language provider associated with input file extension \"{0}\".", 
                    fileExtension);
            }