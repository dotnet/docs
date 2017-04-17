

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeIterationStatementExample
   {
   public:
      CodeIterationStatementExample()
      {
         //<Snippet2>
         // Declares and initializes an integer variable named testInt.
         CodeVariableDeclarationStatement^ testInt = gcnew CodeVariableDeclarationStatement( int::typeid,"testInt",gcnew CodePrimitiveExpression( (int^)0 ) );
         array<CodeMethodInvokeExpression^>^writelineparams = {gcnew CodeMethodInvokeExpression( gcnew CodeVariableReferenceExpression( "testInt" ),"ToString",nullptr )};
         array<CodeStatement^>^codestatements = {gcnew CodeExpressionStatement( gcnew CodeMethodInvokeExpression( gcnew CodeMethodReferenceExpression( gcnew CodeTypeReferenceExpression( "Console" ),"WriteLine" ),writelineparams ) )};

         // Creates a for loop that sets testInt to 0 and continues incrementing testInt by 1 each loop until testInt is not less than 10.

         // Each loop iteration the value of the integer is output using the Console.WriteLine method.
         CodeIterationStatement^ forLoop = gcnew CodeIterationStatement( gcnew CodeAssignStatement( gcnew CodeVariableReferenceExpression( "testInt" ),gcnew CodePrimitiveExpression( 1 ) ),gcnew CodeBinaryOperatorExpression( gcnew CodeVariableReferenceExpression( "testInt" ),CodeBinaryOperatorType::LessThan,gcnew CodePrimitiveExpression( 10 ) ),gcnew CodeAssignStatement( gcnew CodeVariableReferenceExpression( "testInt" ),gcnew CodeBinaryOperatorExpression( gcnew CodeVariableReferenceExpression( "testInt" ),CodeBinaryOperatorType::Add,gcnew CodePrimitiveExpression( 1 ) ) ),codestatements );

         // A C# code generator produces the following source code for the preceeding example code:
         //     int testInt = 0;
         //     for (testInt = 1; (testInt < 10); testInt = (testInt + 1)) {
         //        Console.WriteLine(testInt.ToString());
         //</Snippet2>
      }
   };
}
//</Snippet1>
