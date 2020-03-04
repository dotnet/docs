

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeGotoStatementExample
   {
   public:
      CodeGotoStatementExample()
      {
         
         //<Snippet2>
         // Declares a type to contain the example code.
         CodeTypeDeclaration^ type1 = gcnew CodeTypeDeclaration( "Type1" );
         
         // Declares an entry point method.
         CodeEntryPointMethod^ entry1 = gcnew CodeEntryPointMethod;
         type1->Members->Add( entry1 );
         
         // Adds a goto statement to continue program flow at the "JumpToLabel" label.
         CodeGotoStatement^ goto1 = gcnew CodeGotoStatement( "JumpToLabel" );
         entry1->Statements->Add( goto1 );
         
         // Invokes Console.WriteLine to print "Test Output", which is skipped by the goto statement.
         array<CodeExpression^>^temp = {gcnew CodePrimitiveExpression( "Test Output." )};
         CodeMethodInvokeExpression^ method1 = gcnew CodeMethodInvokeExpression( gcnew CodeTypeReferenceExpression( "System.Console" ),"WriteLine",temp );
         entry1->Statements->Add( method1 );
         
         // Declares a label named "JumpToLabel" associated with a method to output a test string using Console.WriteLine.
         array<CodeExpression^>^temp2 = {gcnew CodePrimitiveExpression( "Output from labeled statement." )};
         CodeMethodInvokeExpression^ method2 = gcnew CodeMethodInvokeExpression( gcnew CodeTypeReferenceExpression( "System.Console" ),"WriteLine",temp2 );
         CodeLabeledStatement^ label1 = gcnew CodeLabeledStatement( "JumpToLabel",gcnew CodeExpressionStatement( method2 ) );
         entry1->Statements->Add( label1 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    public class Type1 
         //    {
         //        
         //        public static void Main() 
         //        {
         //            goto JumpToLabel;
         //            System.Console.WriteLine("Test Output");
         //            JumpToLabel:
         //            System.Console.WriteLine("Output from labeled statement.");
         //        }
         //    }
         //</Snippet2>
      }

   };

}

//</Snippet1>
