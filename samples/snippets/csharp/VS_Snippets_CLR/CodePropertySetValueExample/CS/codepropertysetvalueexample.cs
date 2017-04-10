//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodePropertySetValueExample
    {
        public CodePropertySetValueExample()
        {
            //<Snippet2>
            // Declares a type.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("Type1");

            // Declares a constructor.
            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = MemberAttributes.Public;
            type1.Members.Add( constructor1 );

            // Declares an integer field.
            CodeMemberField field1 = new CodeMemberField("System.Int32", "integerField");
            type1.Members.Add( field1 );

            // Declares a property.
            CodeMemberProperty property1 = new CodeMemberProperty();
            // Declares a property get statement to return the value of the integer field.
            property1.GetStatements.Add( new CodeMethodReturnStatement( new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "integerField") ) );
            // Declares a property set statement to set the value to the integer field.
            // The CodePropertySetValueReferenceExpression represents the value argument passed to the property set statement.
            property1.SetStatements.Add( new CodeAssignStatement( new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "integerField"), 
                                                new CodePropertySetValueReferenceExpression() ) );
            type1.Members.Add( property1 );

            // A C# code generator produces the following source code for the preceeding example code:

            //    public class Type1 
            //    {
            //
            //        private int integerField;
            //
            //        public Type1() 
            //        {
            //        }
            //                            
            //        private int integerProperty 
            //        {
            //            get 
            //            {
            //                return this.integerField;
            //            }
            //            set 
            //            {
            //                this.integerField = value;
            //            }
            //        }
            //    }
            //</Snippet2>
        }
    }
}
//</Snippet1>