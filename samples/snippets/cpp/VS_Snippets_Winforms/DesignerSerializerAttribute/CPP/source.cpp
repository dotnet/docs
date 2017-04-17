#using <System.Drawing.dll>
#using <system.dll>
#using <system.design.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::ComponentModel::Design::Serialization;
using namespace System::Windows::Forms;

namespace ExampleControl
{
   public ref class ExampleSerializer: public CodeDomSerializer
   {
   public:
      ExampleSerializer(){}

      virtual Object^ Deserialize( IDesignerSerializationManager^ /*manager*/, Object^ /*codeObject*/ ) override
      {
         return nullptr;
      }

      virtual Object^ Serialize( IDesignerSerializationManager^ /*manager*/, Object^ /*value*/ ) override
      {
         return nullptr;
      }
   };

   //<Snippet1>
   [DesignerSerializerAttribute(ExampleSerializer::typeid,CodeDomSerializer::typeid)]
   public ref class ExampleControl: public UserControl
   {
   public:
      ExampleControl()
      {

      }
   };
   //</Snippet1>
}
