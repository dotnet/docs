//<Snippet1>
using System;
using System.CodeDom;
using System.Reflection;

namespace CodeDomSamples
{
    public class CodeTypeDeclarationExample
    {
        public CodeTypeDeclarationExample()
        {
            //<Snippet2>
            // Creates a new type declaration.
            CodeTypeDeclaration newType = new CodeTypeDeclaration(
                // name parameter indicates the name of the type.
                "TestType");
            // Sets the member attributes for the type to private.
            newType.Attributes = MemberAttributes.Private;
            // Sets a base class which the type inherits from.
            newType.BaseTypes.Add( "BaseType" );            
            
            // A C# code generator produces the following source code for the preceeding example code:

            // class TestType : BaseType
            // {
            // }
            //</Snippet2>
        }
    }
}
//</Snippet1>