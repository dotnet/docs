//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{    
    public class CodeParameterDeclarationExample
    {
        public CodeParameterDeclarationExample()
        {
            //<Snippet2>            
            // Declares a new type to contain the example methods.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("Type1");

            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = MemberAttributes.Public;            
            type1.Members.Add( constructor1 );    

            //<Snippet3>
            // Declares a method.
            CodeMemberMethod method1 = new CodeMemberMethod();
            method1.Name = "TestMethod";

            // Declares a string parameter passed by reference.
            CodeParameterDeclarationExpression param1 = new CodeParameterDeclarationExpression("System.String", "stringParam");
            param1.Direction = FieldDirection.Ref;
            method1.Parameters.Add(param1);

            // Declares a Int32 parameter passed by incoming field.
            CodeParameterDeclarationExpression param2 = new CodeParameterDeclarationExpression("System.Int32", "intParam");
            param2.Direction = FieldDirection.Out;
            method1.Parameters.Add(param2);

            // A C# code generator produces the following source code for the preceeding example code:

            //        private void TestMethod(ref string stringParam, out int intParam) {
            //        }
            //</Snippet3>

            type1.Members.Add(method1);
            //</Snippet2>
        }
    }
}
//</Snippet1>