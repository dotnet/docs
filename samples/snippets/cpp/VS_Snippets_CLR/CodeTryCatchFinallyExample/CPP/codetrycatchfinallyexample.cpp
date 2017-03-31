

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
public ref class CodeTryCatchFinallyExample
{
public:
   CodeTryCatchFinallyExample()
   {
      
      //<Snippet2>
      // Declares a type to contain a try...catch block.
      CodeTypeDeclaration^ type1 = gcnew CodeTypeDeclaration( "TryCatchTest" );
      
      // Defines a method that throws an exception of type System.ApplicationException.
      CodeMemberMethod^ method1 = gcnew CodeMemberMethod;
      method1->Name = "ThrowApplicationException";
      array<CodePrimitiveExpression^>^temp = {gcnew CodePrimitiveExpression( "Test Application Exception" )};
      method1->Statements->Add( gcnew CodeThrowExceptionStatement( gcnew CodeObjectCreateExpression( "System.ApplicationException",temp ) ) );
      type1->Members->Add( method1 );
      
      // Defines a constructor that calls the ThrowApplicationException method from a try block.
      CodeConstructor^ constructor1 = gcnew CodeConstructor;
      constructor1->Attributes = MemberAttributes::Public;
      type1->Members->Add( constructor1 );
      
      // Defines a try statement that calls the ThrowApplicationException method.
      CodeTryCatchFinallyStatement^ try1 = gcnew CodeTryCatchFinallyStatement;
      try1->TryStatements->Add( gcnew CodeMethodInvokeExpression( gcnew CodeThisReferenceExpression,"ThrowApplicationException", nullptr ) );
      constructor1->Statements->Add( try1 );
      
      // Defines a catch clause for exceptions of type ApplicationException.
      CodeCatchClause^ catch1 = gcnew CodeCatchClause( "ex",gcnew CodeTypeReference( "System.ApplicationException" ) );
      catch1->Statements->Add( gcnew CodeCommentStatement( "Handle any System.ApplicationException here." ) );
      try1->CatchClauses->Add( catch1 );
      
      // Defines a catch clause for any remaining unhandled exception types.
      CodeCatchClause^ catch2 = gcnew CodeCatchClause( "ex" );
      catch2->Statements->Add( gcnew CodeCommentStatement( "Handle any other exception type here." ) );
      try1->CatchClauses->Add( catch2 );
      
      // Defines a finally block by adding to the FinallyStatements collection.
      try1->FinallyStatements->Add( gcnew CodeCommentStatement( "Handle any finally block statements." ) );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //    public class TryCatchTest 
      //    {
      //        
      //        public TryCatchTest() 
      //        {
      //            try 
      //            {
      //                this.ThrowApplicationException();
      //            }
      //            catch (System.ApplicationException ex) 
      //            {
      //                // Handle any System.ApplicationException here.
      //            }
      //            catch (System.Exception ex) 
      //            {
      //                // Handle any other exception type here.
      //            }
      //          finally {
      //                // Handle any finally block statements.
      //            }
      //        }
      //        
      //        private void ThrowApplicationException() 
      //        {
      //            throw new System.ApplicationException("Test Application Exception");
      //        }
      //    }
      //</Snippet2>
   }

};

//</Snippet1>
