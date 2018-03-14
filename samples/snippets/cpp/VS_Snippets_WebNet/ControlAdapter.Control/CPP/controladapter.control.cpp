// <snippet1>
#using <System.Web.Mobile.dll>
#using <System.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::Adapters;
using namespace System::Web::UI::WebControls;

public ref class CustomControl: public Control{};

public ref class CustomControlAdapter: public ControlAdapter
{
public:

   property System::Web::UI::Control^ Control 
   {
      // Return a strongly-typed reference to your custom control.
      System::Web::UI::Control^ get()
      {
         return (CustomControl^)ControlAdapter::Control;
      }
   }
   // Override other ControlAdapter members, as necessary. 
};
// </snippet1>

void main(){}
