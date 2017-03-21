// Command-line argument examples:
//   <exe_name>
//      - Displays Visual Basic, C#, and JScript compiler settings.
//   <exe_name> Language CSharp
//      - Displays the compiler settings for C#.
//   <exe_name> All
//      - Displays settings for all configured compilers.
//   <exe_name> Config Pascal
//      - Displays settings for configured Pascal language provider,
//        if one exists.
//   <exe_name> Extension .vb
//      - Displays settings for the compiler associated with the .vb
//        file extension.

using System;
using System.Globalization;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace CodeDomCompilerInfoSample
{
    class CompilerInfoSample
    {
        [STAThread]
        static void Main(string[] args)
        {
            String queryCommand = "";
            String queryArg = "";
            int iNumArguments = args.Length;

            // Get input command-line arguments.
            if (iNumArguments > 0)
            {
                queryCommand = args[0].ToUpper(CultureInfo.InvariantCulture);
   
                if (iNumArguments > 1)
                {
                    queryArg = args[1];
                }
            }

            // Determine which method to call.

            Console.WriteLine();
            switch(queryCommand)
            {
                case ("LANGUAGE"):
                    // Display compiler information for input language.
                    DisplayCompilerInfoForLanguage(queryArg);
                    break;

                case ("EXTENSION"):
                    // Display compiler information for input file extension.
                    DisplayCompilerInfoUsingExtension(queryArg);
                    break;

                case ("CONFIG"):
                    // Display settings for the configured language provider.
                    DisplayCompilerInfoForConfigLanguage(queryArg);
                    break;

                case ("ALL"):
                    // Display compiler information for all configured 
                    // language providers.
                    DisplayAllCompilerInfo();
                    break;
  
                default: 
                    // There was no command-line argument, or the 
                    // command-line argument was not recognized.
                    // Display the C#, Visual Basic and JScript 
                    // compiler information.
   
                    DisplayCSharpCompilerInfo();
                    DisplayVBCompilerInfo();
                    DisplayJScriptCompilerInfo();
                    break;
            }

        }
      
        static void DisplayCSharpCompilerInfo()
        {
            // Get the provider for Microsoft.CSharp
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            // Display the C# language provider information.
            Console.WriteLine("CSharp provider is {0}", 
                provider.ToString());
            Console.WriteLine("  Provider hash code:     {0}", 
                provider.GetHashCode().ToString());
            Console.WriteLine("  Default file extension: {0}", 
                provider.FileExtension);

            Console.WriteLine();
        }

        static void DisplayVBCompilerInfo()
        {
            // Get the provider for Microsoft.VisualBasic
            CodeDomProvider provider = CodeDomProvider.CreateProvider("VisualBasic");

            // Display the Visual Basic language provider information.
            Console.WriteLine("Visual Basic provider is {0}", 
                provider.ToString());
            Console.WriteLine("  Provider hash code:     {0}", 
                provider.GetHashCode().ToString());
            Console.WriteLine("  Default file extension: {0}", 
                provider.FileExtension);

            Console.WriteLine();
        }

        static void DisplayJScriptCompilerInfo()
        {
            // Get the provider for JScript.
            CodeDomProvider provider;

            try
            {
                provider = CodeDomProvider.CreateProvider("js");

                // Display the JScript language provider information.
                Console.WriteLine("JScript language provider is {0}", 
                    provider.ToString());
                Console.WriteLine("  Provider hash code:     {0}", 
                    provider.GetHashCode().ToString());
                Console.WriteLine("  Default file extension: {0}", 
                    provider.FileExtension);
                Console.WriteLine();
            }
            catch (System.Configuration.ConfigurationException)
            {
                // The JScript language provider was not found.
                Console.WriteLine("There is no configured JScript language provider.");
            }
        }

        static void DisplayCompilerInfoUsingExtension(string fileExtension)
        {
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
        }
     
        static void DisplayCompilerInfoForLanguage(string language)
        {
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
        }

        static void DisplayCompilerInfoForConfigLanguage(string configLanguage)
        {
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
        }

        static void DisplayAllCompilerInfo()
        {
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
        }
    }
}