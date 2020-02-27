// The following example builds a CodeDom source graph for a simple
// Hello World program.  The source is then saved to a file,
// compiled into an executable, and run.

// This example is based loosely on the CodeDom example, but its
// primary intent is to illustrate the CompilerParameters class.

// Notice that the snippet is conditionally compiled for Everett vs.
// Whidbey builds.  Whidbey introduced new APIs that are not available
// in Everett.  Snippet IDs do not overlap between Whidbey and Everett;
// Snippet #1 is Everett, Snippet #2 is Whidbey.
#using <System.dll>
//<Snippet1>
using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::IO;
using namespace System::Diagnostics;

// Build a Hello World program graph using System.CodeDom types.
static CodeCompileUnit^ BuildHelloWorldGraph()
{
   // Create a new CodeCompileUnit to contain the program graph.
   CodeCompileUnit^ compileUnit = gcnew CodeCompileUnit;
   
   // Declare a new namespace called Samples.
   CodeNamespace^ samples = gcnew CodeNamespace( "Samples" );
   // Add the new namespace to the compile unit.
   compileUnit->Namespaces->Add( samples );
   
   // Add the new namespace import for the System namespace.
   samples->Imports->Add( gcnew CodeNamespaceImport( "System" ) );
   
   // Declare a new type called Class1.
   CodeTypeDeclaration^ class1 = gcnew CodeTypeDeclaration( "Class1" );
   // Add the new type to the namespace's type collection.
   samples->Types->Add( class1 );
   
   // Declare a new code entry point method
   CodeEntryPointMethod^ start = gcnew CodeEntryPointMethod;
   
   // Create a type reference for the System::Console class.
   CodeTypeReferenceExpression^ csSystemConsoleType =
      gcnew CodeTypeReferenceExpression( "System.Console" );
   
   // Build a Console::WriteLine statement.
   CodeMethodInvokeExpression^ cs1 = gcnew CodeMethodInvokeExpression(
      csSystemConsoleType, "WriteLine",
      gcnew CodePrimitiveExpression( "Hello World!" ) );
   
   // Add the WriteLine call to the statement collection.
   start->Statements->Add( cs1 );
   
   // Build another Console::WriteLine statement.
   CodeMethodInvokeExpression^ cs2 = gcnew CodeMethodInvokeExpression(
      csSystemConsoleType, "WriteLine",
      gcnew CodePrimitiveExpression( "Press the Enter key to continue." ) );
   // Add the WriteLine call to the statement collection.
   start->Statements->Add( cs2 );
   
   // Build a call to System::Console::ReadLine.
   CodeMethodReferenceExpression^ csReadLine = gcnew CodeMethodReferenceExpression(
      csSystemConsoleType, "ReadLine" );
   CodeMethodInvokeExpression^ cs3 = gcnew CodeMethodInvokeExpression(
      csReadLine,gcnew array<CodeExpression^>(0) );
   
   // Add the ReadLine statement.
   start->Statements->Add( cs3 );
   
   // Add the code entry point method to the Members collection
   // of the type.
   class1->Members->Add( start );

   return compileUnit;
}

static String^ GenerateCode( CodeDomProvider^ provider, CodeCompileUnit^ compileunit )
{
   // Build the source file name with the language extension (vb, cs, js).
   String^ sourceFile = String::Empty;

      if ( provider->FileExtension->StartsWith( "." ) )
      {
         sourceFile = String::Concat( "HelloWorld", provider->FileExtension );
      }
      else
      {
         sourceFile = String::Concat( "HelloWorld.", provider->FileExtension );
      }

      // Create a TextWriter to a StreamWriter to an output file.
      IndentedTextWriter^ tw = gcnew IndentedTextWriter(
         gcnew StreamWriter( sourceFile,false ),"    " );
      // Generate source code using the code generator.
      provider->GenerateCodeFromCompileUnit( compileunit, tw, gcnew CodeGeneratorOptions );
      // Close the output file.
      tw->Close();
   return sourceFile;
}

