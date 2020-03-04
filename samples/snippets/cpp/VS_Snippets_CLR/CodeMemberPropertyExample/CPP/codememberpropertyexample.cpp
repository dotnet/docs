

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeMemberPropertyExample
   {
   public:
      CodeMemberPropertyExample()
      {
         
         //<Snippet2>
         // Declares a type to contain a field and a constructor method.
         CodeTypeDeclaration^ type1 = gcnew CodeTypeDeclaration( "PropertyTest" );
         
         // Declares a field of type String named testStringField.
         CodeMemberField^ field1 = gcnew CodeMemberField( "System.String","testStringField" );
         type1->Members->Add( field1 );
         
         // Declares a property of type String named StringProperty.
         CodeMemberProperty^ property1 = gcnew CodeMemberProperty;
         property1->Name = "StringProperty";
         property1->Type = gcnew CodeTypeReference( "System.String" );
         property1->Attributes = MemberAttributes::Public;
         property1->GetStatements->Add( gcnew CodeMethodReturnStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"testStringField" ) ) );
         property1->SetStatements->Add( gcnew CodeAssignStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"testStringField" ),gcnew CodePropertySetValueReferenceExpression ) );
         type1->Members->Add( property1 );
         
         // Declares an empty type constructor.
         CodeConstructor^ constructor1 = gcnew CodeConstructor;
         constructor1->Attributes = MemberAttributes::Public;
         type1->Members->Add( constructor1 );
         
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

      void SpecificExample()
      {
         
         //<Snippet3>
         // Declares a property of type String named StringProperty.
         CodeMemberProperty^ property1 = gcnew CodeMemberProperty;
         property1->Name = "StringProperty";
         property1->Type = gcnew CodeTypeReference( "System.String" );
         property1->Attributes = MemberAttributes::Public;
         property1->GetStatements->Add( gcnew CodeMethodReturnStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"testStringField" ) ) );
         property1->SetStatements->Add( gcnew CodeAssignStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"testStringField" ),gcnew CodePropertySetValueReferenceExpression ) );
         
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

   };

}

//</Snippet1>
