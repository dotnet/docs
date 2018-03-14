// <snippet1>
#using <System.Web.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::Adapters;

public ref class CustomControlAdapter: public ControlAdapter
{
protected:
   virtual void Render( HtmlTextWriter^ writer ) override
   {
      // Access Browser details through the Browser property.
      Version^ jScriptVersion = Browser->JScriptVersion;
      
      // Test if the browser supports Javascript.
      if ( jScriptVersion != nullptr )
      {
         // Render JavaScript-aware markup.
      }
      else
      {
         // Render scriptless markup.
      }
   }
};
// </snippet1>

void main(){}
