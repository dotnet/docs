

// System.CodeDom.Compiler.CompilerInfo
// 
// Requires .NET Framework version 2.0 or higher.
//
// The following example displays compiler configuration settings.
// Command-line arguments are used to specify a compiler language,
// file extension, or provider type.  For the given input, the 
// example determines the corresponding code compiler settings.
//
// <Snippet1>
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
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Globalization;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace Microsoft::CSharp;
using namespace Microsoft::VisualBasic;
using namespace System::Configuration;
using namespace System::Security::Permissions;

namespace CodeDomCompilerInfoSample
{
   [PermissionSet(SecurityAction::Demand, Name="FullTrust")]
   public ref class CompilerInfoSample
   {
   public:
      static void Main( array<String^>^args )
      {
         String^ queryCommand = "";
         String^ queryArg = "";
         int iNumArguments = args->Length;
         
         // Get input command-line arguments.
         if ( iNumArguments > 0 )
         {
            queryCommand = args[ 0 ]->ToUpper( CultureInfo::InvariantCulture );
            if ( iNumArguments > 1 )
               queryArg = args[ 1 ];
         }

         // Determine which method to call.
         Console::WriteLine();
         if ( queryCommand->Equals( "LANGUAGE" ) )
             DisplayCompilerInfoForLanguage( queryArg );        // Display compiler information for input language.
         else if ( queryCommand->Equals( "EXTENSION" ) )
             DisplayCompilerInfoUsingExtension( queryArg );     // Display compiler information for input file extension.
         else if ( queryCommand->Equals( "CONFIG" ) )
             DisplayCompilerInfoForConfigLanguage( queryArg );  // Display settings for the configured language provider.
         else if ( queryCommand->Equals( "ALL" ) )
             DisplayAllCompilerInfo();             // Display compiler information for all configured language providers.
         else
         {
            // There was no command-line argument, or the 
            // command-line argument was not recognized.
            // Display the C#, Visual Basic and JScript 
            // compiler information.
            DisplayCSharpCompilerInfo();
            DisplayVBCompilerInfo();
            DisplayJScriptCompilerInfo();
         }
      }


   private:
      static void DisplayCSharpCompilerInfo()
      {
         // <Snippet2>
         // Get the provider for Microsoft.CSharp
//         CodeDomProvider^ provider = CodeDomProvider.CreateProvider("CSharp");
         CodeDomProvider^ provider = CodeDomProvider::CreateProvider("CSharp");

         if ( provider )
         {
            // Display the C# language provider information.
            Console::WriteLine( "CSharp provider is {0}", provider->ToString() );
            Console::WriteLine( "  Provider hash code:     {0}", provider->GetHashCode().ToString() );
            Console::WriteLine( "  Default file extension: {0}", provider->FileExtension );
         }

         // </Snippet2>
         Console::WriteLine();
      }

      static void DisplayVBCompilerInfo()
      {
         // <Snippet3>
         // Get the provider for Microsoft.VisualBasic
//         CodeDomProvider^ provider = CodeDomProvider.CreateProvider("VisualBasic");
         CodeDomProvider^ provider = CodeDomProvider::CreateProvider("VisualBasic");
         if ( provider ) // Display the Visual Basic language provider information.
         {
            Console::WriteLine( "Visual Basic provider is {0}", provider->ToString() );
            Console::WriteLine( "  Provider hash code:     {0}", provider->GetHashCode().ToString() );
            Console::WriteLine( "  Default file extension: {0}", provider->FileExtension );
         }

         // </Snippet3>
         Console::WriteLine();
      }

      static void DisplayJScriptCompilerInfo()
      {
         // <Snippet4>
         // Get the provider for JScript.
         CodeDomProvider^ provider;
         try
         {
//            provider = CodeDomProvider.CreateProvider("JScript");
            provider = CodeDomProvider::CreateProvider("JScript");
            if ( provider )
            {
               // Display the JScript language provider information.
               Console::WriteLine( "JScript language provider is {0}", provider->ToString() );
               Console::WriteLine( "  Provider hash code:     {0}", provider->GetHashCode().ToString() );
               Console::WriteLine( "  Default file extension: {0}", provider->FileExtension );
               Console::WriteLine();
            }
         }
         catch ( ConfigurationException^ e ) 
         {
            // The JScript language provider was not found.
            Console::WriteLine( "There is no configured JScript language provider." );
         }

         // </Snippet4>
      }

      static void DisplayCompilerInfoUsingExtension( String^ fileExtension )
      {
         // <Snippet5> 
         if (  !fileExtension->StartsWith(  "." ) )
            fileExtension = String::Concat( ".", fileExtension );

         // Get the language associated with the file extension.
         CodeDomProvider^ provider = nullptr;
         if ( CodeDomProvider::IsDefinedExtension( fileExtension ) )
         {
            String^ language = CodeDomProvider::GetLanguageFromExtension( fileExtension );
            if ( language )
               Console::WriteLine( "The language \"{0}\" is associated with file extension \"{1}\"\n",
                                    language, fileExtension );

            // Check for a corresponding language provider.
            if ( language && CodeDomProvider::IsDefinedLanguage( language ) )
            {
               provider = CodeDomProvider::CreateProvider( language );
               if ( provider )
               {
                  // Display information about this language provider.
                  Console::WriteLine( "Language provider:  {0}\n", provider->ToString() );
                  
                  // Get the compiler settings for this language.
                  CompilerInfo^ langCompilerInfo = CodeDomProvider::GetCompilerInfo( language );
                  if ( langCompilerInfo )
                  {
                     CompilerParameters^ langCompilerConfig = langCompilerInfo->CreateDefaultCompilerParameters();
                     if ( langCompilerConfig )
                     {
                        Console::WriteLine( "  Compiler options:        {0}", langCompilerConfig->CompilerOptions );
                        Console::WriteLine( "  Compiler warning level:  {0}", langCompilerConfig->WarningLevel.ToString() );
                     }
                  }
               }
            }
         }

         if ( provider == nullptr )  // Tell the user that the language provider was not found.
            Console::WriteLine( "There is no language provider associated with input file extension \"{0}\".", fileExtension );

         // </Snippet5> 
      }

      static void DisplayCompilerInfoForLanguage( String^ language )
      {
         // <Snippet6> 
         CodeDomProvider^ provider = nullptr;
         
         // Check for a provider corresponding to the input language.  
         if ( CodeDomProvider::IsDefinedLanguage( language ) )
         {
            provider = CodeDomProvider::CreateProvider( language );
            if ( provider )
            {
               // Display information about this language provider.
               Console::WriteLine( "Language provider:  {0}", provider->ToString() );
               Console::WriteLine();
               Console::WriteLine( "  Default file extension:  {0}", provider->FileExtension );
               Console::WriteLine();
               
               // Get the compiler settings for this language.
               CompilerInfo^ langCompilerInfo = CodeDomProvider::GetCompilerInfo( language );
               if ( langCompilerInfo )
               {
                  CompilerParameters^ langCompilerConfig = langCompilerInfo->CreateDefaultCompilerParameters();
                  if ( langCompilerConfig )
                  {
                     Console::WriteLine( "  Compiler options:        {0}", langCompilerConfig->CompilerOptions );
                     Console::WriteLine( "  Compiler warning level:  {0}", langCompilerConfig->WarningLevel.ToString() );
                  }
               }
            }
         }

         if ( provider == nullptr )  // Tell the user that the language provider was not found.
            Console::WriteLine(  "There is no provider configured for input language \"{0}\".", language );

         // </Snippet6> 
      }

      static void DisplayCompilerInfoForConfigLanguage( String^ configLanguage )
      {
         // <Snippet7>
         CodeDomProvider^ provider = nullptr;
         CompilerInfo^ info = CodeDomProvider::GetCompilerInfo( configLanguage );
         
         // Check whether there is a provider configured for this language.
         if ( info->IsCodeDomProviderTypeValid )
         {
            // Get a provider instance using the configured type information.
            provider = dynamic_cast<CodeDomProvider^>(Activator::CreateInstance( info->CodeDomProviderType ));
            if ( provider )
            {
               // Display information about this language provider.
               Console::WriteLine( "Language provider:  {0}", provider->ToString() );
               Console::WriteLine();
               Console::WriteLine( "  Default file extension:  {0}", provider->FileExtension );
               Console::WriteLine();
               
               // Get the compiler settings for this language.
               CompilerParameters^ langCompilerConfig = info->CreateDefaultCompilerParameters();
               if ( langCompilerConfig )
               {
                  Console::WriteLine( "  Compiler options:        {0}", langCompilerConfig->CompilerOptions );
                  Console::WriteLine( "  Compiler warning level:  {0}", langCompilerConfig->WarningLevel.ToString() );
               }
            }
         }

         if ( provider == nullptr ) // Tell the user that the language provider was not found.
            Console::WriteLine( "There is no provider configured for input language \"{0}\".", configLanguage );

         // </Snippet7>
      }

      static void DisplayAllCompilerInfo()
      {
         // <Snippet8> 
         array<CompilerInfo^>^allCompilerInfo = CodeDomProvider::GetAllCompilerInfo();
         for ( int i = 0; i < allCompilerInfo->Length; i++ )
         {
            String^ defaultLanguage;
            String^ defaultExtension;
            CompilerInfo^ info = allCompilerInfo[ i ];
            CodeDomProvider^ provider = nullptr;
            if ( info )
               provider = info->CreateProvider();

            if ( provider )
            {
               // Display information about this configured provider.
               Console::WriteLine( "Language provider:  {0}", provider->ToString() );
               Console::WriteLine();
               Console::WriteLine( "  Supported file extension(s):" );
               array<String^>^extensions = info->GetExtensions();
               for ( int i = 0; i < extensions->Length; i++ )
                   Console::WriteLine( "    {0}", extensions[ i ] );

               defaultExtension = provider->FileExtension;
               if (  !defaultExtension->StartsWith( "." ) )
                   defaultExtension = String::Concat( ".", defaultExtension );

               Console::WriteLine( "  Default file extension:  {0}\n", defaultExtension );
               Console::WriteLine( "  Supported language(s):" );
               array<String^>^languages = info->GetLanguages();
               for ( int i = 0; i < languages->Length; i++ )
                   Console::WriteLine( "    {0}", languages[ i ] );

               defaultLanguage = CodeDomProvider::GetLanguageFromExtension( defaultExtension );
               Console::WriteLine(  "  Default language:        {0}", defaultLanguage );
               Console::WriteLine();
               
               // Get the compiler settings for this provider.
               CompilerParameters^ langCompilerConfig = info->CreateDefaultCompilerParameters();
               if ( langCompilerConfig )
               {
                  Console::WriteLine( "  Compiler options:        {0}", langCompilerConfig->CompilerOptions );
                  Console::WriteLine( "  Compiler warning level:  {0}", langCompilerConfig->WarningLevel.ToString() );
               }
            }

         }
       //</Snippet8>
      }

   };

}


// The main entry point for the application.

[STAThread]
int main( int argc, char *argv[] )
{
    CodeDomCompilerInfoSample::CompilerInfoSample::Main( Environment::GetCommandLineArgs() );
    Console::WriteLine("\n\nPress ENTER to return");
    Console::ReadLine();
}

// </Snippet1>
