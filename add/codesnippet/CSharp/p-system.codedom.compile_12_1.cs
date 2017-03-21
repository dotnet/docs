            CompilerInfo info = CodeDomProvider.GetCompilerInfo(configLanguage);

            // Check whether there is a provider configured for this language.
            if (info.IsCodeDomProviderTypeValid)
            {
                // Get a provider instance using the configured type information.
                CodeDomProvider provider;
                provider = (CodeDomProvider)Activator.CreateInstance(info.CodeDomProviderType);

                // Display information about this language provider.
                Console.WriteLine("Language provider:  {0}", 
                    provider.ToString());
                Console.WriteLine();
                Console.WriteLine("  Default file extension:  {0}", 
                    provider.FileExtension);
                Console.WriteLine();

                // Get the compiler settings for this language.

                CompilerParameters langCompilerConfig = info.CreateDefaultCompilerParameters();
            
                Console.WriteLine("  Compiler options:        {0}", 
                    langCompilerConfig.CompilerOptions);
                Console.WriteLine("  Compiler warning level:  {0}", 
                    langCompilerConfig.WarningLevel);
            }
            else
            {
                // Tell the user that the language provider was not found.
                Console.WriteLine("There is no provider configured for input language \"{0}\".", 
                    configLanguage);
            }