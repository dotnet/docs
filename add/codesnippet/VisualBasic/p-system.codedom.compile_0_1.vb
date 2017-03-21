         Dim info As CompilerInfo = CodeDomProvider.GetCompilerInfo(configLanguage)
         
         ' Check whether there is a provider configured for this language.
         If info.IsCodeDomProviderTypeValid Then
            ' Get a provider instance using the configured type information.
            Dim provider As CodeDomProvider
            provider = CType(Activator.CreateInstance(info.CodeDomProviderType), CodeDomProvider)
            
            ' Display information about this language provider.
            Console.WriteLine("Language provider:  {0}", _
                provider.ToString())
            Console.WriteLine()
            Console.WriteLine("  Default file extension:  {0}", _
                provider.FileExtension)
            Console.WriteLine()
            
            ' Get the compiler settings for this language.
            Dim langCompilerConfig As CompilerParameters = info.CreateDefaultCompilerParameters()
            
            Console.WriteLine("  Compiler options:        {0}", _
                langCompilerConfig.CompilerOptions)
            Console.WriteLine("  Compiler warning level:  {0}", _
                langCompilerConfig.WarningLevel)
         Else
            ' Tell the user that the language provider was not found.
            Console.WriteLine("There is no provider configured for input language ""{0}"".", configLanguage)
         End If