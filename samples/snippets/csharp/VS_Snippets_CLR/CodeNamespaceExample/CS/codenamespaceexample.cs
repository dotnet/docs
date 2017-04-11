//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeMemberEventExample
    {
        public CodeMemberEventExample()
        {
            //<Snippet2>
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace namespace1 = new CodeNamespace("TestNamespace");
            compileUnit.Namespaces.Add( namespace1 );

            // A C# code generator produces the following source code for the preceeding example code:

            //     namespace TestNamespace {    
            //     }

            //</Snippet2>
        }
    }
}
//</Snippet1>