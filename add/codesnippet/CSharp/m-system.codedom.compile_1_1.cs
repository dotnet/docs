            CompilerInfo [] allCompilerInfo = CodeDomProvider.GetAllCompilerInfo();
            foreach (CompilerInfo info in allCompilerInfo)
            {
                String defaultLanguage;
                String defaultExtension;

                CodeDomProvider provider = info.CreateProvider();

                // Display information about this configured provider.

                Console.WriteLine("Language provider:  {0}", 
                    provider.ToString());
                Console.WriteLine();
         
                Console.WriteLine("  Supported file extension(s):");
                foreach(String extension in info.GetExtensions())
                { 
                    Console.WriteLine("    {0}", extension);
                }
   
                defaultExtension = provider.FileExtension;
                if (defaultExtension[0] != '.')
                {
                    defaultExtension = "." + defaultExtension;
                }
                Console.WriteLine("  Default file extension:  {0}", 
                    defaultExtension);
                Console.WriteLine();

                Console.WriteLine("  Supported language(s):");
                foreach(String language in info.GetLanguages())
                { 
                    Console.WriteLine("    {0}", language);
                }

                defaultLanguage = CodeDomProvider.GetLanguageFromExtension(defaultExtension);
                Console.WriteLine("  Default language:        {0}",
                    defaultLanguage);
                Console.WriteLine();

                // Get the compiler settings for this provider.
                CompilerParameters langCompilerConfig = info.CreateDefaultCompilerParameters();
            
                Console.WriteLine("  Compiler options:        {0}", 
                    langCompilerConfig.CompilerOptions);
                Console.WriteLine("  Compiler warning level:  {0}", 
                    langCompilerConfig.WarningLevel);
                Console.WriteLine();
            }