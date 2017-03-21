         Dim provider As CodeDomProvider
         
         ' Check for a provider corresponding to the input language.  
         If CodeDomProvider.IsDefinedLanguage(language) Then
            provider = CodeDomProvider.CreateProvider(language)
            
            ' Display information about this language provider.
            Console.WriteLine("Language provider:  {0}", _
                provider.ToString())
            Console.WriteLine()
            Console.WriteLine("  Default file extension:  {0}", _
                provider.FileExtension)
            Console.WriteLine()
            
            ' Get the compiler settings for this language.
            Dim langCompilerInfo As CompilerInfo = CodeDomProvider.GetCompilerInfo(language)
            Dim langCompilerConfig As CompilerParameters = langCompilerInfo.CreateDefaultCompilerParameters()
            
            Console.WriteLine("  Compiler options:        {0}", _
                langCompilerConfig.CompilerOptions)
            Console.WriteLine("  Compiler warning level:  {0}", _
                langCompilerConfig.WarningLevel)
         Else
            ' Tell the user that the language provider was not found.
            Console.WriteLine("There is no provider configured for input language ""{0}"".", _
                language)
         End If