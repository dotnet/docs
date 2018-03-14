' System.CodeDom.Compiler.CompilerInfo
' 
' Requires .NET Framework version 2.0 or higher.
'
' The following example displays compiler configuration settings.
' Command-line arguments are used to specify a compiler language,
' file extension, or provider type.  For the given input, the 
' example determines the corresponding code compiler settings.
'
' <Snippet1>
' Command-line argument examples:
'   <exe_name>
'      - Displays Visual Basic, C#, and JScript compiler settings.
'   <exe_name> Language CSharp
'      - Displays the compiler settings for C#.
'   <exe_name> All
'      - Displays settings for all configured compilers.
'   <exe_name> Config Pascal
'      - Displays settings for configured Pascal language provider,
'        if one exists.
'   <exe_name> Extension .vb
'      - Displays settings for the compiler associated with the .vb
'        file extension.

Imports System
Imports System.IO
Imports System.Globalization
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp
Imports Microsoft.VisualBasic
Imports System.ComponentModel

Namespace CodeDomCompilerInfoSample

   Class CompilerInfoSample

      <STAThread()>  _
      Public Shared Sub Main(ByVal args() As String)

        Dim queryCommand As String = ""
        Dim queryArg As String = ""
        Dim iNumArguments As Integer = args.Length
        
        ' Get input command-line arguments.
        If iNumArguments > 0 Then
            queryCommand = args(0).ToUpper(CultureInfo.InvariantCulture)
            
            If iNumArguments > 1 Then
                queryArg = args(1)
            End If
        End If
        
        ' Determine which method to call.
        Console.WriteLine()
        Select Case queryCommand
            Case "LANGUAGE"
                ' Display compiler information for input language.
                DisplayCompilerInfoForLanguage(queryArg)
            Case "EXTENSION"
                ' Display compiler information for input file extension.
                DisplayCompilerInfoUsingExtension(queryArg)
            Case "CONFIG"
                ' Display settings for the configured language provider.
                DisplayCompilerInfoForConfigLanguage(queryArg)
            Case "ALL"
                ' Display compiler information for all configured 
                ' language providers.
                DisplayAllCompilerInfo()
            Case Else
                ' There was no command-line argument, or the 
                ' command-line argument was not recognized.
                ' Display the C#, Visual Basic and JScript 
                ' compiler information.
                DisplayCSharpCompilerInfo()
                DisplayVBCompilerInfo()
                DisplayJScriptCompilerInfo()
        End Select

      End Sub 'Main
      
      
      Shared Sub DisplayCSharpCompilerInfo()
         
         ' <Snippet2>
         ' Get the provider for Microsoft.CSharp
            Dim provider = CodeDomProvider.CreateProvider("CSharp")
         
         ' Display the C# language provider information.
         Console.WriteLine("CSharp provider is {0}", _
            provider.ToString())
         Console.WriteLine("  Provider hash code:     {0}", _
            provider.GetHashCode().ToString())
         Console.WriteLine("  Default file extension: {0}", _
            provider.FileExtension)
         
         ' </Snippet2>
         Console.WriteLine()
      End Sub 'DisplayCSharpCompilerInfo
      
      
      Shared Sub DisplayVBCompilerInfo()
         ' <Snippet3>
         ' Get the provider for Microsoft.VisualBasic
            Dim provider = CodeDomProvider.CreateProvider("VisualBasic")
         
         ' Display the Visual Basic language provider information.
         Console.WriteLine("Visual Basic provider is {0}", _
            provider.ToString())
         Console.WriteLine("  Provider hash code:     {0}", _
            provider.GetHashCode().ToString())
         Console.WriteLine("  Default file extension: {0}", _
            provider.FileExtension)
         
         ' </Snippet3>
         Console.WriteLine()
      End Sub 'DisplayVBCompilerInfo
      
      
      Shared Sub DisplayJScriptCompilerInfo()
         ' <Snippet4>
         ' Get the provider for JScript.
         Dim provider As CodeDomProvider
         
         Try
            provider = CodeDomProvider.CreateProvider("js")
            
            ' Display the JScript language provider information.
            Console.WriteLine("JScript language provider is {0}", _
                provider.ToString())
            Console.WriteLine("  Provider hash code:     {0}", _
                provider.GetHashCode().ToString())
            Console.WriteLine("  Default file extension: {0}", _
                provider.FileExtension)
            Console.WriteLine()
         Catch e As System.Configuration.ConfigurationException
            ' The JScript language provider was not found.
            Console.WriteLine("There is no configured JScript language provider.")
         End Try
         ' </Snippet4>

      End Sub 'DisplayJScriptCompilerInfo
      
      Shared Sub DisplayCompilerInfoUsingExtension(fileExtension As String)
         ' <Snippet5> 
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
         ' </Snippet5> 
      End Sub 'DisplayCompilerInfoUsingExtension
     
      
      Shared Sub DisplayCompilerInfoForLanguage(language As String)
         ' <Snippet6> 
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
         ' </Snippet6> 

      End Sub 'DisplayCompilerInfoForLanguage
      
      Shared Sub DisplayCompilerInfoForConfigLanguage(configLanguage As String)
         ' <Snippet7>
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
         ' </Snippet7>
      End Sub 'DisplayCompilerInfoForConfigLanguage
      
      
      Shared Sub DisplayAllCompilerInfo()
         ' <Snippet8> 
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
         ' </Snippet8> 
      End Sub 'DisplayAllCompilerInfo 

   End Class 'CompilerInfoSample
End Namespace 'CodeDomCompilerInfoSample
' </Snippet1>