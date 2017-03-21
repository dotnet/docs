         If Not fileExtension.StartsWith(".") Then
            fileExtension = "." + fileExtension
         End If

         ' Get the language associated with the file extension.
         If CodeDomProvider.IsDefinedExtension(fileExtension) Then
            Dim provider As CodeDomProvider
            Dim language As String = CodeDomProvider.GetLanguageFromExtension(fileExtension)
            
            Console.WriteLine("The language ""{0}"" is associated with file extension ""{1}""", _
                language, fileExtension)
            Console.WriteLine()
            
            ' Check for a corresponding language provider.
            If CodeDomProvider.IsDefinedLanguage(language) Then
               provider = CodeDomProvider.CreateProvider(language)
               
               ' Display information about this language provider.
               Console.WriteLine("Language provider:  {0}", _
                  provider.ToString())
               Console.WriteLine()
               
               ' Get the compiler settings for this language.
               Dim langCompilerInfo As CompilerInfo = CodeDomProvider.GetCompilerInfo(language)
               Dim langCompilerConfig As CompilerParameters = langCompilerInfo.CreateDefaultCompilerParameters()
               
               Console.WriteLine("  Compiler options:        {0}", _
                   langCompilerConfig.CompilerOptions)
               Console.WriteLine("  Compiler warning level:  {0}", _
                   langCompilerConfig.WarningLevel)
            End If
         Else
            ' Tell the user that the language provider was not found.
            Console.WriteLine("There is no language provider associated with input file extension ""{0}"".", fileExtension)
         End If