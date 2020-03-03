

//<Snippet2>
#using <system.dll>
#using <system.design.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;

namespace DesignerHostTest
{
   public ref class DesignerHostDesigner: public ComponentDesigner
   {
   public:
      DesignerHostDesigner(){}

      virtual void DoDefaultAction() override
      {
         //<Snippet1>
         // Requests an IDesignerHost service from the design time environment using Component.Site.GetService()
         IDesignerHost^ dh = static_cast<IDesignerHost^>(this->Component->Site->GetService( IDesignerHost::typeid ));
         //</Snippet1>
      }
   };
}
//</Snippet2>
