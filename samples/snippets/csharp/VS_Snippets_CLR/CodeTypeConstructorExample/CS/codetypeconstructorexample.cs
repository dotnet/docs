//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeTypeConstructorExample
    {
        public CodeTypeConstructorExample()
        {
            //<Snippet2>
            // Declares a new type for a static constructor.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("Type1");
            // Declares a static constructor.
            CodeTypeConstructor constructor2 = new CodeTypeConstructor();
            // Adds the static constructor to the type.
            type1.Members.Add( constructor2 );

            // A C# code generator produces the following source code for the preceeding example code:

            //    public class Type1 
            //    {
            //
            //        static Type1() 
            //        {
            //        }       
            //    }
            //</Snippet2>
        }
    }
}
//</Snippet1>