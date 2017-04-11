using System;
using System.CodeDom;

namespace CodeMemberField_PublicConst_Example
{
	public class Class1
	{        
        private static CodeCompileUnit GetCompileUnit()
        {			
            CodeCompileUnit cu = new CodeCompileUnit();

            CodeNamespace nsp = new CodeNamespace("TestNamespace");
            cu.Namespaces.Add( nsp );

            CodeTypeDeclaration testType = new CodeTypeDeclaration("testType");
            nsp.Types.Add( testType );

            //<Snippet1>
            // This example demonstrates declaring a public constant type member field.
            
            // When declaring a public constant type member field, you must set a particular
            // access and scope mask to the member attributes of the field in order for the
            // code generator to properly generate the field as a constant field.

            // Declares an integer field using a CodeMemberField
            CodeMemberField constPublicField = new CodeMemberField(typeof(int), "testConstPublicField");
            
            // Resets the access and scope mask bit flags of the member attributes of the field
            // before setting the member attributes of the field to public and constant.
            constPublicField.Attributes = (constPublicField.Attributes & ~MemberAttributes.AccessMask & ~MemberAttributes.ScopeMask) | MemberAttributes.Public | MemberAttributes.Const;
            //</Snippet1>

            testType.Members.Add( constPublicField );            
            return cu;
        }
        
	}
}
