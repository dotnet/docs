//<snippet1>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Design.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::ComponentModel::Design::Serialization;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace CodeDomSerializerSample
{
   ref class MyComponent;
   private ref class MyCodeDomSerializer: public CodeDomSerializer
   {
   public:
      Object^ Deserialize( IDesignerSerializationManager^ manager, Object^ codeObject ) new
      {
         // This is how we associate the component with the serializer.
         CodeDomSerializer^ baseClassSerializer = (CodeDomSerializer^)(
            manager->GetSerializer(
               MyComponent::typeid->BaseType, CodeDomSerializer::typeid ));
         
         /* This is the simplest case, in which the class just calls the base class
            to do the work. */
         return baseClassSerializer->Deserialize( manager, codeObject );
      }

      Object^ Serialize( IDesignerSerializationManager^ manager, Object^ value ) new
      {
         /* Associate the component with the serializer in the same manner as with
            Deserialize */
         CodeDomSerializer^ baseClassSerializer = (CodeDomSerializer^)(
            manager->GetSerializer(
               MyComponent::typeid->BaseType, CodeDomSerializer::typeid ));

         Object^ codeObject = baseClassSerializer->Serialize( manager, value );
         
         /* Anything could be in the codeObject.  This sample operates on a
            CodeStatementCollection. */
         if ( (CodeStatementCollection^)(codeObject) )
         {
            CodeStatementCollection^ statements = (CodeStatementCollection^)(codeObject);
            
            // The code statement collection is valid, so add a comment.
            String^ commentText = "This comment was added to this object by a custom serializer.";
            CodeCommentStatement^ comment = gcnew CodeCommentStatement( commentText );
            statements->Insert( 0, comment );
         }
         return codeObject;
      }
   };

   //<Snippet2>
   [DesignerSerializer(CodeDomSerializerSample::MyCodeDomSerializer::typeid,
      CodeDomSerializer::typeid)]
   public ref class MyComponent: public Component
   {
   private:
      String^ localProperty;

   public:
      MyComponent()
      {
         localProperty = "Component Property Value";
      }

      property String^ LocalProperty 
      {
         String^ get()
         {
            return localProperty;
         }
         void set( String^ value )
         {
            localProperty = value;
         }
      }
   };
}
//</Snippet2>
//</snippet1>

[STAThread]
int main(){}
