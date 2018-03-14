//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeMemberPropertyExample
    {
        public CodeMemberPropertyExample()
        {
            //<Snippet2>
            // Declares a type to contain a field and a constructor method.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("PropertyTest");

            // Declares a field of type String named testStringField.
            CodeMemberField field1 = new CodeMemberField("System.String", "testStringField");
            type1.Members.Add( field1 );

            // Declares a property of type String named StringProperty.
            CodeMemberProperty property1 = new CodeMemberProperty();
            property1.Name = "StringProperty";
            property1.Type = new CodeTypeReference("System.String");
            property1.Attributes = MemberAttributes.Public;
            property1.GetStatements.Add( new CodeMethodReturnStatement( new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "testStringField") ) );
            property1.SetStatements.Add( new CodeAssignStatement( new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "testStringField"), new CodePropertySetValueReferenceExpression()));
            type1.Members.Add(property1);

            // Declares an empty type constructor.
            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = MemberAttributes.Public;            
            type1.Members.Add( constructor1 );
            
            // A C# code generator produces the following source code for the preceeding example code:

            // public class PropertyTest 
            // {
            //        
            //     private string testStringField;
            //
            //     public PropertyTest() 
            //     {
            //     }
            //
            //       public virtual string StringProperty 
            //       {
            //              get 
            //            {
            //                return this.testStringField;
            //            }
            //            set 
            //            {
            //                this.testStringField = value;
            //            }
            //       }
            // }

            //</Snippet2>
        }

        public void SpecificExample()
        {
            //<Snippet3>            
            // Declares a property of type String named StringProperty.
            CodeMemberProperty property1 = new CodeMemberProperty();
            property1.Name = "StringProperty";
            property1.Type = new CodeTypeReference("System.String");
            property1.Attributes = MemberAttributes.Public;
            property1.GetStatements.Add( new CodeMethodReturnStatement( new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "testStringField") ) );
            property1.SetStatements.Add( new CodeAssignStatement( new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "testStringField"), new CodePropertySetValueReferenceExpression()));
            
            // A C# code generator produces the following source code for the preceeding example code:

            //       public virtual string StringProperty 
            //       {
            //              get 
            //            {
            //                return this.testStringField;
            //            }
            //            set 
            //            {
            //                this.testStringField = value;
            //            }
            //       }            
            //</Snippet3>
        }
    }
}
//</Snippet1>