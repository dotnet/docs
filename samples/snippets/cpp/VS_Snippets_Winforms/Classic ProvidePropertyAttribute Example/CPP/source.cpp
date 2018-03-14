

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Globalization;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

// <Snippet1>
[ProvideProperty("MyProperty",Control::typeid)]
public ref class MyClass: public IExtenderProvider
{
protected:
   CultureInfo^ ciMine;

public:
   // Provides the Get portion of MyProperty. 
   CultureInfo^ GetMyProperty( Control^ myControl )
   {
      // Insert code here.
      return ciMine;
   }

   // Provides the Set portion of MyProperty.
   void SetMyProperty( Control^ myControl, String^ value )
   {
      // Insert code here.
   }

   /* When you inherit from IExtenderProvider, you must implement the 
        * CanExtend method. */
   virtual bool CanExtend( Object^ target )
   {
      return dynamic_cast<Control^>(target) != nullptr;
   }
   // Insert additional code here.
};
// </Snippet1>
