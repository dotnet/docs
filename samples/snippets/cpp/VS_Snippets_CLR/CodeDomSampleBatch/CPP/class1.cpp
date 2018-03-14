#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSampleBatch
{
   public ref class Class1
   {
   public:
      Class1(){}

      static CodeCompileUnit^ CreateCompileUnit()
      {
         CodeCompileUnit^ cu = gcnew CodeCompileUnit;
         
         //<Snippet1>
         // Creates a code expression for a CodeExpressionStatement to contain.
         array<CodeExpression^>^ temp = {gcnew CodePrimitiveExpression( "Example string" )};
         CodeExpression^ invokeExpression = gcnew CodeMethodInvokeExpression(
            gcnew CodeTypeReferenceExpression( "Console" ),"Write",temp );
         
         // Creates a statement using a code expression.
         CodeExpressionStatement^ expressionStatement;
         expressionStatement = gcnew CodeExpressionStatement( invokeExpression );
         
         // A C++ code generator produces the following source code for the preceeding example code:

         // Console::Write( "Example string" );
         //</Snippet1>

         //<Snippet2>
         // Creates a CodeLinePragma that references line 100 of the file "example.cs".
         CodeLinePragma^ pragma = gcnew CodeLinePragma( "example.cs",100 );
         //</Snippet2>

         //<Snippet9>
         // Creates a CodeSnippetExpression that represents a literal string that
         // can be used as an expression in a CodeDOM graph.
         CodeSnippetExpression^ literalExpression =
            gcnew CodeSnippetExpression( "Literal expression" );
         //</Snippet9>

         //<Snippet10>
         // Creates a statement using a literal string.
         CodeSnippetStatement^ literalStatement =
            gcnew CodeSnippetStatement( "Console.Write(\"Test literal statement output\")" );
         //</Snippet10>

         //<Snippet11>
         // Creates a type member using a literal string.
         CodeSnippetTypeMember^ literalMember =
            gcnew CodeSnippetTypeMember( "public static void TestMethod() {}" );
         //</Snippet11>
         return cu;
      }

      static CodeCompileUnit^ CreateSnippetCompileUnit()
      {
         //<Snippet8>
         // Creates a compile unit using a literal sring;
         String^ literalCode;
         literalCode = "using System; namespace TestLiteralCode " +
            "{ public class TestClass { public TestClass() {} } }";
         CodeSnippetCompileUnit^ csu = gcnew CodeSnippetCompileUnit( literalCode );
         //</Snippet8>
         return csu;
      }

      // CodeNamespaceImportCollection
      void CodeNamespaceImportCollectionExample()
      {
         //<Snippet3>
         //<Snippet4>
         // Creates an empty CodeNamespaceImportCollection.
         CodeNamespaceImportCollection^ collection =
            gcnew CodeNamespaceImportCollection;
         //</Snippet4>

         //<Snippet5>
         // Adds a CodeNamespaceImport to the collection.
         collection->Add( gcnew CodeNamespaceImport( "System" ) );
         //</Snippet5>

         //<Snippet6>
         // Adds an array of CodeNamespaceImport objects to the collection.
         array<CodeNamespaceImport^>^ Imports = {
            gcnew CodeNamespaceImport( "System" ),
            gcnew CodeNamespaceImport( "System.Drawing" )};
         collection->AddRange( Imports );
         //</Snippet6>

         //<Snippet7>
         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;
         //</Snippet7>            
         //</Snippet3>
      }
   };
}
