//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeMethodReferenceExample
    {
        public CodeMethodReferenceExample()
        {
            //<Snippet2>
            // Declares a type to contain the example code.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("Type1");            
            
            // Declares a method.
            CodeMemberMethod method1 = new CodeMemberMethod();
            method1.Name = "TestMethod";
            type1.Members.Add(method1);
            
            // Declares a type constructor that calls a method.
            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = MemberAttributes.Public;            
            type1.Members.Add( constructor1 );
            
            // Invokes the TestMethod method of the current type object.
            CodeMethodReferenceExpression methodRef1 = new CodeMethodReferenceExpression( new CodeThisReferenceExpression(), "TestMethod" );
            CodeMethodInvokeExpression invoke1 = new CodeMethodInvokeExpression( methodRef1, new CodeParameterDeclarationExpression[] {} );                                    
            constructor1.Statements.Add( invoke1 );
            //</Snippet2>
        }

        public void InvokeExample()
        {
            //<Snippet3>
            // Invokes the TestMethod method of the current type object.
            CodeMethodReferenceExpression methodRef1 = new CodeMethodReferenceExpression( new CodeThisReferenceExpression(), "TestMethod" );
            CodeMethodInvokeExpression invoke1 = new CodeMethodInvokeExpression( methodRef1, new CodeParameterDeclarationExpression[] {} );                                    

            // A C# code generator produces the following source code for the preceeding example code:

            //        this.TestMethod();
            
            //</Snippet3>
        }
    }
}
//</Snippet1>