

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeEntryPointMethodExample
   {
   public:

      //<Snippet2>
      // Builds a Hello World Program Graph using System.CodeDom objects
      static CodeCompileUnit^ BuildHelloWorldGraph()
      {
         
         // Create a new CodeCompileUnit to contain the program graph
         CodeCompileUnit^ CompileUnit = gcnew CodeCompileUnit;
         
         // Declare a new namespace object and name it
         CodeNamespace^ Samples = gcnew CodeNamespace( "Samples" );
         
         // Add the namespace object to the compile unit
         CompileUnit->Namespaces->Add( Samples );
         
         // Add a new namespace import for the System namespace
         Samples->Imports->Add( gcnew CodeNamespaceImport( "System" ) );
         
         // Declare a new type object and name it
         CodeTypeDeclaration^ Class1 = gcnew CodeTypeDeclaration( "Class1" );
         
         // Add the new type to the namespace object's type collection
         Samples->Types->Add( Class1 );
         
         // Declare a new code entry point method
         CodeEntryPointMethod^ Start = gcnew CodeEntryPointMethod;
         
         // Create a new method invoke expression
         array<CodeExpression^>^temp = {gcnew CodePrimitiveExpression( "Hello World!" )};
         CodeMethodInvokeExpression^ cs1 = gcnew CodeMethodInvokeExpression( gcnew CodeTypeReferenceExpression( "System.Console" ),"WriteLine",temp );
         
         // Add the new method code statement
         Start->Statements->Add( gcnew CodeExpressionStatement( cs1 ) );
         
         // Add the code entry point method to the type's members collection
         Class1->Members->Add( Start );
         return CompileUnit;
         
         //</Snippet2>
      }

   };

}

//</Snippet1>
