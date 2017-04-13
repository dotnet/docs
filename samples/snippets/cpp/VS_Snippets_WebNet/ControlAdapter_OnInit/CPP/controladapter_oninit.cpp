// <snippet1>
#using <System.Web.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::Adapters;

public ref class CustomControlAdapter: public ControlAdapter
{
   // Override the ControlAdapter default OnInit implementation.
protected:
   virtual void OnInit( EventArgs^ e ) override
   {
      // Make the control invisible.
      Control->Visible = false;
      
      // Call the base method, which calls OnInit of the control,
      // which raises the control Init event.
      ControlAdapter::OnInit( e );
   }
};
// </snippet1>

void main(){}
