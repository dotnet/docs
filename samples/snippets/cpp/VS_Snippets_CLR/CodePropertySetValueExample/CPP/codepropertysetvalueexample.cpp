

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodePropertySetValueExample
   {
   public:
      CodePropertySetValueExample()
      {
         
         //<Snippet2>
         // Declares a type.
         CodeTypeDeclaration^ type1 = gcnew CodeTypeDeclaration( "Type1" );
         
         // Declares a constructor.
         CodeConstructor^ constructor1 = gcnew CodeConstructor;
         constructor1->Attributes = MemberAttributes::Public;
         type1->Members->Add( constructor1 );
         
         // Declares an integer field.
         CodeMemberField^ field1 = gcnew CodeMemberField( "System.Int32","integerField" );
         type1->Members->Add( field1 );
         
         // Declares a property.
         CodeMemberProperty^ property1 = gcnew CodeMemberProperty;
         
         // Declares a property get statement to return the value of the integer field.
         property1->GetStatements->Add( gcnew CodeMethodReturnStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"integerField" ) ) );
         
         // Declares a property set statement to set the value to the integer field.
         // The CodePropertySetValueReferenceExpression represents the value argument passed to the property set statement.
         property1->SetStatements->Add( gcnew CodeAssignStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"integerField" ),gcnew CodePropertySetValueReferenceExpression ) );
         type1->Members->Add( property1 );
         
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

   };

}

//</Snippet1>
