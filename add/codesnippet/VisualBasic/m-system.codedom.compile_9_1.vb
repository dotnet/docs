         Dim allCompilerInfo As CompilerInfo() = CodeDomProvider.GetAllCompilerInfo()
         Dim info As CompilerInfo
         For Each info In  allCompilerInfo

            Dim defaultLanguage As String
            Dim defaultExtension As String

            Dim provider As CodeDomProvider = info.CreateProvider()
            
            ' Display information about this configured provider.
            Console.WriteLine("Language provider:  {0}", _
                provider.ToString())
            Console.WriteLine()
            
            Console.WriteLine("  Supported file extension(s):")
            Dim extension As String
            For Each extension In info.GetExtensions()
               Console.WriteLine("    {0}", extension)
            Next extension
            
            defaultExtension = provider.FileExtension
            If Not defaultExtension.StartsWith(".") Then
               defaultExtension = "." + defaultExtension
            End If
 
            Console.WriteLine("  Default file extension:  {0}", _
              defaultExtension)
            Console.WriteLine()
            
            Console.WriteLine("  Supported language(s):")
            Dim language As String
            For Each language In  info.GetLanguages()
               Console.WriteLine("    {0}", language)
            Next language
            defaultLanguage = CodeDomProvider.GetLanguageFromExtension(defaultExtension)
            Console.WriteLine("  Default language:        {0}", _
               defaultLanguage)
            Console.WriteLine()
            
            ' Get the compiler settings for this provider.
            Dim langCompilerConfig As CompilerParameters = info.CreateDefaultCompilerParameters()
            
            Console.WriteLine("  Compiler options:        {0}", _
                langCompilerConfig.CompilerOptions)
            Console.WriteLine("  Compiler warning level:  {0}", _
                langCompilerConfig.WarningLevel)
            Console.WriteLine()
         Next info