//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeMemberFieldExample
    {
        public CodeMemberFieldExample()
        {
            //<Snippet2>
            // Declares a type to contain a field and a constructor method.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("FieldTest");

            // Declares a field of type String named testStringField.
            CodeMemberField field1 = new CodeMemberField("System.String", "TestStringField");
            type1.Members.Add( field1 );

            // Declares an empty type constructor.
            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = MemberAttributes.Public;            
            type1.Members.Add( constructor1 );
            
            // A C# code generator produces the following source code for the preceeding example code:

            //    public class FieldTest 
            //    {
            //      private string testStringField;
            //        
            //        public FieldTest() 
            //        {
            //        }                            
            //    }            
            //</Snippet2>
        }
    }
}
//</Snippet1>