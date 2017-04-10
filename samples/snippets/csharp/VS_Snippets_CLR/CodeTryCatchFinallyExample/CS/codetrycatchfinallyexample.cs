//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeTryCatchFinallyExample
    {
        public CodeTryCatchFinallyExample()
        {
            //<Snippet2>
            // Declares a type to contain a try...catch block.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("TryCatchTest");

            // Defines a method that throws an exception of type System.ApplicationException.
            CodeMemberMethod method1 = new CodeMemberMethod();
            method1.Name = "ThrowApplicationException";
            method1.Statements.Add( new CodeThrowExceptionStatement( 
                new CodeObjectCreateExpression("System.ApplicationException", new CodePrimitiveExpression("Test Application Exception")) ) );
            type1.Members.Add( method1 );

            // Defines a constructor that calls the ThrowApplicationException method from a try block.
            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = MemberAttributes.Public;            
            type1.Members.Add( constructor1 );    
        
            // Defines a try statement that calls the ThrowApplicationException method.
            CodeTryCatchFinallyStatement try1 = new CodeTryCatchFinallyStatement();
            try1.TryStatements.Add( new CodeMethodInvokeExpression( new CodeThisReferenceExpression(), "ThrowApplicationException" ) );
            constructor1.Statements.Add( try1 );                    

            // Defines a catch clause for exceptions of type ApplicationException.
            CodeCatchClause catch1 = new CodeCatchClause("ex", new CodeTypeReference("System.ApplicationException"));
            catch1.Statements.Add( new CodeCommentStatement("Handle any System.ApplicationException here.") );
            try1.CatchClauses.Add( catch1 );
            
            // Defines a catch clause for any remaining unhandled exception types.
            CodeCatchClause catch2 = new CodeCatchClause("ex");
            catch2.Statements.Add( new CodeCommentStatement("Handle any other exception type here.") );
            try1.CatchClauses.Add( catch2 );
        
            // Defines a finally block by adding to the FinallyStatements collection.
            try1.FinallyStatements.Add( new CodeCommentStatement("Handle any finally block statements.") );
        
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
    }
}
//</Snippet1>