//<Snippet2>
static bool CompileCode( CodeDomProvider^ provider,
   String^ sourceFile,
   String^ exeFile )
{

   CompilerParameters^ cp = gcnew CompilerParameters;
   if ( !cp)  
   {
      return false;
   }

   // Generate an executable instead of 
   // a class library.
   cp->GenerateExecutable = true;
   
   // Set the assembly file name to generate.
   cp->OutputAssembly = exeFile;
   
   // Generate debug information.
   cp->IncludeDebugInformation = true;
   
   // Add an assembly reference.
   cp->ReferencedAssemblies->Add( "System.dll" );
   
   // Save the assembly as a physical file.
   cp->GenerateInMemory = false;
   
   // Set the level at which the compiler 
   // should start displaying warnings.
   cp->WarningLevel = 3;
   
   // Set whether to treat all warnings as errors.
   cp->TreatWarningsAsErrors = false;
   
   // Set compiler argument to optimize output.
   cp->CompilerOptions = "/optimize";
   
   // Set a temporary files collection.
   // The TempFileCollection stores the temporary files
   // generated during a build in the current directory,
   // and does not delete them after compilation.
   cp->TempFiles = gcnew TempFileCollection( ".",true );

   if ( provider->Supports( GeneratorSupport::EntryPointMethod ) )
   {
      // Specify the class that contains 
      // the main method of the executable.
      cp->MainClass = "Samples.Class1";
   }

   if ( Directory::Exists( "Resources" ) )
   {
      if ( provider->Supports( GeneratorSupport::Resources ) )
      {
         // Set the embedded resource file of the assembly.
         // This is useful for culture-neutral resources,
         // or default (fallback) resources.
         cp->EmbeddedResources->Add( "Resources\\Default.resources" );

         // Set the linked resource reference files of the assembly.
         // These resources are included in separate assembly files,
         // typically localized for a specific language and culture.
         cp->LinkedResources->Add( "Resources\\nb-no.resources" );
      }
   }

   // Invoke compilation.
   CompilerResults^ cr = provider->CompileAssemblyFromFile( cp, sourceFile );

   if ( cr->Errors->Count > 0 )
   {
      // Display compilation errors.
      Console::WriteLine( "Errors building {0} into {1}",
         sourceFile, cr->PathToAssembly );
      for each ( CompilerError^ ce in cr->Errors )
      {
         Console::WriteLine( "  {0}", ce->ToString() );
         Console::WriteLine();
      }
   }
   else
   {
      Console::WriteLine( "Source {0} built into {1} successfully.",
         sourceFile, cr->PathToAssembly );
   }

   // Return the results of compilation.
   if ( cr->Errors->Count > 0 )
   {
      return false;
   }
   else
   {
      return true;
   }
}
//</Snippet2>

[STAThread]
void main()
{
   String^ exeName = "HelloWorld.exe";
   CodeDomProvider^ provider = nullptr;

   Console::WriteLine( "Enter the source language for Hello World (cs, vb, etc):" );
   String^ inputLang = Console::ReadLine();
   Console::WriteLine();

   if ( CodeDomProvider::IsDefinedLanguage( inputLang ) )
   {
      CodeCompileUnit^ helloWorld = BuildHelloWorldGraph();
      provider = CodeDomProvider::CreateProvider( inputLang );
      if ( helloWorld && provider )
      {
         String^ sourceFile = GenerateCode( provider, helloWorld );
         Console::WriteLine( "HelloWorld source code generated." );
         if ( CompileCode( provider, sourceFile, exeName ) )
         {
            Console::WriteLine( "Starting HelloWorld executable." );
            Process::Start( exeName );
         }
      }
   }

   if ( provider == nullptr )
   {
      Console::WriteLine( "There is no CodeDomProvider for the input language." );
   }
}
//</Snippet1>

